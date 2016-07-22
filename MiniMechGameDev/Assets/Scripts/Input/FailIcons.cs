using UnityEngine;
using UnityEngine.UI;
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
            // this.transform.GetChild(0).transform.GetComponent<Image>().enabled = true;
            // AnimObject.SetTrigger("Live1");
            this.transform.GetChild(0).transform.GetComponent<Animator>().enabled = true;
        }

        if (ScoreManager.Instance.Scores.CurrFails == 2)
        {
            this.transform.GetChild(1).transform.GetComponent<Animator>().enabled = true;
            // AnimObject.SetTrigger("Live2");
        }

        if (ScoreManager.Instance.Scores.CurrFails == 3)
        {
            this.transform.GetChild(2).transform.GetComponent<Animator>().enabled = true;
            // AnimObject.SetTrigger("Live3");
        }
    }
}
