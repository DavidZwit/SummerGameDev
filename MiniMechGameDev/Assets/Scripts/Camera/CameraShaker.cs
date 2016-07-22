using UnityEngine;
using System.Collections;

public class CameraShaker : Singleton<CameraShaker>
{
    /*
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.4f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.position;
    }

    void Update()
    {
        originalPos = camTransform.position;

        if (shakeDuration > 0)
        {
            camTransform.position = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            // camTransform.localPosition = originalPos;
        }
    }


    */
    private Vector3 originPosition;
    private Quaternion originRotation;
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
            transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
            transform.rotation = new Quaternion(
                originRotation.x,
                originRotation.y,
                originRotation.z + Random.Range(-shake_intensity, shake_intensity) * .2f,
                originRotation.w);
            shake_intensity -= shake_decay;
        }
        else
        {
            transform.rotation = originRotation;
        }

    }

    public void SmallShake()
    {
        originPosition = transform.position;
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
