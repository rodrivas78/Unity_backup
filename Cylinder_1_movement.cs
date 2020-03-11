using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Movimento de vai e vem da plataforma 1
public class Cylinder_1_movement : MonoBehaviour {

	bool volta = false;
	//private Transform playerPosition;

	void Update () {
		
			//volta = true;
			if (!volta) {
				transform.position += Vector3.right * Time.deltaTime * 5;
			if (transform.position.x >= 46) {
				volta = true;
			}
			} else {
				transform.position -= Vector3.right * Time.deltaTime * 5;
				if (transform.position.x <= 4) {
					volta = false;
				}
			}
		
		//}
	}
}
