﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TowerLevel {
  public int cost;
  public GameObject visualization;
  public GameObject bullet;
  public float fireRate;
}

public class TowerData : MonoBehaviour {

	public List<TowerLevel> levels;
	private TowerLevel currentLevel;
	
	//1
	public TowerLevel CurrentLevel {
		//2
		get {
			return currentLevel;
		}
		//3
		set {
			currentLevel = value;
			int currentLevelIndex = levels.IndexOf(currentLevel);
			
			GameObject levelVisualization = levels[currentLevelIndex].visualization;
			for (int i = 0; i < levels.Count; i++) {
				if (levelVisualization != null) {
					if (i == currentLevelIndex) {
						levels[i].visualization.SetActive(true);
					} else {
						levels[i].visualization.SetActive(false);
					}
				}
			}
		}
	}

	void OnEnable() {
 		CurrentLevel = levels[0];
	}

	public TowerLevel getNextLevel() {
		int currentLevelIndex = levels.IndexOf (currentLevel);
		int maxLevelIndex = levels.Count - 1;
		if (currentLevelIndex < maxLevelIndex) {
			return levels[currentLevelIndex+1];
		} else {
			return null;
		}
	}
	
	public void increaseLevel() {
		int currentLevelIndex = levels.IndexOf(currentLevel);
		if (currentLevelIndex < levels.Count - 1) {
			CurrentLevel = levels[currentLevelIndex + 1];
		}
	}

	public bool upgradable()
	{
		int currentLevelIndex = levels.IndexOf (currentLevel);
		int maxLevelIndex = levels.Count - 1;
		if (currentLevelIndex < maxLevelIndex) {
			return true;
		} else {
			return false;
		}
	}
}
