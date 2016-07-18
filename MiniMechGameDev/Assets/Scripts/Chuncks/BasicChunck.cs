using UnityEngine;
using System.Collections;

public class BasicChunck : MonoBehaviour, IChunck { 
    float moveSpeed = 0;
    bool active;

    void Start()
    {
        Active = false;
        StartCoroutine("Move");
    }

    public void Spawn(float yPos, float unitsPerSecond)
    {
        gameObject.transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        moveSpeed = unitsPerSecond;
        Active = true;
    }

    WaitForSeconds returnSeconds = new WaitForSeconds(0.1f);

    public IEnumerator Move()
    {
        while (true)
        { 
            if (active)
            {
                transform.Translate(0, 0, -moveSpeed);
            }
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
            transform.position = new Vector3(value ? 0 : 500, 0, 0);
            active = value;   
        }
    }
}
