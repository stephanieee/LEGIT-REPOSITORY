using UnityEngine;
using System.Collections;
using Pathfinding;

public class astarTest : MonoBehaviour {

	public Vector3 targetPosition;
	public Path path;
	private Seeker seeker;
	public float speed = 100;
	public float nextWaypointDistance = 3;
	private CharacterController controller;
	private int currentWaypoint = 0;
	private Transform myTransform;


	public void Start () {
		//Get a reference to the Seeker component we added earlier
		Seeker seeker = GetComponent<Seeker>();
		controller = GetComponent<CharacterController> ();
		//Start a new path to the targetPosition, return the result to the OnPathComplete function
		seeker.StartPath (transform.position,targetPosition, OnPathComplete);
	}
	public void OnPathComplete (Path p) {
		Debug.Log ("Yay, we got a path back. Did it have an error? "+p.error);
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}

	public void Update () {
		if (path == null) {
			return;
		}
		if (currentWaypoint >= path.vectorPath.Count) {
			Debug.Log ("end of path reached");
			return;
		}
		Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position).normalized;
		dir *= speed * Time.deltaTime;
		controller.SimpleMove (dir);

//		if (Input.GetMouseButtonDown (0) && GUIUtility.hotControl == 0) {
//			Plane playerPlane = new Plane (Vector3.up, myTransform.position);
//			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//			float hitdist = 0.0f;
//			if (playerPlane.Raycast (ray, out hitdist)) {
//				Vector3 targetPoint = ray.GetPoint (hitdist); 
//				targetPosition = ray.GetPoint (hitdist); 
//				Quaternion targetRotation = Quaternion.LookRotation (targetPoint - transform.position);
//				myTransform.rotation = targetRotation;
//				controller.SimpleMove (targetPoint);
//
//			}
//		}

		if (Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]) < nextWaypointDistance) {
			currentWaypoint++;
			return;
		}

	}
}
