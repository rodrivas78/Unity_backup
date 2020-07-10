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
	private Transform cubeRotation;
	private Transform cameraPosition;

	private float fValue;
	//private Vector3 vect; 
	//float vect = -70.0f;
	public float playerVelocity = 0.8f;
	public float rotationSpeed = 70f;
	public float constantValue = 2.0f;

	//private float cameraAngle = 0;
	public GameObject reference;
	public Vector3 rotationAxis;
	Vector3 direction;

	private float target;


	
	void Start()
	{
		playerPosition = GameObject.Find("Sphere").transform;
		direction = transform.position - reference.transform.position;	

	}

	/*
	//Esta função mostra que o foi o botão "forward" que foi presssionado.
	public void RotateLeft(){
		//forwardPressed = true;
		cameraAngle = cameraAngle - 90.0f;
		target = cameraAngle;

	}

	public void RotateRight(){
		//forwardPressed = true;
		cameraAngle = cameraAngle + 90.0f;
		//target = cameraAngle;
	}
	*/


	void LateUpdate() 
	{


		////float playerRotate = Input.GetAxis("Horizontal") * rotationSpeed * Time.smoothDeltaTime;
		//transform.Rotate(0, playerRotate, 0);
		////float playerMove = Input.GetAxis("Vertical") * -rotationSpeed * Time.smoothDeltaTime;

	

		////float playerRotate = constantValue * rotationSpeed * Time.smoothDeltaTime;
		////float playerMove = constantValue * -rotationSpeed * Time.smoothDeltaTime;
		float playerRotate = horizontalFloat * rotationSpeed * Time.smoothDeltaTime;
		float playerMove = verticalFloat * -rotationSpeed * Time.smoothDeltaTime;


		//float playerRotate = Input.GetButton ("Forward") * rotationSpeed * Time.smoothDeltaTime;
		/*
		forwardPressed = Input.GetButton("Forward");
		if (forwardPressed) {
			transform.Rotate(0, playerRotate, 0,Space.World);
		}
       */

		//transform.Translate(playerMove, 0, 0);
		////transform.position = playerPosition.position + new Vector3(cameraX, cameraY, cameraZ);
		////transform.LookAt (playerPosition);
		//transform.position= cameraPosition.position + new Vector3(-6.06f,2.73f, -0.2f);
		//target = 2.0f;
		//fValue = Mathf.SmoothDamp(fValue,target,steeringVelocity,1.0f);
		//fValue = Mathf.MoveTowards(0,cameraAngle, 90.0f);
		//fValue = Mathf.MoveTowards(0,cameraAngle, 5.0f);

		//fValue = Mathf.MoveTowardsAngle (target, cameraAngle, 90.0f);

		//Quaternion rot = Quaternion.AngleAxis(cameraAngle, Vector3.up);
		/*
		Quaternion rot = Quaternion.AngleAxis(cameraAngle, Vector3.up);
		transform.position = reference.transform.position + new Vector3(0.0f,2.0f, -2.0f) + rot * direction;
		transform.localRotation = rot;
		transform.Rotate (15.0f, 0, 0, Space.Self);
		Debug.Log("cameraAngle" + fValue);
        */

		//Alterna o tipo de movimentação da camera
		if (integerToChange==1) {	

			if (boolChange == 1) {
				transform.Rotate(0, playerRotate, 0,Space.World);
				transform.Rotate (playerMove, 0, 0, Space.Self);

			} else {
				transform.Rotate (0, 0, 0, Space.Self);
				//transform.Rotate (0, 0, 0, Space.Self);
			}
			//transform.RotateAround (Vector3.zero, Vector3.up, 2 * Time.deltaTime);
			//transform.Rotate (0, playerRotate, 0);
			//transform.Translate (0, -4, 0);

		} else if(integerToChange==0){
			transform.position = playerPosition.position + new Vector3(cameraX, cameraY, cameraZ);
			//transform.position = playerPosition.position + rot * direction;
			transform.LookAt (playerPosition);
		}
		//criar else que com um OR que também considere a queda da bola fora da plataforma ou ainda quando tocar no totem
		else if (integerToChange == 2) {
			transform.LookAt (playerPosition);
		}


		/*
		if (integerToChange == 2) {
			transform.LookAt (playerPosition);
		}
        */
		/*
		if (integerToChange==1) {

			transform.LookAt (playerPosition);
			//transform.position = playerPosition.position + new Vector3(cameraDistance, cameraHeight, cameraAxis);
			//transform.LookAt(playerPosition);
			//transform.RotateAround (Vector3.zero, Vector3.up, 2 * Time.deltaTime); //Variar entre 2 e 10
			//transform.Rotate(0, 90, 0);
			//transform.position = cameraPosition.position + new Vector3(-6.06f,2.73f, -0.2f);
			//transform.position = playerPosition.position + new Vector3(-6.06f,2.73f, -0.2f);
		}
		//if (transform.position.y >= -69.0f)    {
			
		//transform.position = playerPosition.position + new Vector3(cameraDistance, cameraHeight, cameraAxis);
		   //transform.LookAt(playerPosition);
			//transform.RotateAround (Vector3.zero, Vector3.up, 2 * Time.deltaTime);

		//transform.Rotate(0, 10 * Time.deltaTime, 0);
		//}
		else {			
		//transform.LookAt (playerPosition);
			//transform.position = playerPosition.position + new Vector3(cameraDistance, cameraHeight, cameraAxis);

		}
		*/

	}
}