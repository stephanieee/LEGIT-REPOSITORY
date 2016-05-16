using UnityEngine;
using System.Collections;

public class InteractibleBlockHandler : MonoBehaviour {
	
	public bool InteractibleToggle = false;

	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			InteractibleToggle = true;
			Debug.Log("Object can be interacted with!");
		}
	}
	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			InteractibleToggle = false;
			Debug.Log("No Interaction");
		}
	}
}
