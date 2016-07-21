using UnityEngine;
using System.Collections;


public class BasicChunck : MonoBehaviour, IChunck { 
    [SerializeField]
    float moveSpeed = 20;

    [System.Serializable]
    class bools { public bool[] canHit = new bool[4]; }
    [SerializeField]
    bools[] HitPosibilities = new bools[4];


    void Start()
    {
        StartCoroutine(Move());
    }

    public bool Spawn(float zPos, float unitsPerSecond)
    {
        //if (!)
        transform.position = new Vector3(0, 0, zPos);
        moveSpeed = unitsPerSecond;
        return true;
    }

    WaitForFixedUpdate returnSeconds = new WaitForFixedUpdate();

    public IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(0, 0, (-moveSpeed * NonDestroyableData.GameSpeed) / 100);
            yield return returnSeconds;
        }

    }

    public void ChangeSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public bool CanHit(int left, int right)
    {
        if (HitPosibilities[left - 1].canHit[right - 1])
            return true;
        else return false;
    }
}
