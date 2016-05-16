using UnityEngine;
using System.Collections;

public class longShadowTrigger : MonoBehaviour {
	public Transform longShadow;
	public Transform longShadowTarget;
	public LayerMask layerMask;
	public bool isPlayerInTrigger = false;
	public float speed;


	void Start () {
		longShadow.GetComponent<Renderer>().enabled = false;
	}

	//trigger that extends long shadow on left click
	void OnTriggerEnter (Collider other) {
		isPlayerInTrigger = true;
		Debug.Log ("collision detected:" + GetComponent<Collider>().gameObject.name);
		if (Input.GetMouseButtonDown(0) && isPlayerInTrigger == true) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo = new RaycastHit ();
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo))
			if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask)){
				Debug.Log ("Object hit is: " + hitInfo.collider.gameObject.name);
				StartCoroutine (shadowStretch ());
			}

		}
		}

	//transform of long shadow
	IEnumerator shadowStretch () {
		longShadow.GetComponent<Renderer>().enabled = true;
		float step = speed * Time.deltaTime;
		while (Vector3.Distance (longShadow.position, longShadowTarget.position) > 0.05) {
			longShadow.position = Vector3.MoveTowards (longShadow.position, longShadowTarget.position, step);
			yield return null;
//		}

	}
}
}
