using UnityEngine;
using System.Collections;

interface IChunck
{
    bool Spawn(float yPos, float unitysPerSecond);
    void Delete();
    IEnumerator Move();
    void ChangeSpeed(float unitsPerSecond);
    bool CanHit(int left, int right);
}