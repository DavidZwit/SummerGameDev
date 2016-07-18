using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Scroller : MonoBehaviour {

	private Scrollbar _scrollBar;
	private  Vector3 _oldPos; 
	[SerializeField] private GameObject _playerMovement;
	void Start()
	{
		_oldPos = transform.position;
		_scrollBar = GetComponent<Scrollbar> ();

	}
	public void Pressed()
	{
		ChangeZ<IMoveable> (_playerMovement, x => x.ChangeMyZ (_scrollBar.value));
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
