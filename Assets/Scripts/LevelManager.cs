using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel(string name){
		Debug.Log ("Level load requested for: " + name);
		Brick.brickCount = 0;
		Application.LoadLevel(name);
	}
	
	public void quitLevel() {
		Debug.Log ("Quit function requested");
		Application.Quit();
	}
	
	public void LoadNextLevel() {
		Brick.brickCount = 0;
		Application.LoadLevel(Application.loadedLevel+1);
	}
	
	public void BrickDestroyed () {
		if (Brick.brickCount <= 0) {
			print ("Called for next level");
			LoadNextLevel();
		}
	}
}
