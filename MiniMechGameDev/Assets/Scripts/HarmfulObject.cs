using UnityEngine;
using System.Collections;

public class HarmfulObject : MonoBehaviour {

    private Animator AnimObjec;


	void Start ()
    {
        AnimObjec = GetComponentInChildren<Animator>();

    }
	
	
	void Update ()
    {
	
	}
    void OnTriggerEnter(Collider _Col)
    {
		Debug.Log (_Col);
		if(_Col.gameObject.tag == "Player")
        {
            Debug.Log("animate me");
            AnimObjec.SetTrigger("Active");
        }
    }

}
