﻿using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

	/// <summary>
	/// The velocity vector holds the player's movement speed.
	/// This gets multiplied by the direction to get actual movement.
	/// </summary>
	public float velocity = 10;
	public GameObject Weapon;
	/// <summary>
	/// The movement vector is given to the rigidbody physics to move the object
	/// </summary>
	private Vector3 movement;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);

		//Debug.Log ((Quaternion.Euler (0, 0, -45) * (velocity * direction)).ToString ());
		movement = Quaternion.Euler (0, 0, -45) * (velocity * direction);
	
		if(Input.GetMouseButtonDown (0)){
			GameObject.Destroy (GameObject.Find ("Weapon(Clone)"));
			Vector3 swingDir = new Vector3(transform.position.x,transform.position.y, 0);
			Quaternion swingRot = new Quaternion(0,0,0,0);
			if(Input.mousePosition.x > Screen.width/2 && Input.mousePosition.y < Screen.height/2 - 16)
				swingDir.y = transform.position.y - 0.70F;
			else if(Input.mousePosition.x < Screen.width/2 - 16 && Input.mousePosition.y < Screen.height/2 - 16)
				swingDir.x = transform.position.x - 0.70F;
			else if(Input.mousePosition.x < Screen.width/2 - 16 && Input.mousePosition.y > Screen.height/2 + 16)
				swingDir.y = transform.position.y + 0.70F;
			else if(Input.mousePosition.x > Screen.width/2 + 16 && Input.mousePosition.y > Screen.width/2 + 16)
				swingDir.x = transform.position.x + 0.70F;
			else if(Input.mousePosition.x > Screen.width/2 + 16){
				swingDir.x = transform.position.x + 0.55F;
				swingDir.y = transform.position.y - 0.55F;
			}
			else if(Input.mousePosition.x < Screen.width/2 - 16){
				swingDir.x = transform.position.x - 0.55F;
				swingDir.y = transform.position.y + 0.55F;
			}
			else if(Input.mousePosition.y > Screen.height/2 + 16){
				swingDir.x = transform.position.x + 0.55F;
				swingDir.y = transform.position.y + 0.55F;
			}
			else if(Input.mousePosition.y < Screen.height/2 - 16){
				swingDir.x = transform.position.x - 0.55F;
				swingDir.y = transform.position.y - 0.55F;
			}
			
			/*if(Input.mousePosition.x > Screen.width/2 + 16)
				swingDir.x  = transform.position.x + 0.55F;
			else if(Input.mousePosition.x < Screen.width/2 - 16)
				swingDir.x = transform.position.x - 0.55F;
			if(Input.mousePosition.y > Screen.height/2 + 16)
				swingDir.y  = transform.position.y + 0.55F;
			else if(Input.mousePosition.y < Screen.height/2 - 16)
				swingDir.y = transform.position.y - 0.55F;*/
			//Debug?
			Debug.Log ((Screen.width/2).ToString () + ", " + (Screen.height/2).ToString () + 
			           ", " + Input.mousePosition.x.ToString () + ", " + Input.mousePosition.y.ToString()
			           + ", " + (swingDir.x - transform.position.x).ToString() + ", " + 
			           (swingDir.y - transform.position.y).ToString ());
			swingRot = Quaternion.LookRotation (swingDir - transform.position);
			swingRot.z = swingRot.w = 0;
			if(swingDir.x == transform.position.x){
				swingRot.y = swingRot.x;
			}
			if(swingDir.x != transform.position.x || swingDir.y != transform.position.y){
				
				//we need account for the isometric rotation
				GameObject swingInstance = Instantiate (Weapon,swingDir, swingRot) as GameObject;
			}
		}
	}

	//FixedUpdate is called once per tick and should be used for physics
	void FixedUpdate(){
		transform.position += movement;
	}
}
