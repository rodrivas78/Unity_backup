using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Animation : MonoBehaviour {


	public Animator myAnimatorController;


	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space))
		{
			
			myAnimatorController.SetBool("ativar", true); 

		}
		//Segundo evento do Animator
		if (Input.GetKeyDown (KeyCode.A)) 
		{

			myAnimatorController.SetBool("ativar2", true); 
			myAnimatorController.SetBool("desativar2", false);
		}
		//Terceiro evento do Animator
		if (Input.GetKeyDown (KeyCode.S)) 
		{

			myAnimatorController.SetBool("desativar2", true); 
			myAnimatorController.SetBool("ativar2", false); 
			myAnimatorController.SetBool("ativar", false); 
		}
	}
}
