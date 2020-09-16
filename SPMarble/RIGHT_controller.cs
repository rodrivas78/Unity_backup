using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIGHT_controller : MonoBehaviour {
	
	private Rigidbody rb;
	public float speed;
	float verticalMove;
	float horizontalMove;
	bool forceSelection;
	public int cameraButtonOn; 
	public FollowingPlayer referenceFloat;
	//*NEW*//  
	public int newDirection;


	void Start () {
		rb = GetComponent<Rigidbody>();
		referenceFloat = GameObject.FindWithTag("MainCamera").GetComponent<FollowingPlayer>();
	}


	public void OnPress(){

		if (cameraButtonOn == 0) {

			speed = 2.0f;
			Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove);
			rb.AddForce (movement * speed);
			forceSelection = true;
	
			switch (newDirection) {
			case 0:  //RIGHT				
				horizontalMove = 2.0f;
				break;
			case 1:  //DOWN
				verticalMove = -2.0f;
				break;
			case 2:  //LEFT
				horizontalMove = -2.0f;
				break;
			case 3:  //UP 
				verticalMove = 2.0f;
				break;

			}


		}else {
			
			referenceFloat.horizontalFloat = 0.5f; //Entra com a intensidade giro da camera em Following Player
			//enquanto não efetua acelerações na esfera
		}
	}

	public void OnRelease(){

		speed = 0;
		horizontalMove = 0.0f;
		verticalMove = 0.0f; //NEW
		Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove);
		rb.AddForce (movement * speed);
		forceSelection = false;
		referenceFloat.horizontalFloat = 0.0f; 
	}

	public void AddForce_RIGHT()
	{		

		Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove);
		rb.AddForce (movement * speed);

		switch (newDirection) {
		case 0:  //RIGHT
			horizontalMove = 8.0f;				
			break;
		case 1:  //DOWN
			verticalMove = -8.0f;
			break;
		case 2:  //LEFT
			horizontalMove = -8.0f;	
			break;
		case 3:  //UP 
			verticalMove = 8.0f;
			break;
	}

	}

	void FixedUpdate () {

		if (forceSelection) {					
			AddForce_RIGHT();
		}

	}
}
