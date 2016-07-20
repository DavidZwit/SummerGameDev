using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Ball : Singleton<Ball>
{

    [Range(0, 5)]
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
    public bool UpdateScore
    {
        get
        {
            if (ReceivedBall && Target != Origin && !UpdatedCheck)
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
                if (Target.GetComponent<PlayerInfo>().Left)
                    PlayerPassLineTool.Instance.CurrentPlayer = 1;
                else
                    PlayerPassLineTool.Instance.CurrentPlayer = -1;

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
            Target = PlayerPassLineTool.Instance.Players[0].transform;

        if (Origin == null)
            Origin = Target;

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PassBall(PlayerPassLineTool.Instance.Players[0].transform, 5, PlayerPassLineTool.Instance.Players[1].transform);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            PassBall(PlayerPassLineTool.Instance.Players[1].transform, 5, PlayerPassLineTool.Instance.Players[0].transform);
        }

        if (!ReceivedBall)
        {
            //transform.position = Vector3.Lerp(transform.position, Target.position, PassSpeed * Time.deltaTime);
            Rigidbody rb = this.transform.GetComponent<Rigidbody>();

            //rb.AddForce((Target.position - transform.position) * 50 * Time.deltaTime);
            rb.AddForce((Target.position - transform.position) * 6f * Time.smoothDeltaTime, ForceMode.Impulse);

            if (rb.drag <= 5f)
                rb.drag += (1.45f / DistanceToTarget);
        }
        else
        {
            this.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.transform.GetComponent<Rigidbody>().drag = 0;
        }




        if (!UpdateScore) return;

        ScoreManager.Instance.Scores.AddToScore(ScoreManager.Instance.SmallScore);
        Text[] AllText = FindObjectsOfType<Text>();
        for (int i = 0; i < AllText.Length; i++)
        {
            if (AllText[i].transform.name.Contains("Score"))
            {
                AllText[i].text = "Score: " + ScoreManager.Instance.Scores.CurrScore.ToString();
                break;
            }
        }


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
        if (_col.tag == "Obstacles")
        {
            // Debug.Log("Hit an obstacle, attempting to go back to : " + Origin.transform.name);
            PassBall(Origin, PassSpeed / 1.5f, Origin);
            CameraShaker.Instance.shakeDuration = .4f;
        }
    }

}

