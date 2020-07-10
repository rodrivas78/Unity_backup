using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEFT_controller : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	float verticalMove;
	float horizontalMove;
	bool forceSelection;
	public int cameraButtonOn; 
	public FollowingPlayer referenceFloat;

	void Start () {
		rb = GetComponent<Rigidbody>();
		referenceFloat = GameObject.FindWithTag("MainCamera").GetComponent<FollowingPlayer>();
	}

	public void OnPress(){

		if (cameraButtonOn == 0) {
		speed = 2.0f;
		horizontalMove = -2.0f;
		Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove);
		rb.AddForce (movement * speed);
		forceSelection = true; //Mantém a aceleração dentro do loop
		}else {
			referenceFloat.horizontalFloat = -0.5f; //Entra com a intensidade giro da camera em Following Player
			//enquanto não efetua acelerações na esfera
		}
	}

	public void OnRelease(){

		speed = 0;
		horizontalMove = 0.0f;
		Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove);
		rb.AddForce (movement * speed);
		forceSelection = false;
		referenceFloat.horizontalFloat = 0.0f; 
	}

	public void AddForce_LEFT()
	{		
		horizontalMove = -8.0f;
		Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove);
		rb.AddForce (movement * speed);
	}

	void FixedUpdate () {

		if (forceSelection) {					
			AddForce_LEFT();
		}

	}
}
