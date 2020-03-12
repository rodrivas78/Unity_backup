using UnityEngine;
using System.Collections;

public class FollowingPlayer : MonoBehaviour
{
	public float cameraHeight = 2.0f;
	public float cameraDistance = 9.0f;
		
	private Transform playerPosition;
	
	void Start()
	{
		playerPosition = GameObject.Find("Player").transform;
	}

		
	void LateUpdate( ) 
	{
		transform.position = playerPosition.position + 
			new Vector3(cameraDistance, cameraHeight, -cameraDistance);
		transform.LookAt(playerPosition);
		//transform.Rotate(0, 10 * Time.deltaTime, 0);

	}
}