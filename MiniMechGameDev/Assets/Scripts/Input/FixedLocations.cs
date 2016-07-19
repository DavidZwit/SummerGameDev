using UnityEngine;
using System.Collections;
using System;

public class FixedLocations : MonoBehaviour {

	[SerializeField] private int _location;
	[SerializeField] private GameObject _player;
	private float _multiplier = 5f;

	public void Pressed()
	{
		ChangeZ<IMoveable> (_player, x => x.ChangeMyZSmooth (_location, _multiplier));
	}

	void ChangeZ<T>(GameObject target, Action<T> move)
	{
		T[] components = target.GetComponents<T> ();
		foreach (T component in components) 
		{
			move (component);
			Debug.Log ("clicked");
		}
	}
}
