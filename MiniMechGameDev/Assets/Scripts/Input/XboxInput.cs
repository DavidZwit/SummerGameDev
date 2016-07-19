using UnityEngine;
using System.Collections;
using System;

public class XboxInput : MonoBehaviour {

	[SerializeField] private GameObject _playerMovement;
	private float _multiplier = 5f;
	private float _changingValue = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (Input.GetAxis ("XboxVertical") > 0.5f) { 
			if (_changingValue <= 1f) {
				_changingValue += 0.03f;
			}
			ChangeZ<IMoveable> (_playerMovement, x => x.ChangeMyZ (_changingValue, _multiplier));
		}
		else 
		{
			if (_changingValue >= 0f) 
			{
				_changingValue -= 0.04f;
			}	
			ChangeZ<IMoveable> (_playerMovement, x => x.ChangeMyZ (_changingValue,_multiplier));
		}
	}
	void ChangeZ<T>(GameObject target, Action<T> move)
	{
		T[] components = target.GetComponents<T> ();
		foreach (T component in components) 
		{
			move (component);
		}
	}

}
