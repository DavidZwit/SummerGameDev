using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Scroller : MonoBehaviour {

	private Scrollbar _scrollBar;
	[SerializeField] private float _multiplier;
	[SerializeField] private GameObject _playerMovement;
	void Start()
	{

		_scrollBar = GetComponent<Scrollbar> ();

	}
	public void Pressed()
	{
		ChangeZ<IMoveable> (_playerMovement, x => x.ChangeMyZ (_scrollBar.value, _multiplier));
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
