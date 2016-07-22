using UnityEngine;
using System.Collections;
using System;

public class PositionAnimator : MonoBehaviour
{

    Coroutine position, rotation;

    public void Animate(Transform targetPosition, float time, Vector3 offset, Action Done)
    {
        if (position != null) StopCoroutine(position);
        if (rotation != null) StopCoroutine(rotation);

        inputs = 0;

        position = StartCoroutine(PositionToTarget(targetPosition.position + offset, time, () => { if (Done != null) Done(); }));
        rotation = StartCoroutine(RotateLikeTarget(targetPosition.rotation, time, () => { if (Done != null) Done(); }));
    }

    WaitForFixedUpdate update = new WaitForFixedUpdate();

    //Animate position to target
    IEnumerator PositionToTarget(Vector3 dest, float time, Action arrived)
    {
        while (Vector3.Distance(transform.position, dest) > 0.2f)
        {
            transform.position = Vector3.Lerp(transform.position, dest, Time.deltaTime * time);
            yield return update;
        }
        transform.position = dest;
        AndGate(arrived);
    }

    //Animate rotation to target
    IEnumerator RotateLikeTarget(Quaternion targetRot, float time, Action arrived)
    {
        while (Quaternion.Angle(transform.rotation, targetRot) > 0.2f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * time);
            yield return update;
        }
        transform.rotation = targetRot;
        AndGate(arrived);
    }

    int inputs = 2;
    void AndGate(Action fire)
    {
        if (inputs <= 0) inputs--;
        else
        {
            fire();
            inputs = 0;
        }
    }
}

public static class ExtentionMethod
{
    public static void AnimateCameraToMe(this Transform trans, float time, Vector3 offset = new Vector3(), Action DoneAnimating = null)
    {
        PositionAnimator animationScript = Camera.main.GetComponent<PositionAnimator>();
        animationScript.Animate(trans, time, offset, DoneAnimating);
    }
}