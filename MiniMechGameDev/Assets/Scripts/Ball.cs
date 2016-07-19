﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEditor.VersionControl;

public class Ball : MonoBehaviour {

	bool shootBack = false;
	float shootTime = 2;
	public GameObject PlayerOnePos;
	public GameObject PlayerTwoPos;

	private GameObject _target;
	private bool ShouldIMove = true;

	void Start() {
		StartCoroutine (ShootLoop());
	}

	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, _target.transform.position, 0.2f);

	}
	IEnumerator ShootLoop()
	{
		
		while (true)
		{
			ShouldIMove = true;
			if (shootBack) {
				_target = PlayerOnePos;

				Debug.Log (PlayerOnePos.transform.position);
				shootBack = false;

			} else {
				_target = PlayerTwoPos;
				Debug.Log (PlayerTwoPos.transform.position);
				shootBack = true;
			}
			yield return new WaitForSeconds(2f);
		}
	}
}

