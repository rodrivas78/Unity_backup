using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOWN_controller : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	float verticalMove;
	float horizontalMove;
	bool forceSelection;
	public int cameraButtonOn;  //valor é alterado em OnPress do Collision_Drop_Detect (valor zero ou um) 
	// para ativar ou desativar a aceleração 
	//quando o botão camera está ativado ou desativado
	public FollowingPlayer referenceFloat;
	//*NEW*//  
	public int newDirection;

	void Start () {
		rb = GetComponent<Rigidbody>();
		referenceFloat = GameObject.FindWithTag("MainCamera").GetComponent<FollowingPlayer>();
		//cameraButtonOn = 0;
	}

	public void OnPress(){

		if (cameraButtonOn == 0) {

			speed = 2.0f;
			Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove);
			rb.AddForce (movement * speed);
			forceSelection = true;

			switch (newDirection) {
			case 0:  //D				
				verticalMove = -2.0f;			
				break;
			case 1:  //L
				horizontalMove = -2.0f;
				break;
			case 2:  //U
				verticalMove = 2.0f;
				break;
			case 3:  //R 
				horizontalMove = 2.0f;			
				break;

			}

		} else {
			referenceFloat.verticalFloat = -0.5f; //Entra com a intensidade do giro da camera em Following Player
			//enquanto não efetua acelerações na esfera
		}
	}

	public void OnRelease(){

		speed = 0;
		verticalMove = 0.0f;
		horizontalMove = 0.0f; //NEW
		Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove);
		rb.AddForce (movement * speed);
		forceSelection = false;
		referenceFloat.verticalFloat = 0.0f;
	}

	public void AddForce_DOWN()
	{		

		Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove);
		rb.AddForce (movement * speed);

		switch (newDirection) {
		case 0:  //D
			verticalMove = -8.0f;
			break;
		case 1:  //L
			horizontalMove = -8.0f;		
			break;
		case 2:  //U
			verticalMove = 8.0f;
			break;
		case 3:  //R 
			horizontalMove = 8.0f;		
			break;

		}
	}

	void FixedUpdate () {

		if (forceSelection) {					
			AddForce_DOWN();
		}

	}
}
