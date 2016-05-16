using UnityEngine;
using System.Collections;

	public class blockTrigger : MonoBehaviour {
	public Transform target;
	public float speed;
	public Transform shadow;
	public Transform shadowTarget;
	public Transform block;
	public bool enabled = false;
	public LayerMask layerMask;
	public int ID;
	public bool isPlayerInTrigger = false;
//	public bool isTrigger = true;
		

	void Start () {
		shadow.GetComponent<Renderer>().enabled = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			isPlayerInTrigger = true;
			shadow.GetComponent<Renderer> ().enabled = true;
			GameStateManager.s_Singleton.currentBlockID = ID;
			Debug.Log ("ENTER ID:" + ID);
		}
	}
		
	void OnTriggerStay(Collider other){
//		isPlayerInTrigger = true;
		if (Input.GetMouseButtonDown(0) && isPlayerInTrigger == true) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hitInfo = new RaycastHit ();
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo)) 
				Debug.Log ("Object hit is: " + hitInfo.collider.gameObject.name);
			if (Physics.Raycast(ray, out hitInfo, 100, layerMask) && GameStateManager.s_Singleton.currentBlockID == ID){
				Debug.Log ("ID:" + ID);
				StartCoroutine (moveTowardsPositionCoroutine ());

			}
		
		}

	}

	IEnumerator moveTowardsPositionCoroutine(){
		float step = speed * Time.deltaTime;
		while (Vector3.Distance (block.position, target.position) > 0.05) {
			while (Vector3.Distance (shadow.position, shadowTarget.position) > 0.05) {
				block.position = Vector3.MoveTowards (block.position, target.position, step);
				shadow.position = Vector3.MoveTowards (shadow.position, shadowTarget.position, step);
				yield return null;

			}
		}
//		float distCovered = (Time.time - startTime) * speed;
//		float fracJourney = distCovered / journeyLength;
//		block.position = Vector3.Lerp (block.position, target.position, fracJourney);
//		shadow.position = Vector3.Lerp (shadow.position, shadowTarget.position, fracJourney);
//		yield return null;
	
	}

	//destroys treasure collider if shadow has reached position
	void Update() {
		if (Vector3.Distance (shadow.position, shadowTarget.position) < 1) {
			Debug.Log ("shadow reached destination");
			Collider collider = GameStateManager.s_Singleton.treasureChest.GetComponent<Collider> ();
			if (collider != null) {
				Destroy (collider);

			Debug.Log ("destroy collider");

		}
	}

}
}
