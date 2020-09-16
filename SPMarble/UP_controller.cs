using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP_controller : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	float verticalMove;
	float horizontalMove;
	bool forceSelection;
	public int cameraButtonOn;  //valor é alterado em OnPress do Collision_Drop_Detect (valor zero ou um) 
	// para ativar ou desativar a aceleração quando o botão camera está ativado ou desativado
	private FollowingPlayer referenceFloat;
	//*NEW*//  
	//Variável de controle de direção da força aplicada, respeitando o novo angulo de visão (dado pelo steering)
	public int newDirection;

	private float fValue; //Teste com variável que pegará valor do GetAxis para um movimento de camera suave


	void Start () {
		rb = GetComponent<Rigidbody>();
		referenceFloat = GameObject.FindWithTag("MainCamera").GetComponent<FollowingPlayer>();
		fValue = 0;
	}

	public void OnPress(){

		if (cameraButtonOn == 0) {
			
			//Debug.Log ("newDirection em UP " + newDirection);		
			speed = 2.0f;
			Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove);
			rb.AddForce (movement * speed);
			forceSelection = true;

			switch (newDirection) {
			case 0:  //UP
				verticalMove = 2.0f;				
				break;
			case 1:  //RIGHT
				horizontalMove = 2.0f;							
				break;
			case 2:  //DOWN
				verticalMove = -2.0f;
				break;
			case 3:  //LEFT
				horizontalMove = -2.0f;			
				break;
			}


		}else {
				
		referenceFloat.verticalFloat = 0.5f; //Entra com a velocidade do giro da camera em Following Player
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

	public void AddForce_UP()
	{		

		Vector3 movement = new Vector3 (horizontalMove, 0.0f, verticalMove);
		rb.AddForce (movement * speed);

		switch (newDirection) {
		case 0:  //UP
			verticalMove = 8.0f;		
			break;
		case 1:  //RIGHT
			horizontalMove = 8.0f;		
			break;
		case 2:  //DOWN
			verticalMove = -8.0f;
			break;
		case 3:  //LEFT 
			horizontalMove = -8.0f;
			break;

		}

	}
	
	void FixedUpdate () {

		//float target = Input.GetAxisRaw("Vertical");
		//target = 2.0f;  //valor defalut
		//target = 8.0f;   //Default final
		//fValue = Mathf.MoveTowards(0,target, 0.5f);  //Default final
		//fValue = Mathf.SmoothDamp(fValue,target,steeringVelocity,1.0f);
		//fValue = Mathf.MoveTowards(0,target, sensitivity * Time.deltaTime);

		if (forceSelection) {					
			AddForce_UP();
		}
				
	}
}
