using UnityEngine;
using System.Collections;

public class followscript : MonoBehaviour {
	NavMeshAgent agent;
	public Transform Player;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (Player.position);
	}
}
