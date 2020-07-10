using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//Script destinado à Scena3_1  (ou cena1)
public class Collision_Drop_Detect : MonoBehaviour {

	public int nextLevelIndex;			//The next scene index;  Tirada de FinishLevels
	private int levelIndex;				//This scene index			"          "

	private Transform playerPosition;
	private Rigidbody rb;
	int contadorDeColisoes;  //Valor tem que ser igual ao número de check-points da fase
	bool once;  //Permite apenas uma colisão. 
	bool once2;  //Um para cada coluna
	private FollowingPlayer referenceScript;
	private FollowingPlayer referenceBool;
	private DOWN_controller downReference;
	private UP_controller upReference;
	private RIGHT_controller rightReference;
	private LEFT_controller leftReference;
	private PointLight1 pointLight1;
	private PointLight2 pointLight2;
	private Fiat_Lux1 fiatLux1;
	private Fiat_Lux2 fiatLux2;
	private GameObject lightningEmitter;

	private GameObject show1Star;
	private GameObject show2Stars;
	private GameObject show3Stars;

	bool buttonOn; //Desliga o botão de mudança de view da câmera

	//Variáveis do temporizador
	bool timer;
	float delayInterval = 5.0f;
	float eventTimeTrigger;

	//contagem de estrelas
	private int contaEstrelas;

	//Faz o fade das estrelas
	//public Image star1;
	//public Image star2;
	//public Image star3;
	Color starColor;
	//public float lerpMultiplier = 0.02f;

	public AudioClip efeito1;
	public AudioClip efeito2;
	public AudioClip efeito3; // entrance_2

	public AudioSource source;
	bool playAudio;

	void Awake(){
		contadorDeColisoes = 0;
		lightningEmitter = GameObject.FindWithTag ("lightning_emitter");
		//show1Star = GameObject.FindWithTag ("star1");
		//show2Stars = GameObject.FindWithTag ("star2");
		//show3Stars = GameObject.FindWithTag ("star3");
		playAudio = true;
	}

	void Start () {

		levelIndex = Application.loadedLevel;	//Getting current level index for saving needs;

		//contadorDeColisoes = 0;
		rb = GetComponent<Rigidbody>();			

		playerPosition = GameObject.Find("Sphere").transform;
		//Acessa a variável integerToChange presente em MainCamera
		referenceScript = GameObject.FindWithTag("MainCamera").GetComponent<FollowingPlayer>();
		referenceBool = GameObject.FindWithTag("MainCamera").GetComponent<FollowingPlayer>();
		//Para acessar os scripts de controle anexados à esfera
		downReference = GameObject.Find("Sphere").GetComponent<DOWN_controller> ();
		upReference = GameObject.Find("Sphere").GetComponent<UP_controller> ();
		rightReference = GameObject.Find("Sphere").GetComponent<RIGHT_controller> ();
		leftReference = GameObject.Find("Sphere").GetComponent<LEFT_controller> ();

		pointLight1 = GameObject.Find ("Point light").GetComponent<PointLight1> ();
		pointLight2 = GameObject.Find ("Point light (1)").GetComponent<PointLight2> ();
		fiatLux1 = GameObject.FindWithTag("planetag").GetComponent<Fiat_Lux1> ();
		fiatLux2 = GameObject.FindWithTag("gem2").GetComponent<Fiat_Lux2> ();

		//lightningEmitter = GameObject.FindWithTag ("lightning_emitter");
		lightningEmitter.SetActive(false);
		//show1Star.SetActive (false); //Mantem as estrelas apagadas até "timer=true"
		//show2Stars.SetActive (false);
		//show3Stars.SetActive (false);

		//Fade-in das estrelas / Seta cor transparente nos sprites
		//starColor = new Color (1, 1, 1, 0);    
		//star1.color = starColor;
		//star2.color = starColor;
		//star3.color = starColor;

		source = GetComponent<AudioSource>();		
	}

	//As seguintes funções cuidam do ponto de vista da camera. OnPress ativa a camera livre
	//são alteradas ao pressionar o botão "Button" em Canvas
	public void OnPress(){
		

		if (!buttonOn) {  //se o valor de y de playerPosition ultrapassa 5.0f o OnPress e OnRelease não alteraram o valor de intergerToChange = 2;
			referenceScript.integerToChange = 1; 
			referenceBool.boolChange = 1;
		}
		//Acessa cameraButtonOn nos scripts de controle (de aceleração) anexados à esfera. Se = true move-se a camera. 
		// Caso contrário há aceleraçao da esfera.
		//rb.constraints = RigidbodyConstraints.FreezePositionY;
		//rb.useGravity = false;
		downReference.cameraButtonOn = 1;
		upReference.cameraButtonOn = 1;
		rightReference.cameraButtonOn = 1;
		leftReference.cameraButtonOn = 1;
	}

