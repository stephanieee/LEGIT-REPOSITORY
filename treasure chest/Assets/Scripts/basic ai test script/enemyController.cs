using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {


	public Transform target; //player
	public float moveSpeed; //general move speed?
	public int rotationSpeed;
	public int stop;
	private float destinationDistance; //distance btwn enemy and player
	private Transform myTransform; // position
	public int health = 100; //health points

	public int maxRange;
	public int minRange;

	private Animator anim;
	public float animSpeed; // animation speed
	public int idleState = Animator.StringToHash("Base Layer.Idle"); // string to hash conversion for mecanim 'base layer'
	public int runState = Animator.StringToHash("Base Layer.Walk"); // string to hash for mecanim 'base layer run'
	public int attackState = Animator.StringToHash("Base Layer.Attack");
	private AnimatorStateInfo currentBaseState; // ref to current state of the animator

	void Awake () {
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {

//		this is code for movement
		anim = GetComponent<Animator>();
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		target = go.transform;
	}
		
	// Update is called once per frame
	void FixedUpdate ()
	{

		currentBaseState = anim.GetCurrentAnimatorStateInfo (0);

//		this is code for movement, look at target
		Debug.DrawLine (target.position, transform.position, Color.yellow);

		//look at target
		myTransform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
	
//		Move towards target
		if (Vector3.Distance (target.position, transform.position) < 5 && Vector3.Distance (transform.position, target.position) > 2) {

			transform.position += transform.forward * moveSpeed * Time.deltaTime;
			moveSpeed = 15;
			anim.SetFloat ("walk", animSpeed);
//			Debug.Log ("RUUUUUUUUUUN");
		}
			if (Vector3.Distance (target.position, transform.position) < 4 && Vector3.Distance (transform.position, target.position) > 1) {

				transform.position += transform.forward * moveSpeed * Time.deltaTime;
				moveSpeed = 5;
				anim.SetFloat ("walk", animSpeed);
//				Debug.Log ("walkawalkwalkawalka");

		} else {
			moveSpeed = 0;
			anim.SetFloat ("walk", 0.0f);
//			Debug.Log ("idling idling idling");
		}

		//don't want this to keep updating
		if (Vector3.Distance (target.position, transform.position) < 1) {
			anim.SetBool ("Attack", true);
//			Debug.Log ("attaaaaaaaaaack");
		} 
		if (Vector3.Distance (target.position, transform.position) > 1) {
			anim.SetBool ("Attack", false);
//			Debug.Log ("do not attack idiot");
		}
	}


	//when player enters enemy range.  
	// this animation needs to loop, so when player is idle it will continue attacking. 
	//right now animation plays ONCE and doesn't idle/walk after
//	void OnTriggerStay(Collider other){
//		if (other.gameObject.tag == "Player") {
//			Debug.Log ("entered player trigger what");
//			anim.SetBool ("Attack", true);
//
//		}



	}









