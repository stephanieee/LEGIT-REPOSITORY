using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	private Transform myTransform; // current location of object
	private Vector3 hitPoint; // target destination
	private float destinationDistance; // distance between myTransform and hitPoint
	public float moveSpeed; // speed character will move
	public Transform enemy; // enemy 
	public int rotationSpeed; // rotation of enemy
	public int layerMask;

	private Animator anim;


		public float Speed; // float trigger for float created in mecanim
//		public float animSpeed =0.1f; // animation speed
//		public int idleState = Animator.StringToHash("Base Layer.Idle"); // string to hash conversion for mecanim 'base layer'
//		public int runState = Animator.StringToHash("Base Layer.Move"); // string to hash for mecanim 'base layer run'
	int idleState = Animator.StringToHash("Base Layer.Idle"); 
	int runState = Animator.StringToHash ("Base Layer.Move");
	private AnimatorStateInfo currentBaseState; // ref to current state of the animator
		private Collider col;

	// Use this for initialization
	void Start () {
				Physics.gravity = new Vector3 (0, -200f, 0); // uesd in conjunction w/ rigidbody for better gravity)
				anim = GetComponent<Animator>();
			
		myTransform = transform; //sets myTransform to this GameObject.transform
		hitPoint = myTransform.position; //prevents myTransform reset

	}

		// Update is called once per frame
	void FixedUpdate () {

		destinationDistance = Vector3.Distance (hitPoint, myTransform.position); //tracks distance btwn this gameObject + hitPoint

		if (destinationDistance < .5f) { //prevents shaking behaviour when near destination
			moveSpeed = 0;
		} else if (destinationDistance > .5f) { // resets speed to default
			moveSpeed = 3;
		}

//		// below sends floats to mecanim, raycast sets speed to X until destination is reached, animation plays until speed drops
//		float animSpeed = 0.1f;
//		if (animSpeed > .1f) {
//			anim.SetFloat ("Speed", 0.1f);
//		} else if (animSpeed < .1f) {
//			anim.SetFloat ("Idle", 0f);
//		}

		if (anim){
			currentBaseState = anim.GetCurrentAnimatorStateInfo (0);
			{
				if (currentBaseState.nameHash == Animator.StringToHash ("Base Layer.Idle")) {
					if (Input.GetMouseButtonDown (0))
						anim.SetFloat ("Move", Speed);
				}
			}
		}

		
		// moves player if left mouse button is clicked
		if (Input.GetMouseButtonDown (0) && GUIUtility.hotControl ==0){
			Plane playerPlane = new Plane (Vector3.up, myTransform.position);
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float hitdist = 5.0f;
			Debug.Log ("walk walk walk");


			if (playerPlane.Raycast(ray, out hitdist)) {
				Vector3 targetPoint = ray.GetPoint(hitdist); 
				hitPoint = ray.GetPoint(hitdist); 
				Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				myTransform.rotation = targetRotation;
			}
			//			prevents code from running if not needed
		}


		else if(Input.GetMouseButtonUp (0) && GUIUtility.hotControl ==0){
		//idle waiting animation supposed to fucking play here	
			Debug.Log ("wait wait wait");
		}



		//****THIS HAPPENS OUTSIDE OF THE IF STATEMENT THAT CHECKS FOR THE MOUSE CLICK***
		if (destinationDistance > .5f) {
			myTransform.position = Vector3.MoveTowards (myTransform.position, hitPoint, moveSpeed * Time.deltaTime);
		}



	}


//----------------------------------------------------------------------------

	//attack enemy with this crap
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Enemy") {
		if (Input.GetMouseButtonDown (0)) {
				RaycastHit hitInfo = new RaycastHit ();
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo))
			if (Physics.Raycast (ray, out hitInfo, 100, layerMask)){
			if (hitInfo.collider.gameObject.tag == "Enemy");
				StartCoroutine (attackEnemy ());
			}
		}

	}
	}

	IEnumerator attackEnemy(){

			myTransform.LookAt (enemy.position);
			myTransform.rotation =  Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(enemy.position - myTransform.position), rotationSpeed * Time.deltaTime);			
			Debug.Log ("LOOOOOOOOOOOOOOking");
		anim.SetBool ("Attack", true);
		Debug.Log ("player attack attack attack");
		yield return null;
	}


}
