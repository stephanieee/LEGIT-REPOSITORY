using UnityEngine;
using System.Collections;
using Pathfinding;

public class mecanimtestfuckyou : MonoBehaviour {
	private Transform myTransform; // current location of object
	private Vector3 hitPoint; // target destination
	private float destinationDistance; // distance between myTransform and hitPoint
	public float moveSpeed; // speed character will move
	public Transform enemy; // enemy 
	public int rotationSpeed; // rotation of enemy

	private Animator anim;
	//		public float Speed; // float trigger for float created in mecanim
	public float animSpeed; // animation speed
	public int idleState = Animator.StringToHash("Base Layer.Idle"); // string to hash conversion for mecanim 'base layer'
	public int runState = Animator.StringToHash("Base Layer.Walk"); // string to hash for mecanim 'base layer run'
	private AnimatorStateInfo currentBaseState; // ref to current state of the animator
	private Collider col;
	public LayerMask layerMask; //this layer mask is to detect enemy

	// --------------------------------------------------------------------//
	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3 (0, -200f, 0); // uesd in conjunction w/ rigidbody for better gravity)
		anim = GetComponent<Animator>();

		myTransform = transform; //sets myTransform to this GameObject.transform
		hitPoint = myTransform.position; //prevents myTransform reset

	}

	// Update is called once per frame
	void FixedUpdate () {

		currentBaseState = anim.GetCurrentAnimatorStateInfo (0);

		destinationDistance = Vector3.Distance (hitPoint, myTransform.position); //tracks distance btwn this gameObject + hitPoint

		if (destinationDistance < .5f) { //prevents shaking behaviour when near destination
			moveSpeed = 0;
		} else if (destinationDistance > .5f) { // resets speed to default
			moveSpeed = 3;
		}

		//player mecanim for walk + idle
		if (moveSpeed > 0.1f) {
			anim.SetFloat ("walk", animSpeed);
		}
		else {
			anim.SetFloat ("walk", 0.0f);
		}


		// moves player if left mouse button is clicked
		if (Input.GetMouseButtonDown (0) && GUIUtility.hotControl == 0) {
			Plane playerPlane = new Plane (Vector3.up, myTransform.position);
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float hitdist = 0.0f;
			if (playerPlane.Raycast (ray, out hitdist)) {
				Vector3 targetPoint = ray.GetPoint (hitdist); 
				hitPoint = ray.GetPoint (hitdist); 
				Quaternion targetRotation = Quaternion.LookRotation (targetPoint - transform.position);
				myTransform.rotation = targetRotation;

			}
		}
			

		//****THIS HAPPENS OUTSIDE OF THE IF STATEMENT THAT CHECKS FOR THE MOUSE CLICK***
		if (destinationDistance > .5f) {
			myTransform.position = Vector3.MoveTowards (myTransform.position, hitPoint, moveSpeed * Time.deltaTime);
		}

	}

	//----------------------------------------------------------------------------

	//player isn't detecting enemy when clicked
//	void OnTriggerStay(Collider other){
//		if (Input.GetMouseButtonDown (0)) {
//				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//				RaycastHit hitInfo = new RaycastHit ();
//				if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo))
//				Debug.Log ("Object hit is: " + hitInfo.collider.gameObject.name);
//		//this shit below isn't being detected
//				if (Physics.Raycast(ray, out hitInfo, 100, layerMask)){
//				Debug.Log (hitInfo.collider.name);				
//
//		myTransform.LookAt (enemy.position);
//		myTransform.rotation =  Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(enemy.position - myTransform.position), rotationSpeed * Time.deltaTime);			
//		Debug.Log ("LOOOOOOOOOOOOOOking");
//		anim.SetBool ("Attack", true);
//		Debug.Log ("player attack");


//	}


//}

//	}


	
}


