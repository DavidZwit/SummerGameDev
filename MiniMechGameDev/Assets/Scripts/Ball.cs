using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ball : Singleton<Ball>
{

    [Range(0,5)]
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

    private bool UpdatedCheck = false;
    private bool UpdateScore
    {
        get
        {
            if(ReceivedBall && Target != Origin && !UpdatedCheck)
            {
                UpdatedCheck = true;
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
                ShotBall = false;
                return true;
            }

            return false;
        }
    }

    private float DistanceToTarget
    {
        get { return Vector3.Distance(this.transform.position, target.position); }
    }

    [Range(0, 5)]
    public float ReceiveOffset = 2;


	void Start()
    {
        if (Target == null)
            Target = GameObject.Find("P1_TEST").transform;

        if (Origin == null)
            Origin = Target;

    }


	void Update()
	{
        if(Input.GetKeyDown(KeyCode.A))
        {
            PassBall(GameObject.Find("P1_TEST").transform, 5, GameObject.Find("P2_TEST").transform);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            PassBall(GameObject.Find("P2_TEST").transform, 5, GameObject.Find("P1_TEST").transform);
        }

        if (!ReceivedBall)
            transform.position = Vector3.Lerp(transform.position, Target.position, PassSpeed * Time.deltaTime);


        if (!UpdateScore) return;

        ScoreManager.Instance.Scores.AddToScore(ScoreManager.Instance.SmallScore);
        // Debug.Log("Current score : " + ScoreManager.Instance.Scores.CurrScore);
    }

    public void PassBall(Transform t, float s, Transform o)
    {
        ShotBall = true;
        // Debug.Log("Pass ball from : " + t.transform.position + ", to : " + o.transform.position);
        Target = t;
        PassSpeed = s;
        Origin = o;
    }

    void OnTriggerEnter(Collider _col)
    {
        if(_col.tag == "Obstacles")
        {
            // Debug.Log("Hit an obstacle, attempting to go back to : " + Origin.transform.name);
            PassBall(Origin, PassSpeed/1.5f, Origin);
            CameraShaker.Instance.shakeDuration = .4f;
        }
    }

}

