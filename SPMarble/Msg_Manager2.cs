using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Msg_Manager2 : MonoBehaviour {

	private PauseMenu pauseMenu;
	private GameObject pauseButton; 
	private GameObject escurecedor;
	private GameObject okButton;
	private GameObject message1;
	private GameObject message2;
	private GameObject message3;
	private GameObject message4;
	private GameObject message5;

	private GameObject camButton;
	private GameObject leftArrow;
	private GameObject rightArrow;

	private Image image;
	private Image image2;
	private Image image3;
	private Image image4;
	private Image image5;
	//private Image image6;

	private Color red;
	private Color white;

	public static bool msgOn;
	private static bool msg1; 
	//private static bool msg2; 
	private static bool msg3; 
	private static bool msg4; 
	private static bool msg5; 

	public bool timer;
	//public bool timer1;
	public bool timer2; //Timer ativado em Collision_tuto
	public bool timer3;
	public bool timer4; //Timer ativado após a queda da esfera. 

	float interval1 = 3.0f;
	float interval2 = 2.7f;

	float eventTimeTrigger;
	float eventTimeTrigger2;

	private bool catchTime;
	private int countClick;
	bool oneTimeMsg1;
	bool oneTimeMsg2;
	bool oneTimeMsg3;
	bool oneTimeMsg4;
	bool oneTimeMsg5;

	void Awake (){

		pauseMenu = GameObject.FindWithTag ("MainCamera").GetComponent<PauseMenu>();
		pauseButton = GameObject.Find ("Pause");
		escurecedor = GameObject.FindWithTag ("msgBG");
		okButton = GameObject.FindWithTag ("okButton");
		message1 = GameObject.FindWithTag ("msg1");
		//message2 = GameObject.FindWithTag ("msg2");
		message3 = GameObject.FindWithTag ("msg3");
		message4 = GameObject.FindWithTag ("msg4");
		message5 = GameObject.FindWithTag ("msg5");

		camButton = GameObject.Find ("Button");
	    leftArrow = GameObject.Find ("ArrowLeft");
		rightArrow = GameObject.Find ("ArrowRight");

	}


	void Start () {

		escurecedor.SetActive (false);
		okButton.SetActive (false);
		message1.SetActive (false);
		//message2.SetActive (false);
		message3.SetActive (false);
		message4.SetActive (false);
		message5.SetActive (false);

		eventTimeTrigger = Time.time;

		timer = true;
		//timer1 = true;
		catchTime = true;

		image = GameObject.FindWithTag("right").GetComponent<Image>();
		image2 = GameObject.FindWithTag("left").GetComponent<Image>();
		image3 = GameObject.FindWithTag("forward").GetComponent<Image>();
		image4 = GameObject.Find("Back").GetComponent<Image>();
		image5 = GameObject.FindWithTag("camButton").GetComponent<Image>();
		//image6 = GameObject.Find("ArrowRight").GetComponent<Image>();


		red = new Color (1, 0.2f, 0.2f, 1);
		white = new Color (1, 1, 1, 1);


	}

	public void PressOk () {

		msgOn = false;
		msg1 = false;
		//msg2 = false;
		msg3 = false;
		msg4 = false;
		msg5 = false;
		countClick++;

	}


	// Update is called once per frame
	void Update () {

		if (timer) {

			if (Time.time - eventTimeTrigger >= interval1) {

				msgOn = true;
				msg1 = true;					
				timer = false;	
			} 
		}

		/*
		if (timer1) {

			if (Time.time - eventTimeTrigger >= interval2) {

				msgOn = true;
				msg2 = true;
				timer1 = false;

			} 

		}
		*/
		if (timer2) {

			if (catchTime) {
				eventTimeTrigger2 = Time.time;				
				catchTime = false;
			}
			//Ativa 3a mensagem 3 segundos após a colisão com a primeira coluna
			if (Time.time - eventTimeTrigger2 >= 2.7f) {

				msgOn = true;
				msg3 = true;
				timer2 = false;
				//timer3 = true;
				//catchTime = true;

			} 	
		}


		if (timer3) {

			/*
			if (catchTime) {
				eventTimeTrigger2 = Time.time;				
				catchTime = false;
			}
			*/
			//Ativa a mensagem final 
			if (Time.time - eventTimeTrigger >= interval2) {

				//Debug.Log ("Dentro de Time");
				msgOn = true;
				msg4 = true;
				timer3 = false;

			} 
		}

		if (timer4) {

			//Ativa a mensagem de queda
			msgOn = true;
			msg1 = false;
			//msg2 = false;
			msg3 = false;
			msg4 = false;
			msg5 = true;
			timer4 = false;

		}

	}

	void OnGUI() {


		if (msg1) {

			message1.SetActive (true);
			image.color = red;
			image2.color = red;
			image3.color = red;
			image4.color = red;
			image5.color = red;
			//camButton.SetActive (false);
			leftArrow.SetActive (false);
			rightArrow.SetActive (false);
			//okButton.transform.localPosition = new Vector3 (194.3f, -220.5f, 0);
			okButton.transform.localPosition = new Vector3 (-1.52587f, -263.9f, 0); 

			oneTimeMsg1 = true;

		} else {

			if(oneTimeMsg1) {
				image.color = white;
				image2.color = white;
				image3.color = white;
				image4.color = white;
				image5.color = white;
				//camButton.SetActive (true);
				leftArrow.SetActive (true);
				rightArrow.SetActive (true);
			}
		}

		/*
		if (msg2) {

			oneTimeMsg1 = false;
			oneTimeMsg2 = true;
			image.enabled = false;
			image2.enabled = false;
			image3.enabled = false;
			image4.enabled = false;
			camButton.SetActive (false);
			leftArrow.SetActive (false);
			rightArrow.SetActive (false);
			message2.SetActive (true);
			okButton.transform.localPosition = new Vector3 (-1.52587f, -263.9f, 0); 

		} else {

			if (oneTimeMsg2) {
				image.enabled = true;
				image2.enabled = true;
				image3.enabled = true;
				image4.enabled = true;
				camButton.SetActive (true);
				leftArrow.SetActive (true);
				rightArrow.SetActive (true);
			}

		}
		*/

		if (msg3) {

			oneTimeMsg1 = false;
			oneTimeMsg3 = true;
			image.enabled = false;
			image2.enabled = false;
			image3.enabled = false;
			image4.enabled = false;
			camButton.SetActive (false);
			leftArrow.SetActive (false);
			rightArrow.SetActive (false);
			message3.SetActive (true);
			okButton.transform.localPosition = new Vector3 (-1.52587f, -263.9f, 0); 

		} else {

			if (oneTimeMsg3) {
				image.enabled = true;
				image2.enabled = true;
				image3.enabled = true;
				image4.enabled = true;
				camButton.SetActive (true);
				leftArrow.SetActive (true);
				rightArrow.SetActive (true);
			}

		}

		if (msg4) {

			oneTimeMsg3 = false;
			oneTimeMsg4 = true;
			image.enabled = false;
			image2.enabled = false;
			image3.enabled = false;
			image4.enabled = false;
			message4.SetActive (true);
			image5.color = red;
//			image6.color = red;
			okButton.transform.localPosition = new Vector3 (-120.52587f, -263.9f, 0); 
		} else {

			if (oneTimeMsg4) {
				image5.color = white;
			//	image6.color = white;
				image.enabled = true;
				image2.enabled = true;
				image3.enabled = true;
				image4.enabled = true;
				camButton.SetActive (true);
				leftArrow.SetActive (true);
				rightArrow.SetActive (true);
			}
		}

		if (msg5) {
			oneTimeMsg4 = false;
			oneTimeMsg5 = true;
		 	message5.SetActive (true);
			image.enabled = false;
			image2.enabled = false;
			image3.enabled = false;
			image4.enabled = false;
			camButton.SetActive (false);
			leftArrow.SetActive (false);
			rightArrow.SetActive (false);
			okButton.transform.localPosition = new Vector3 (-120.52587f, -263.9f, 0); 

		} else {

			if (oneTimeMsg5) {
				image.enabled = true;
				image2.enabled = true;
				image3.enabled = true;
				image4.enabled = true;
				camButton.SetActive (true);
				leftArrow.SetActive (true);
				rightArrow.SetActive (true);
			}
		}

		if (msgOn) {

			Time.timeScale = 0.0f;

			pauseMenu.enabled = false;
			pauseButton.SetActive(false);
			escurecedor.SetActive (true);
			okButton.SetActive (true);


		} else {

			pauseMenu.enabled = true;
			pauseButton.SetActive(true);
			escurecedor.SetActive (false);
			okButton.SetActive (false);

			//Time.timeScale = 1.0f;	
			message1.SetActive (false);
//			message2.SetActive (false);
			message3.SetActive (false);
			message4.SetActive (false);
  			message5.SetActive (false);

		}

	}
}

