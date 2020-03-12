using UnityEngine;
using System.Collections;

public class FollowingPlayer : MonoBehaviour
{
	public float cameraHeight = 2.0f;
	public float cameraDistance = 9.0f;

	private Transform playerPosition;
	private Transform playerPosition2;

	private float futureTime = 0;
	private int countDown = 0;
	private float screenDuration = 8;

	private Time teste;


	//private StateManager manager;

	void Start()
	{
		playerPosition = GameObject.Find("Cube").transform;
		playerPosition2 = GameObject.Find("Willow").transform;

	}

	void Update()
	{
				
		//futureTime = screenDuration + Time.realtimeSinceStartup;
		//float rightNow = Time.realtimeSinceStartup;
		//countDown = (int)futureTime - (int)rightNow;
		Debug.Log (Time.realtimeSinceStartup);

		if (Time.realtimeSinceStartup >=15.0f) 
		{
			LookAtStone ();
		} 
		else 
		{
			transform.LookAt(playerPosition2);
		}

	}

	void LateUpdate( ) 
	{
		//transform.position = playerPosition.position + 
			//new Vector3(cameraDistance, cameraHeight, -cameraDistance);

		//transform.Rotate(0, 10 * Time.deltaTime, 0);
		//transform.LookAt(playerPosition);			

	}

	void LookAtStone( )
	{
		transform.LookAt(playerPosition);
				
	}

}