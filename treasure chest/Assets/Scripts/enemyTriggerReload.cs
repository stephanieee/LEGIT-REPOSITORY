using UnityEngine;
using System.Collections;

public class enemyTriggerReload : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter (Collider other) {
//		Application.LoadLevel (Application.loadedLevel);
		if (other.gameObject.tag == "Player") {
			GameStateManager.s_Singleton.isInAIVision = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			GameStateManager.s_Singleton.isInAIVision = false;
		}
	}
}
