using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class CubeCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.gameObject.name == "player") {
			SceneManager.LoadScene (2);
			GameManager.instance.endGame ();
		}
			
		//GameManager.instance.score++;
	}
}
