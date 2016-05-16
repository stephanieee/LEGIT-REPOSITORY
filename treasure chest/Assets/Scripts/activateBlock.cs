using UnityEngine;
using System.Collections;

public class activateBlock : MonoBehaviour {
	public Transform target;
	public float speed;
	public Transform shadow;
	public Transform shadowTarget;
	public Transform block;
	public bool enabled = false;
	public bool isPlayerInTrigger = false;

	void Start () {
		shadow.GetComponent<Renderer>().enabled = false;
	}



	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			isPlayerInTrigger = true;
			shadow.GetComponent<Renderer> ().enabled = true;
		}
		if (isPlayerInTrigger == true) {
				Debug.Log ("i'm in the trigger whatever");

		}
	}


	void FixedUpdate (){
		if (Input.GetMouseButtonDown (0) && isPlayerInTrigger == true) {
			float step = speed * Time.deltaTime;
			while (Vector3.Distance (block.position, target.position) > 0.05) {
				block.position = Vector3.MoveTowards (block.position, target.position, step);
				shadow.position = Vector3.MoveTowards (shadow.position, shadowTarget.position, step);
			}
			}

		}


}