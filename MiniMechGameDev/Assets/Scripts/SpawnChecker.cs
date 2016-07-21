using UnityEngine;
using System.Collections;
using System;

public class SpawnChecker : MonoBehaviour {
    public static Action<bool> canCollide;
    bool isColliding, oldColliding;        

    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.tag == "Chunck")
            canCollide(true);
    }   

    void Update()
    {
        /*
        if (!isColliding) {
            canCollide(true);
        }

        isColliding = false;
    */
    }
}
