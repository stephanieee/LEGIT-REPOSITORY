using UnityEngine;
using System.Collections;

public class longBlockTrigger : MonoBehaviour {
	public Transform target;
	public float speed;
	public Transform shadowSouth;
	public Transform shadowTargetSouth;
	public Transform block;
	public bool enabled = false;


	void Start () {
		shadowSouth.GetComponent<Renderer>().enabled = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			shadowSouth.GetComponent<Renderer> ().enabled = true;
		}
	}


	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Player"){
			Debug.Log("Object can be interacted with!");
			if (Input.GetMouseButtonDown (0)) 
			{
				StartCoroutine (moveTowardsPositionCoroutine ());
			}


		}
	}
	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			Debug.Log("No Interaction");
		}


	}

	IEnumerator moveTowardsPositionCoroutine(){
		float step = speed * Time.deltaTime;
		while (Vector3.Distance (block.position, target.position) > 0.05) {
			block.position = Vector3.MoveTowards (block.position, target.position, step);
			shadowSouth.position = Vector3.MoveTowards (shadowSouth.position, shadowTargetSouth.position, step);
			yield return null;

		}


	}
}
