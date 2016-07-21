using UnityEngine;
using System.Collections;

public class ScoreAnim : MonoBehaviour {

    // Use this for initialization
    private int PreviouScore = 0;
    private Animator AnimObjec;
    private AudioSource Cheer;
    void Start ()
    {
        AnimObjec = this.gameObject.GetComponent<Animator>();
        Cheer = this.gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (ScoreManager.Instance.Scores.CurrScore > PreviouScore)
        {
            //Debug.Log("IVEDONEIT");
            PreviouScore = ScoreManager.Instance.Scores.CurrScore;
            AnimObjec.SetTrigger("Scored");
            Cheer.Play();
        }
    }
}
