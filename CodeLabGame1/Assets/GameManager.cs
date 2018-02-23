using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int score = 0;

	public int highScore = 0;

	public static GameManager instance = null;

	// Use this for initialization
	void Start () {
		
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else {
			//instance.score = 0;

			Destroy(gameObject); // THERE CAN BE ONLY ONE!
			return;
		}

		string FullFilePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "SaveData.txt";
		if (File.Exists (FullFilePath)) {
			string highScoreString = File.ReadAllText (FullFilePath);
			highScore = int.Parse (highScoreString);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void endGame() {
		// When the score is higher than our previous best, record a new high score.
		if (score > highScore) {
			highScore = score;

			string fullFilePath = Application.dataPath + Path.DirectorySeparatorChar + "SaveData.txt";
			File.WriteAllText (fullFilePath, highScore.ToString ());
		}

		SceneManager.LoadScene("bad");
		GameManager.instance.score = 0;
	}
}
