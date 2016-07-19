using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Ball : MonoBehaviour {

    public GameObject PlayerOnePos;
    public GameObject PlayerTwoPos;
    bool shootBack = false;
    float passTimer = 2;
    


    void Start ()
    {
        StartCoroutine(shootTimer());
	}
	
    IEnumerator shootTimer()
    {
        while (true)
        {
            StartCoroutine(Shoot(shootBack ? PlayerOnePos.transform : PlayerTwoPos.transform, new Vector3(0, 0, 2)));
            shootBack = !shootBack;
            yield return new WaitForSeconds(passTimer);
        }

    }

	void Update ()
    {
       
    }
   
    void OnTriggerEnter(Collider _Col)
    {
        
        if(_Col.tag == "Hostile")
        {
            Debug.Log("hit u");

        }
    }

    IEnumerator Shoot(Transform targetPos, Vector3 offset)
    {
        float distance= 5000;
        while (distance > 0.05f)
        {
            Vector3 calPos = transform.position - offset;
            distance = Mathf.Abs(calPos.x - targetPos.position.x);

            transform.position -= new Vector3(
                (calPos.x - targetPos.position.x) / 20,
                0,
                (calPos.z - targetPos.position.z) / 20
            );

            calPos += offset;
            yield return new WaitForFixedUpdate();
        }
        transform.position = targetPos.position + offset;
    }
}
