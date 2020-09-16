using UnityEngine;
using System.Collections;

public class FollowingPlayer : MonoBehaviour
{
	
	//public float cameraX = 0.0f;
	//public float cameraY = 13.0f;
	//public float cameraZ = -5.0f;
	public float cameraX;
	public float cameraY;
	public float cameraZ;
   //bool forwardPressed;
	//bool cameraActivated;

	//Estas variáveis são alteradas pela pressionamento do botão (camera) 
	//e pela altura (variável y) da esfera
	public int integerToChange;
	public int boolChange;

	public float verticalFloat;
	public float horizontalFloat;
		
	private Transform playerPosition;
	//private Transform cubeRotation;
	private Transform cameraPosition;

	private float fValue;
	//private Vector3 vect; 
	//float vect = -70.0f;
	public float playerVelocity = 0.8f;
	public float rotationSpeed = 70f;

	//private float cameraAngle = 0;
	public GameObject reference;
	public Vector3 rotationAxis;
	Vector3 direction;

	private float cameraAngle = 0;
	private float cameraTemp;
	private bool complete;

	//*NEW*//
	private UP_controller direction_UP; 
	private RIGHT_controller direction_RIGHT;
	private DOWN_controller direction_DOWN;
	private LEFT_controller direction_LEFT;

	
	void Start()
	{
		playerPosition = GameObject.Find("Sphere").transform;

		direction_UP = GameObject.Find("Sphere").GetComponent<UP_controller>();  //0
		direction_RIGHT = GameObject.Find("Sphere").GetComponent<RIGHT_controller>(); //1
		direction_DOWN = GameObject.Find("Sphere").GetComponent<DOWN_controller>(); //2
		direction_LEFT = GameObject.Find("Sphere").GetComponent<LEFT_controller>();  //3

		direction = transform.position - reference.transform.position;	

		complete = true;

	}


	//Esta função mostra que o foi o botão "forward" que foi presssionado.
	public void RotateLeft(){
		
		if (complete) {
			cameraTemp = cameraAngle - 90.0f;

			direction_UP.newDirection--;
		if (direction_UP.newDirection == -1) 
				direction_UP.newDirection = 3; 	
			direction_UP.newDirection =direction_UP.newDirection % 4;

			direction_RIGHT.newDirection--;
			if (direction_RIGHT.newDirection == -1) 
				direction_RIGHT.newDirection = 3; 	
			direction_RIGHT.newDirection =direction_RIGHT.newDirection % 4;

			direction_DOWN.newDirection--;
			if (direction_DOWN.newDirection == -1) 
				direction_DOWN.newDirection = 3; 	
			direction_DOWN.newDirection =direction_DOWN.newDirection % 4;

			direction_LEFT.newDirection--;
			if (direction_LEFT.newDirection == -1) 
				direction_LEFT.newDirection = 3; 	
			direction_LEFT.newDirection =direction_LEFT.newDirection % 4;

			//Debug.Log ("direction_UP.newDirection " + direction_UP.newDirection);
		}
	}

	public void RotateRight(){
		
		if (complete) {
			cameraTemp = cameraAngle + 90.0f;

			direction_UP.newDirection++;
			direction_UP.newDirection =direction_UP.newDirection % 4;

			direction_RIGHT.newDirection++;
			direction_RIGHT.newDirection =direction_RIGHT.newDirection % 4;

			direction_DOWN.newDirection++;
			direction_DOWN.newDirection =direction_DOWN.newDirection % 4;

			direction_LEFT.newDirection++;
			direction_LEFT.newDirection =direction_LEFT.newDirection % 4;

		}
	}



	void LateUpdate() 
	{


		////float playerRotate = Input.GetAxis("Horizontal") * rotationSpeed * Time.smoothDeltaTime;
		//transform.Rotate(0, playerRotate, 0);
		////float playerMove = Input.GetAxis("Vertical") * -rotationSpeed * Time.smoothDeltaTime;	
	
		float playerRotate = horizontalFloat * rotationSpeed * Time.smoothDeltaTime;
		float playerMove = verticalFloat * -rotationSpeed * Time.smoothDeltaTime;

		//float playerRotate = Input.GetButton ("Forward") * rotationSpeed * Time.smoothDeltaTime;
		/*
		forwardPressed = Input.GetButton("Forward");
		if (forwardPressed) {
			transform.Rotate(0, playerRotate, 0,Space.World);
		}
       */

		//Alterna o tipo de movimentação da camera
		if (integerToChange==1) {	

			if (boolChange == 1) {
				transform.Rotate(0, playerRotate, 0,Space.World);
				transform.Rotate (playerMove, 0, 0, Space.Self);

			} else {
				transform.Rotate (0, 0, 0, Space.Self);

			}

		} else if(integerToChange==0){
			
			//Controle de Steering
			fValue = Mathf.MoveTowardsAngle (cameraAngle, cameraTemp, 5.0f);	
			Quaternion rot = Quaternion.AngleAxis(fValue, Vector3.up);
			transform.position = playerPosition.transform.position + new Vector3(0.0f,0.0f, 0.0f) + rot * direction;
			transform.localRotation = rot;
			//transform.Rotate (15.0f, 0, 0, Space.World);
			transform.LookAt (playerPosition);

			cameraAngle = fValue;
			 //Condicional para barrar funcionalidade dos botões Rotate caso o giro ainda não esteja completo
			if (fValue != cameraTemp) {
				complete = false;
			} else {
				complete = true;
				//Aqui envia o sinal de troca dos controles
			}
		}
		//criar else que com um OR que também considere a queda da bola fora da plataforma ou ainda quando tocar no totem
		else if (integerToChange == 2) {
			transform.LookAt (playerPosition);
		}

	}
}
