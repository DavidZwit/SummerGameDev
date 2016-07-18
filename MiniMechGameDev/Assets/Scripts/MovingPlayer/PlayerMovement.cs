using UnityEngine;
using System.Collections;

public interface IMoveable
{
	void ChangeMyZ (float value);
}

public class PlayerMovement : MonoBehaviour, IMoveable {

	private Vector3 _newPos;
 	

	void Start()
	{
		_newPos = transform.position;
	}
	public void ChangeMyZ(float value)
	{
		_newPos.z = 20 + (value * 10);
		transform.position = _newPos;
	}
}
