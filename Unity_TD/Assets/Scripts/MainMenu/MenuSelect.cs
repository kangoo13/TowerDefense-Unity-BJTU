﻿using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SelectLevel(string level){
		GameManager.Instance.LoadLevel (level);
	}
}

