﻿//using UnityEngine;
//using System.Collections;
//
//public class ClickToMove : MonoBehaviour {
//	private Transform myTransform; // current location of object
//	private Vector3 hitPoint; // target destination
//	private float destinationDistance; // distance between myTransform and hitPoint
//	public float moveSpeed; // speed character will move
////	public float moveAnimSpeed; // float trigger for float created in mecanim
////	public float animSpeed = 1.5f; // animation speed
////	public Animator anim; // animator to anim converter
////	public int idleState = Animator.StringToHash("Base Layer.Idle"); // string to hash conversion for mecanim 'base layer'
////	public int runState = Animator.StringToHash("Base Layer.Run"); // string to hash for mecanim 'base layer run'
////	private AnimatorStateInfo currentBaseState; // ref to current state of the animator
////	private Collider col;
//
//
//	// Use this for initialization
//	void Start () {
////		Physics.gravity = new Vector3 (0, -200f, 0); // uesd in conjunction w/ rigidbody for better gravity)
////		anim = GetComponent<Animator>();
////		idleState = Animator.StringToHash("Idle"); 
////		runState = Animator.StringToHash ("Run");
//		myTransform = transform; //sets myTransform to this GameObject.transform
//		hitPoint = myTransform.position; //prevents myTransform reset
//	}
//
//	// Update is called once per frame
//	void Update () {
//
////		currentBaseState = anim.GetCurrentAnimatorStateInfo (0);
//
//		destinationDistance = Vector3.Distance (hitPoint, myTransform.position); //tracks distance btwn this gameObject + hitPoint
//
//		if (destinationDistance < .5f) { //prevents shaking behaviour when near destination
//			moveSpeed = 0;
//		} else if (destinationDistance > .5f) { // resets speed to default
//			moveSpeed = 3;
//		}
//
//		// below sends floats to mecanim, raycast sets speed to X until destination is reached, animation plays until speed drops
////		if (animSpeed > .5f) {
////			anim.SetFloat ("moveAnimSpeed", 2.0f);
////		} else if (animSpeed < .5f) {
////			anim.SetFloat ("moveAnimSpeed", 0.0f);
////		}
//
//
//		// moves player if left mouse button is clicked
//		if (Input.GetMouseButtonDown (0) && GUIUtility.hotControl ==0){
//			Debug.Log ("i did the left click");
//			Plane playerPlane = new Plane (Vector3.up, myTransform.position);
//			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//			float hitdist = 5.0f;
//		
//
//			if (playerPlane.Raycast(ray, out hitdist)) {
//				Vector3 targetPoint = ray.GetPoint(hitdist); 
//				hitPoint = ray.GetPoint(hitdist); 
//				Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
//				myTransform.rotation = targetRotation;
//			}
//			//			prevents code from running if not needed
//		}
//
//
//		//****THIS HAPPENS OUTSIDE OF THE IF STATEMENT THAT CHECKS FOR THE MOUSE CLICK***
//		if (destinationDistance > .5f) {
//			myTransform.position = Vector3.MoveTowards (myTransform.position, hitPoint, moveSpeed * Time.deltaTime);
//		}
//
//	
//
//	}
//
//}