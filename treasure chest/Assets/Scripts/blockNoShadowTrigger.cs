using UnityEngine;
using System.Collections;

public class blockNoShadowTrigger : MonoBehaviour {
	public Transform target;
	public float speed;
	public Transform block;
	public LayerMask layerMask;
	public bool isPlayerInTrigger = false;
	public bool enabled = false;
	public Transform longShadow;
	public Transform longShadowTarget;

	void Start () {
		longShadow.GetComponent<Renderer>().enabled = false;
	}

	void OnTriggerStay(Collider other){
		isPlayerInTrigger = true;

		if (Input.GetMouseButtonDown(0) && isPlayerInTrigger == true) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo = new RaycastHit ();
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo)) 
				Debug.Log ("Object hit is: " + hitInfo.collider.gameObject.name);
			if (Physics.Raycast(ray, out hitInfo, 100, layerMask)){
				Debug.Log ("hit layer mask");
				StartCoroutine (moveTowardsPositionCoroutine ());

	}
}

}
	//block being raised
	IEnumerator moveTowardsPositionCoroutine () {
	float step = speed * Time.deltaTime;
	while (Vector3.Distance (block.position, target.position) > 0.05) {
	block.position = Vector3.MoveTowards (block.position, target.position, step);
	yield return null;
		}
	}

	//this is the transform for the shadow. when player enters west trigger, clicks block and shadow casts 

//	void OnTriggerEnter (Collider other) {
//		Debug.Log ("collision detected:" + GetComponent<Collider>().gameObject.name);
//		if (gameObject.name == "west trigger") {
//			Debug.Log ("what");
////			if (Input.GetMouseButtonDown (0) && isPlayerInTrigger == true) {
////				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
////				RaycastHit hitInfo = new RaycastHit ();
////				if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo))
////				if (Physics.Raycast(ray, out hitInfo, 100, layerMask)){	
////				Debug.Log ("clicked long shadow");
////					StartCoroutine (shadowStretch ());
////				}
////			}
////		}
//	}
//
//	}
//	IEnumerator shadowStretch () {
//		longShadow.GetComponent<Renderer>().enabled = true;
//		float step = speed * Time.deltaTime;
//		while (Vector3.Distance (block.position, target.position) > 0.05) {
//			longShadow.position = Vector3.MoveTowards (longShadow.position, longShadowTarget.position, step);
//			yield return null;
//	}
//
//}
}