﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Ball : Singleton<Ball>
{
    public bool isLeftPlayer = false;

	private bool _passTo1 = false;
	private bool _didHitObj = false;
    [Range(0, 15)]
    public float PassSpeed = 2;
    private Transform target;
    public Transform Target
    {
        get { return target; }
        set { target = value; }
    }

    private Transform origin;
    public Transform Origin
    {
        get { return origin; }
        set { origin = value; }
    }

    private bool shotBall;
    public bool ShotBall
    {
        get
        {
            return shotBall;
        }
        set
        {
            if (value) UpdatedCheck = false;
            shotBall = value;
        }
    }

    private int ScoreCheck = 0;
    private bool UpdatedCheck = false;
    public bool UpdateScore
    {
        get
        {
            if (ReceivedBall && Target != Origin && !UpdatedCheck)
            {
                UpdatedCheck = true;

                if (Target == PlayerPassLineTool.Instance.players[1].transform)
                {
					Debug.Log (target.gameObject.name + "First IF, origin :" + Origin + " + Target: " + Target);
					isLeftPlayer = true;
                }
                else  
                {
					Debug.Log (target.gameObject.name + "second IF, origin :" + Origin + " + Target: " + Target);
					isLeftPlayer = false;
                }

                return true;
            }

            return false;
        }
    }
    private bool ReceivedBall
    {
        get
        {
            if (DistanceToTarget <= ReceiveOffset)
            {
                if (Target.GetComponent<PlayerInfo>().Left)
                {
                    PlayerPassLineTool.Instance.CurrentPlayer = 1;
                    target.GetComponent<CirclesOnplayer>().StartParticles();
                }
                else
                {
                    PlayerPassLineTool.Instance.CurrentPlayer = -1;
                    target.GetComponent<CirclesOnplayer>().StartParticles();
                }
                this.transform.parent = Target;
                ShotBall = false;
                return true;
            }
            else
            {

            }
            return false;
        }
    }
    /*
    private bool ReceivedBall
    {
        get
        {
			if (DistanceToTarget <= ReceiveOffset) {
				if (Target.GetComponent<PlayerInfo> ().Left) {
					PlayerPassLineTool.Instance.CurrentPlayer = 1;
					target.GetComponent<CirclesOnplayer> ().StartParticles ();
				} else {
					PlayerPassLineTool.Instance.CurrentPlayer = -1;
					target.GetComponent<CirclesOnplayer> ().StartParticles ();
				}
				this.transform.parent = Target;
				ShotBall = false;
				return true;
			} else {
				target.GetComponent<CirclesOnplayer> ().StopParticles ();
			}
			target.GetComponent<CirclesOnplayer> ().StopParticles ();
            return false;
        }
    }
    */
    private bool HitSomething = false;

    private float DistanceToTarget
    {
        get { return Vector3.Distance(this.transform.position, target.position); }
    }

    [Range(0, 5)]
    public float ReceiveOffset = 2;


    void Start()
    {
        if (Target == null)
            Target = PlayerPassLineTool.Instance.Players[0].transform;

		if (Origin == null)
			Origin = Target;

        ScoreCheck = PlayerPassLineTool.Instance.CurrentPlayer;

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Target.AnimateCameraToMe(2);
            PassBall(PlayerPassLineTool.Instance.Players[0].transform, 5, PlayerPassLineTool.Instance.Players[1].transform);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            // Origin.AnimateCameraToMe(2);
            // GameObject.Find("Right_View").transform.AnimateCameraToMe(1);
            PassBall(PlayerPassLineTool.Instance.Players[1].transform, 5, PlayerPassLineTool.Instance.Players[0].transform);
        }

        if (!ReceivedBall)
        {
            //transform.position = Vector3.Lerp(transform.position, Target.position, PassSpeed * Time.deltaTime);
            Rigidbody rb = this.transform.GetComponent<Rigidbody>();

            //rb.AddForce((Target.position - transform.position) * 50 * Time.deltaTime);
			rb.AddForce((Target.position - transform.position) * PassSpeed * Time.smoothDeltaTime, ForceMode.Impulse);

            if (rb.drag <= 5f)
                rb.drag += (1.45f / DistanceToTarget);
        }
        else
        {
            this.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.transform.GetComponent<Rigidbody>().drag = 0;
        }




        if (!UpdateScore) return;

        if (ScoreCheck == PlayerPassLineTool.Instance.CurrentPlayer) return;


        ScoreCheck = PlayerPassLineTool.Instance.CurrentPlayer;
        if (!HitSomething)
        {
            ScoreManager.Instance.Scores.AddToScore(ScoreManager.Instance.SmallScore);
            ParticleSpawner.Instance.SpawnParticle(this.transform.position, ParticleSpawner.Instance.particlesList[0]);

            Text[] AllText = FindObjectsOfType<Text>();
            for (int i = 0; i < AllText.Length; i++)
            {
                if (AllText[i].transform.name.Contains("CurrentScore"))
                {
                    AllText[i].text = "Score: " + ScoreManager.Instance.Scores.CurrScore.ToString();
                    break;
                }
            }

        }


        // Debug.Log("Current score : " + ScoreManager.Instance.Scores.CurrScore);
    }


    public void PassBall(Transform t, float s, Transform o)
    {

        HitSomething = false;
        this.transform.GetComponent<Rigidbody>().drag = 0;
        this.transform.parent = null;
        ShotBall = true;
        target.GetComponent<CirclesOnplayer>().StopParticles();
        // Debug.Log("Pass ball from : " + t.transform.position + ", to : " + o.transform.position);
        Target = t;
        PassSpeed = s;
        Origin = o;
    }
    /*
    public void PassBall(Transform t, float s, Transform o)
    {
        HitSomething = false;
        this.transform.GetComponent<Rigidbody>().drag = 0;
        this.transform.parent = null;
        ShotBall = true;
        // Debug.Log("Pass ball from : " + t.transform.position + ", to : " + o.transform.position);
        Target = t;
        PassSpeed = s;
        Origin = o;
    }
    */
    void OnCollisionEnter(Collision _col)
    {
        if (_col.transform.tag == "Dummie")
        {
            if(!HitSomething)
                ScoreManager.Instance.Scores.AddToFails (1);

            ParticleSpawner.Instance.SpawnParticle(_col.transform.position, ParticleSpawner.Instance.particlesList[1]);

            HitSomething = true;
            _col.transform.GetComponent<Rigidbody>().isKinematic = false;
            // Debug.Log("Hit an obstacle, attempting to go back to : " + Origin.transform.name
            // this.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _col.transform.FindChild("sheet").GetComponent<ParticleSystem>().Play();
            // this.transform.GetComponent<Rigidbody>().drag = 0;
            // PassBall(Origin, PassSpeed *2, Origin);
            // CameraShaker.Instance.shakeDuration = .1f;
            CameraShaker.Instance.SmallShake();

        }
    }
	public void ShootTheBallFromState()
	{
		if (Origin == Target) {
			_passTo1 = _passTo1;
		} else {
			_passTo1 = !_passTo1;
		}
		if (_passTo1) {
			PassBall (PlayerPassLineTool.Instance.Players [0].transform, 10, PlayerPassLineTool.Instance.Players [1].transform);
        }
        else {
			PassBall (PlayerPassLineTool.Instance.Players [1].transform, 10, PlayerPassLineTool.Instance.Players [0].transform);
        }

    }
}

