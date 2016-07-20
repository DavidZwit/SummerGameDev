using UnityEngine;
using System.Collections;

public class HarmfulObject : MonoBehaviour {

    private Animator AnimObjec;
    public GameObject Lights;

	void Start ()
    {
        
        AnimObjec = this.gameObject.GetComponent<Animator>();
        if (Lights!=null)
        Lights.SetActive(false);
    }
	
	
	void Update ()
    {
	
	}
    void OnTriggerEnter(Collider _Col)
    {
        if(_Col.tag == "Player")
        {
            Debug.Log("animate me");
            
            if (AnimObjec!=null)
            AnimObjec.SetTrigger("Active");

            if (Lights != null)
            {
                Lights.SetActive(true);
                Invoke("turn", 0.5f);
            }
        }
    }

    void turn()
    {
        Lights.SetActive(false);
    }
}