	public void OnRelease(){

		if (!buttonOn) {   
			referenceScript.integerToChange = 0;
			referenceBool.boolChange = 0;
		}
		//rb.useGravity = true;
		//rb.constraints = RigidbodyConstraints.None;
		downReference.cameraButtonOn = 0;
		upReference.cameraButtonOn = 0;
		rightReference.cameraButtonOn = 0;
		leftReference.cameraButtonOn = 0;	
	}

	void FixedUpdate () {

		//Temporizador p/ contagem de estrelas
	
		//Debug.Log ("Time since Level:  " + Time.timeSinceLevelLoad);

		if (playerPosition.position.y <= 5.0f) {
			//transform.LookAt (playerPosition);
			referenceScript.integerToChange = 2;
			buttonOn = true;
			//referenceBool.boolChange = false;
			if (playerPosition.position.y <= -140.0f) {  //Default -240.0
				Application.LoadLevel ("scene3_1");			
			}
		} 				       
		// temporizador / evento programado 
		if (timer) {

			/*
			if (Time.timeSinceLevelLoad <= 25) {
				contaEstrelas = 3;	
				Debug.Log ("3 estrelas:  " + Time.timeSinceLevelLoad);
			} else if (Time.timeSinceLevelLoad >= 25 && Time.timeSinceLevelLoad <=35) {
				contaEstrelas = 2;			
				Debug.Log ("2 estrelas:  " + Time.timeSinceLevelLoad);
			} else {
				contaEstrelas = 1;			
				Debug.Log ("1 estrela:  " + Time.timeSinceLevelLoad);
			}
			*/
			//Mostra as estrelas na tela antes de mudar de nível. Torna ativo o GameObject
			// e utilza um lerp para o efeito de fade

			/*
			switch (contaEstrelas) {
			case 1:
				show1Star.SetActive (true);
				starColor = Color.Lerp (starColor, new Color (1, 1, 1, 1),
					Time.time * lerpMultiplier);
				star1.color = starColor;
				break;
			case 2:
				show2Stars.SetActive (true);
				starColor = Color.Lerp (starColor, new Color (1, 1, 1, 1),
					Time.time * lerpMultiplier);
				star2.color = starColor;
				break;
			case 3:
				show3Stars.SetActive (true);	
				starColor = Color.Lerp (starColor, new Color (1, 1, 1, 1),
					Time.time * lerpMultiplier);
				star3.color = starColor;				
				break;
			}
			*/

			/*
			if (contaEstrelas == 1) {
				show1Star.SetActive (true);
				starColor = Color.Lerp(starColor, new Color(1, 1, 1, 1),
					Time.time * lerpMultiplier);
				star1.color = starColor;
			}
			if (contaEstrelas == 2) {
				show2Stars.SetActive (true);
				starColor = Color.Lerp(starColor, new Color(1, 1, 1, 1),
					Time.time * lerpMultiplier);
				star2.color = starColor;
			}
			if (contaEstrelas == 3) {
				show3Stars.SetActive (true);	
				starColor = Color.Lerp(starColor, new Color(1, 1, 1, 1),
					Time.time * lerpMultiplier);
				star3.color = starColor;
			}
			*/
			//Ativa o Lightning Emitter de mudança de fase (teletransporte)
			if (Time.time - (eventTimeTrigger - delayInterval / 2) >= delayInterval) {
				    	
					lightningEmitter.SetActive (true);

				if (playAudio) {
					source.PlayOneShot (efeito3, 0.5F);
					playAudio = false;
				}
			
			}
				
			if (Time.time - eventTimeTrigger >= delayInterval) {
				
				Data.SaveData(levelIndex, true, 1);
				LoadNextLevel();
			}
		}
	
	} // fim do Update

	//Contador de colisões
	void OnCollisionEnter(Collision collision) {


		if(collision.gameObject.name == "roman_column_short" && !once) 
		{
			contadorDeColisoes++;
			source.PlayOneShot(efeito2, 0.5F);
			source.PlayOneShot(efeito1, 0.9F);
			pointLight1.turnOn = true; 
			fiatLux1.turnOnFiatLux = true;
			once = true;

		}
		if(collision.gameObject.name == "roman_column_short (1)" && !once2) 
		{
			contadorDeColisoes++;
			//Destroy (GameObject.Find ("Cylinder (1)"), 0.6f);

			once2 = true;			 

			if (contadorDeColisoes == 2) {
				//Time.timeScale = 0.4f; //Reduz a velocidade do jogo 
				//Data.SaveData(levelIndex, true, contaEstrelas);
				rb.constraints = RigidbodyConstraints.FreezePositionY;  
				source.PlayOneShot(efeito2, 0.5F);
				source.PlayOneShot(efeito1, 0.9F);	
				pointLight2.turnOn = true;
				fiatLux2.turnOnFiatLux = true;
				//lightningEmitter.SetActive (true);

				eventTimeTrigger = Time.time;
				timer = true; //Ativa o timer que chamará a próxima cena	

			}
			//else mensagem "Voce nao ativou todas as "pedras"
		}
	}

	void LoadNextLevel()
	{
		Application.LoadLevel(4);

	}
}
