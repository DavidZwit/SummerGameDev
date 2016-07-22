using UnityEngine;
using System.Collections;

public class FailIcons : MonoBehaviour {

    private Animator AnimObject;
    

	// Use this for initialization
	void Start ()
    {
        AnimObject = this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(ScoreManager.Instance.Scores.CurrFails== 1)
        {
            AnimObject.SetTrigger("Live1");
        }

        if (ScoreManager.Instance.Scores.CurrFails == 2)
        {
            AnimObject.SetTrigger("Live2");
        }

        if (ScoreManager.Instance.Scores.CurrFails == 3)
        {
            AnimObject.SetTrigger("Live3");
        }
    }
}
