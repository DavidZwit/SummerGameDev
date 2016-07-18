using UnityEngine;
using System.Collections;

interface IChunck
{
    void Spawn(float yPos, float unitysPerSecond);
    void Delete();
    IEnumerator Move();
    void ChangeSpeed(float unitsPerSecond);
}