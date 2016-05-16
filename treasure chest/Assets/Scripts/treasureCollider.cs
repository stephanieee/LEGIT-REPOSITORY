using UnityEngine;
using System.Collections;

public class treasureCollider : MonoBehaviour {


	void Start () {

	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.gameObject.tag == "Player") {
			Debug.Log ("entered trigger");
			StartCoroutine (ResetScene ());
		}

	}

	IEnumerator ResetScene() {
		Debug.Log ("Hi!, I'm supposed to reset the scene");
		Application.LoadLevel (Application.loadedLevel);
		yield return null;
	}


}


