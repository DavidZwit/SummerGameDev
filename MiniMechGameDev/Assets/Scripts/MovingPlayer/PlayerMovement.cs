using UnityEngine;
using System.Collections;

public interface IMoveable
{
	void ChangeMyZ (float value, float multiplier);
	void ChangeMyZSmooth (float Value, float Multiplier);
}

public class PlayerMovement : MonoBehaviour, IMoveable {

	private Vector3 _newPos;
	private float _startZ;

	void Start()
	{
		_newPos = transform.position;
		_startZ = _newPos.z;
	}
	public void ChangeMyZ(float value, float multiplier)
	{
		_newPos.z = _startZ + (value * multiplier);
		transform.position = _newPos;
	}
	public void ChangeMyZSmooth(float value, float multiplier)
	{
		_newPos.z = _startZ + (value * multiplier);
		StartCoroutine (SmoothMove (0.01f));
	}

	IEnumerator SmoothMove(float repeatingTime)
	{
		while (transform.position != _newPos) {
			//transform.position = Vector3.Lerp (transform.position, _newPos, 0.02f);
			transform.position = Vector3.MoveTowards(transform.position, _newPos, 0.3f);

			yield return  new WaitForSeconds (repeatingTime);
		}


	}
}
