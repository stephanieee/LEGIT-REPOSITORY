using UnityEngine;
using System.Collections;

public class ShadowTrigger : MonoBehaviour {


	void Update (){
	}

	//this script attaches to a shadow object
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			GameStateManager.s_Singleton.isUnderShadow = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "Player") {
			GameStateManager.s_Singleton.isUnderShadow = false;
		}
	}
}
