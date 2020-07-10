using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP_controller : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	float verticalMove;
	bool forceSelection;
	public int cameraButtonOn;  //valor é alterado em OnPress do Collision_Drop_Detect (valor zero ou um) 
	// para ativar ou desativar a aceleração 
	//quando o botão camera está ativado ou desativado
	public FollowingPlayer referenceFloat;

	private float fValue; //Teste com variável que pegará valor do GetAxis para um movimento de camera suave
	float sensitivity = 6.0f;
	float target;

	//private float steeringValue = 0;
	//private float steeringVelocity = 0;

	void Start () {
		rb = GetComponent<Rigidbody>();
		referenceFloat = GameObject.FindWithTag("MainCamera").GetComponent<FollowingPlayer>();
		fValue = 0;
	}

	public void OnPress(){

		if (cameraButtonOn == 0) {
		speed = 2.0f;
		verticalMove = 2.0f;
		Vector3 movement = new Vector3 (0.0f, 0.0f, verticalMove);
		rb.AddForce (movement * speed);
		forceSelection = true; //Mantém a aceleração dentro do loop
		}else {
			
		//referenceFloat.verticalFloat = fValue;
		referenceFloat.verticalFloat = 0.5f; //Entra com a velocidade do giro da camera em Following Player
		//enquanto não efetua acelerações na esfera
	}
	}

	public void OnRelease(){

		speed = 0;
		verticalMove = 0.0f;
		Vector3 movement = new Vector3 (0.0f, 0.0f, verticalMove);
		rb.AddForce (movement * speed);
		forceSelection = false;
		referenceFloat.verticalFloat = 0.0f;
	}

	public void AddForce_UP()
	{		
		verticalMove = 8.0f;
		Vector3 movement = new Vector3 (0.0f, 0.0f, verticalMove);
		rb.AddForce (movement * speed);
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
