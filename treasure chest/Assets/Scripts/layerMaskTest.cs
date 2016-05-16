using UnityEngine;
using System.Collections;

public class layerMaskTest : MonoBehaviour {
	public LayerMask layerMask;
	public Transform target;
	public Transform block;
	public bool isPlayerInTrigger = false;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay (Collider other) {
		isPlayerInTrigger = true;
		if (Input.GetMouseButtonDown(0) && isPlayerInTrigger == true) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo = new RaycastHit ();
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo)) 
				Debug.Log ("whatever");
			if (Physics.Raycast(ray, out hitInfo, 100, layerMask)){
				Debug.Log ("Object hit is: " + hitInfo.collider.gameObject.name);
				StartCoroutine (moveTowardsPositionCoroutine ());
			}

		}
	}

	IEnumerator moveTowardsPositionCoroutine(){
		float step = speed * Time.deltaTime;
		while (Vector3.Distance (block.position, target.position) > 0.05) {
				block.position = Vector3.MoveTowards (block.position, target.position, step);
				yield return null;

			}
		}





}
