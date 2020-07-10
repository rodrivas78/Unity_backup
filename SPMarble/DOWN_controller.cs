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

	void Start () {
		rb = GetComponent<Rigidbody>();
		referenceFloat = GameObject.FindWithTag("MainCamera").GetComponent<FollowingPlayer>();
		//cameraButtonOn = 0;
	}

	public void OnPress(){

		if (cameraButtonOn == 0) {
			speed = 2.0f;
			verticalMove = -2.0f;
			Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove);
			rb.AddForce (movement * speed);
			forceSelection = true; //Mantém a aceleração dentro do loop

		} else {
			referenceFloat.verticalFloat = -0.5f; //Entra com a intensidade do giro da camera em Following Player
			//enquanto não efetua acelerações na esfera
		}
	}

	public void OnRelease(){

		speed = 0;
		verticalMove = 0.0f;
		Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove);
		rb.AddForce (movement * speed);
		forceSelection = false;
		referenceFloat.verticalFloat = 0.0f;
	}

	public void AddForce_DOWN()
	{		
		verticalMove = -8.0f;
		Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove);
		rb.AddForce (movement * speed);
	}

	void FixedUpdate () {

		if (forceSelection) {					
			AddForce_DOWN();
		}

	}
}
