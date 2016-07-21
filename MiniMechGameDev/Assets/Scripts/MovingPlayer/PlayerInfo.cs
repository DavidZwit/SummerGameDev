using UnityEngine;
using System.Collections;


public interface IRemember
{
	void UpdateMyValue (float Value);
}

public class PlayerInfo : Singleton<PlayerInfo>, IRemember {
	
	[SerializeField] private bool AmILeft = false;
    public bool Left
    {
        get
        {
            return AmILeft;
        }
    }

	public void UpdateMyValue(float Value)
	{
		if (AmILeft) {
			NonDestroyableData.playerOneValue = Value;

		} else {
			NonDestroyableData.playerTwoValue = Value;


		}
	}
}
