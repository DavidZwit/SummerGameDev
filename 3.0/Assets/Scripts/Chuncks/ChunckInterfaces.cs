using UnityEngine;
using System.Collections;

public interface IChunck
{
    bool Spawn(float yPos, float unitysPerSecond);
    IEnumerator Move();
    void ChangeSpeed(float unitsPerSecond);
    bool CanHit(int left, int right);
}