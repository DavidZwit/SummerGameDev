using UnityEngine;
using System.Collections;

public class CameraShaker : Singleton<CameraShaker>
{
    private Vector3 originPosition;
    private Quaternion originRotation;

    bool goBack;

    float shake_decay = 0.001f;
    float shake_intensity;

    void Start()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
    }

    void Update()
    {
        if (shake_intensity > 0)
        {
            OverwriteOrigin();
            transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
            transform.rotation = new Quaternion(
                originRotation.x,
                originRotation.y,
                originRotation.z + Random.Range(-shake_intensity, shake_intensity) * .2f,
                originRotation.w);
            shake_intensity -= shake_decay;
            goBack = true;
        }
        else
        {
            if (goBack) {
                Debug.Log("Get back to origin");
                transform.position = originPosition;
                transform.rotation = originRotation;
                goBack = false;
            } 
        }
    }

    public void OverwriteOrigin()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
    }

    public void SmallShake()
    {
        // Debug.Log("cast a small shake");
        originPosition = this.transform.position;
        shake_intensity = .035f;
        shake_decay = 0.01f;
    }

    public void BigShake()
    {
        originPosition = transform.position;
        shake_intensity = .1f;
        shake_decay = 0.02f;

    }
}
