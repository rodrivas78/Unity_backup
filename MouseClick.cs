using UnityEngine;
using System.Collections;

	
	public class MouseClick : MonoBehaviour
	{
		void OnMouseDown ()
		{
		GetComponent<Rigidbody>().AddForce(-transform.forward * 700f);
		GetComponent<Rigidbody>().useGravity = true;
		}
	}