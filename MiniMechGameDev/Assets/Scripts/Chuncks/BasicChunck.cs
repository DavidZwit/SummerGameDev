using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class PosAndRot
{
    public Quaternion rot;
    public Vector3 pos;
    public Transform currTrans;

    public PosAndRot(Transform _currTrans, Vector3 _pos, Quaternion _rot) {
        pos = _pos;
        rot = _rot;
        currTrans = _currTrans;
    }
}


public class BasicChunck : MonoBehaviour, IChunck { 
    [SerializeField]
    float moveSpeed = 20;

    List<PosAndRot> startPositions;
    
    [System.Serializable]
    class bools { public bool[] canHit = new bool[4]; }
    [SerializeField]
    bools[] HitPosibilities = new bools[4];


    void Awake()
    {
        StartCoroutine(Move());
        startPositions = new List<PosAndRot>();
        print(startPositions);

        Transform[] childTransforms = GetComponentsInChildren<Transform>();

        foreach (Transform trans in childTransforms)
        {
            if(trans.tag == "Dummie")
            {
                startPositions.Add(new PosAndRot(trans, trans.localPosition, trans.localRotation));
            }
        }
    }

    public bool Spawn(float zPos, float unitsPerSecond)
    {
        //if (!)

        transform.position = new Vector3(0, 0, zPos);
        moveSpeed = unitsPerSecond;

        for (int i = 0; i < startPositions.Count; i++)
        {
            PosAndRot curr = startPositions[i];
            curr.currTrans.GetComponent<Rigidbody>().isKinematic = true;
            curr.currTrans.localPosition = curr.pos;
            curr.currTrans.localRotation = curr.rot;
        }

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
