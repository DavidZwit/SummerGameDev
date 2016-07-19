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
        if(_Col.tag == "Player")
        {
            Debug.Log("animate me");
            AnimObjec.SetTrigger("Active");
        }
    }
}
