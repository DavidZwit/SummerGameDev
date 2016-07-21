using UnityEngine;
using System.Collections;

public class AnimationObject : MonoBehaviour {

    private Animator AnimObjec;
    //public GameObject Lights;
    public Transform partis;
	void Start ()
    {
        
        AnimObjec = this.gameObject.GetComponent<Animator>();
        //partis = GetComponentInChildren<ParticleSystem>();
        partis.GetComponent<ParticleSystem>().enableEmission = false;
       // if (Lights!=null)
        //Lights.SetActive(false);
    }
	
	
	void Update ()
    {
	
	}
    void OnTriggerEnter(Collider _Col)
    {
        if(_Col.tag == "Player")
        {
            Debug.Log("animate me");
            
            
            if (partis != null)
            {
                partis.GetComponent<ParticleSystem>().enableEmission = true;
                StartCoroutine(Sparkles());
            }
            if (AnimObjec != null)
                AnimObjec.SetTrigger("Left");

            //Debug.Log(partis);
            // if (Lights != null)
            // {
            //     Lights.SetActive(true);
            //     Invoke("turn", 0.5f);
            //  }
        }
    }

   // void turn()
    //{
    //    Lights.SetActive(false);
    //}

    IEnumerator Sparkles()
    {
        yield return new WaitForSeconds(0.4f);
        partis.GetComponent<ParticleSystem>().enableEmission = false;
    }
}
