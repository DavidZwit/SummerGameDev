using UnityEngine;
using System.Collections;

public class DestroyAfterFinish : MonoBehaviour {


    ParticleSystem ps;

    void Awake()
    {
        ps = this.transform.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (!ps.isPlaying)
            Destroy(this.transform.gameObject);
    }

}
