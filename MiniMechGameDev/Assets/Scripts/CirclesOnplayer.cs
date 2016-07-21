using UnityEngine;
using System.Collections;

public class CirclesOnplayer : MonoBehaviour
{

    // Use this for initialization
    private Animator AnimObjec;
    public AudioSource ShootSound;

    void Start()
    {
        AnimObjec = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

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