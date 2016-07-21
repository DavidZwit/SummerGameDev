using UnityEngine;
using System.Collections;

public class CirclesOnplayer : MonoBehaviour
{

    // Use this for initialization
    private Animator AnimObjec;
    public AudioSource ShootSound;
    // private int Score;
    private int PreviouScore = 0;

    void Start()
    {
        AnimObjec = this.gameObject.GetComponent<Animator>();
       
    //    Score= ScoreManager.Instance.Scores.CurrScore;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Previous score: " + PreviouScore + ", Current Score: " + Score);
        if(ScoreManager.Instance.Scores.CurrScore > PreviouScore)
        {
            Debug.Log("IVEDONEIT");
            PreviouScore = ScoreManager.Instance.Scores.CurrScore;
            AnimObjec.SetTrigger("Level");
        }
    }

    void OnTriggerEnter(Collider _Col)
    {
        if (_Col.tag == "Player")
        {
            Debug.Log("animate me");

            if (AnimObjec != null)
                AnimObjec.SetBool("HasBall", true);
        }
    }

    void OnTriggerExit(Collider _Col)
    {
        if (_Col.tag == "Player")
        {
            if (AnimObjec != null)
                AnimObjec.SetBool("HasBall", false);
            if (ShootSound != null)
            {
                ShootSound.Play();
            }
        }
    }
}