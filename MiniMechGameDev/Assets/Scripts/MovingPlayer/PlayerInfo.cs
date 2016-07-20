﻿using UnityEngine;
using System.Collections;


public interface IRemember
{
	void UpdateMyValue (float Value);
}
public class PlayerInfo : MonoBehaviour, IRemember {
	
    public bool Left
    {
        get
        {
            return AmILeft;
        }
    }
	[SerializeField] private bool AmILeft = false;

	public void UpdateMyValue(float Value)
	{
		if (AmILeft) {
			NonDestroyableData.playerOneValue = Value;
			Debug.Log ("I changed #1 " +NonDestroyableData.playerOneValue);
		} else {
			NonDestroyableData.playerTwoValue = Value;
			Debug.Log ("I changed #2 " + NonDestroyableData.playerTwoValue);

		}
	}
}
