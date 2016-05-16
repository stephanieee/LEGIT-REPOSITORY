using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

	static public GameStateManager s_Singleton;

	#region VARIABLE DECLARATIONS
	public bool isInAIVision = false;
	public bool isUnderShadow = false;
	public int currentBlockID;
	public Collider treasureChest;
	public GameObject treasure;

	#endregion

	// Use this for initialization
	void Start () {
		s_Singleton = this;
		InvokeRepeating("HasPlayerBeenSeen", 0.1f, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	#region GAME LOGIC METHODS
	//This checks if the player is not hidden and in line of sight of the AI. It will reset the scene if it is. 
	public void HasPlayerBeenSeen () {
		if (isInAIVision == true && isUnderShadow == false) {
			//RESET THE SCENE BELOW!
			ResetScene();
		}
	}

	public void ResetScene(){
		Debug.Log ("Hi!, I'm supposed to reset the scene");
		Application.LoadLevel (Application.loadedLevel);
	}




	#endregion
}
