using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {
public Animator anim;
public bool playerIsInRange = false;


	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "enemy"){
			playerIsInRange = true;
			Debug.Log("Object can be interacted with!");
			if(Input.GetMouseButtonDown (0))
				GetComponent<Animation>().Play("Attack");
		}
	}
	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "enemy"){
			playerIsInRange = false;
			Debug.Log("No Interaction");
		}
	}
}
