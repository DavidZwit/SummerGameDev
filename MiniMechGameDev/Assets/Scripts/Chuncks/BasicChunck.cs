using UnityEngine;
using System.Collections;


public class BasicChunck : MonoBehaviour, IChunck { 
    float moveSpeed = 0;
    bool active = false;

    [System.Serializable]
    class bools { public bool[] canHit = new bool[4]; }
    [SerializeField]
    bools[] HitPosibilities = new bools[4];

    IEnumerator move;

    void Start()
    {
        move = Move();
        //  Active = false;
        //StartCoroutine(Move());
    }

    public bool Spawn(float zPos, float unitsPerSecond)
    {
        //if (!)
        Active = true;
        transform.position = new Vector3(0, 0, zPos);
        moveSpeed = unitsPerSecond;
        return true;
    }

    WaitForSeconds returnSeconds = new WaitForSeconds(0.01f);

    public IEnumerator Move()
    {
        while (active)
        {
            transform.Translate(0, 0, -moveSpeed / 100);
            yield return returnSeconds;
        }

    }

    public void Delete()
    {
        Active = false;
    }

    public void ChangeSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    bool Active
    {
        get {
            return active; }
        set {
            bool oldActive = active;
            active = value;
            transform.position = new Vector3(0, 0, transform.position.z);
            if (value && !oldActive) StartCoroutine(Move());
        }
    }

    public bool CanHit(int left, int right)
    {
        if (HitPosibilities[left - 1].canHit[right - 1])
            return true;
        else return false;
    }
}
