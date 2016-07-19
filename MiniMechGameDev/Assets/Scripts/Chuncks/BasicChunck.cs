using UnityEngine;
using System.Collections;


public class BasicChunck : MonoBehaviour, IChunck { 
    float moveSpeed = 0;
    bool active;

    [System.Serializable]
    class bools { public bool[] canHit = new bool[4]; }
    [SerializeField]
    bools[] HitPosibilities = new bools[4];


    void Start()
    {
        Active = false;
        StartCoroutine(Move());
    }

    public bool Spawn(float yPos, float unitsPerSecond)
    {
        //if (!)
        gameObject.transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        moveSpeed = unitsPerSecond;
        Active = true;
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
        get { return active; }
        set {
            active = value;        
            transform.position = new Vector3(value ? 0 : 500, 0, 0);
            if (value) StartCoroutine(Move());
        }
    }

    public bool CanHit(int left, int right)
    {
        if (HitPosibilities[left -1].canHit[right -1])
            return true;
        else return false;
    }
}
