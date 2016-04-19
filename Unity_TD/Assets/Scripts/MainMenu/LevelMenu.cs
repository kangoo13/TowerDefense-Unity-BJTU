﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using System.CodeDom;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelMenu : MonoBehaviour {

	private LevelSelection instantiatedLevel = null;
	private int x = 100;
	private int y = -60;
	public GameObject obj;
	public LevelSelection InstantiatedLevel {
		get {
			return instantiatedLevel;
		}
		set {
			instantiatedLevel = value;
		}
	}

	[SerializableAttribute]
	public class Action {
		public String title;
		public String levelName;
		public String sceneName;
	}

	public Action[] actions;

	void Start() {
		int i = 0;

		foreach (Action action in actions) {
			
			GameObject objLevel = Instantiate (obj) as GameObject;
			objLevel.transform.SetParent (this.transform, false);

			RectTransform	rt = objLevel.GetComponent<RectTransform> ();

			Level lvl = objLevel.GetComponent <Level> ();
			lvl.title = action.title;
			lvl.levelName = action.levelName;
			lvl.sceneName = action.sceneName;

			lvl.UpdateText();

			if (i % 2 == 0) {
				rt.localPosition = new Vector3 (x + (x * i), y, 0f);
			} else {
				rt.anchorMin = new Vector2 (0, 0);
				rt.anchorMax = new Vector2 (0, 0);
				rt.pivot = new Vector2 (0, 0);
				rt.localPosition = new Vector3 ((x * i), y * -1, 0f);
			}
			i++;
		}
		/*		int i = 0;
		foreach (GameObject level in levelObject) {
			GameObject objLevel = Instantiate (level) as GameObject;
			objLevel.transform.SetParent (this.transform, false);

			RectTransform	rt = objLevel.GetComponent<RectTransform> ();

			if (i % 2 == 0) {
				rt.localPosition = new Vector3 (x + (x * i), y, 0f);
			} else {
				rt.anchorMin = new Vector2 (0, 0);
				rt.anchorMax = new Vector2 (0, 0);
				rt.pivot = new Vector2 (0, 0);
				rt.localPosition = new Vector3 ((x * i), y * -1, 0f);
			}
			i++;
		}*/
	}
}
