using UnityEngine;
using System.Collections;
using UnityEngine.UI;



//This Script is written by Muhammad Maaz Irfan which is used for smoth movement of player from one point to another 
//It can be used easily in VR and also can be used for roalercoster kind of games 
//There are certain current points when user reach at that timer will popup for 10 sec and can be changed in unity edittor too 


public class Phone_booth : MonoBehaviour {

	//for smooth movement 
	public Transform[] path;
	public float speed = 5.0f;
	public float reachDist = 1.0f;
	//specific defined path to follow
	public int currentPoint = 0;

	public GameObject SelectionPanel;
	//to start movement start has to be true other wise it wont run
	public	bool start;
	public UI skybx;

	public AudioSource Playbtn;
	public AudioSource[] AlertSound;


	//test
	public GameObject locitest;

	//Timer displayed at speicific current points 
	private float timer;
	public Image _timerRef;
	public int startTime = 3;
	public Text timerText ;
	public bool entered;

	//public GameObject backgroundpoint9;

	public GameObject GazePointerRing;

	public GameObject Video360sphere;


	public GameObject[] LociLoadImages;

	//already waiting is used to call for waiting part when timer comes up
	private bool alreadyWaiting = false;
	private bool alreadyWaitingPointTwo = false;
	private bool alreadyWaitingTwo = false;
	private bool alreadyWaitingThree = false;
	private bool alreadyWaitingfore = false;
	private bool alreadyWaitingFive = false;
	private bool alreadyWaitingSixPointOne = false;
	private bool alreadyWaitingSix = false;
	private bool alreadyWaitingSeven = false;
	private bool alreadyWaitingEight = false;

	//Rotation is used to rotate player movement at some specific point 
	public float rotateObj = -90;
	public float rotateObj1 = 34.6434f;


	//Restart Panel at the end of journey
	public GameObject RestartPanel;

	public GameObject[] videoPlayer;

	public GameObject Phone_Booth;



	public GameObject Background;


	void Start () {
	


		start = false;
		entered = true;
		timerText.enabled = false;

		GazePointerRing.SetActive (true);

		Video360sphere.SetActive (false);

		RestartPanel.SetActive (false);

		videoPlayer[0].SetActive (false);
		videoPlayer[1].SetActive (false);
		videoPlayer[2].SetActive (false);
		videoPlayer[3].SetActive (false);
		videoPlayer[4].SetActive (false);
		videoPlayer[5].SetActive (false);
		videoPlayer[6].SetActive (false);
		videoPlayer[7].SetActive (false);

			}
	 






// Update is called once per frame
	void Update () {


		if (entered == true) 
		{
			
			timer -= Time.deltaTime;
			timerText.text = timer.ToString ("00");
			_timerRef.fillAmount = timer * 0.1f;
			if (timer <= 0) {
				timer = startTime;

				LociLoadImages [0].SetActive (false);
				videoPlayer[0].SetActive (false);

				LociLoadImages [1].SetActive (false);
				videoPlayer[1].SetActive (false);

				LociLoadImages [2].SetActive (false);
				videoPlayer[2].SetActive (false);

				LociLoadImages [3].SetActive (false);
				videoPlayer[3].SetActive (false);



				entered = false;
			}
		}
		


	


		
		if (start == true) {

		//	GazePointerRing.SetActive (false);

			Vector3 dir =   path [currentPoint].position - transform.position ;
			transform.position += dir * Time.deltaTime * speed;


			if (dir.magnitude <= reachDist)
			{
				currentPoint++;

			}


			if (currentPoint == 2 && !alreadyWaiting  ) 
			{
				
				entered = true;
				timerText.enabled = true;


				StartCoroutine ("Wait");     



			} 
		




			if (currentPoint == 3) 
			{
				RestartPanel.SetActive (true);
			}


			if(currentPoint>=path.Length)
			{
 		
				currentPoint = 2;
				start = false;
	//			GazePointerRing.SetActive (true);

			}

		}

		//GazePointerRing.SetActive (true);


	 


	}


IEnumerator	 Wait()
	{
		

			
		start = false;
		GetComponent<AudioSource> ().volume =0;
		alreadyWaiting = true;
		yield return new WaitForSeconds (10f);
		timerText.enabled = false;
		Phone_Booth.SetActive (false);
		Background.SetActive (true);
		GazePointerRing.SetActive (true);
		start = true;
		GetComponent<AudioSource> ().volume =0.901f;		 	
		alreadyWaiting = true;
				
	}







	IEnumerator	 WaitPointTwo()

	{
		entered = true;
		LociLoadImages [0].SetActive (true);
		videoPlayer[0].SetActive (true);
		GetComponent<AudioSource> ().volume =0;
		alreadyWaitingPointTwo = true;
		yield return new WaitForSeconds (10f);
		timerText.enabled = false;
//		videoPlayer[0].SetActive (false);
//		LociLoadImages [0].SetActive (false);
		GetComponent<AudioSource> ().volume =0.901f;
//		alreadyWaitingPointTwo = true;


	}
	IEnumerator	 WaitTwo()
	{


		entered = true;
		LociLoadImages [1].SetActive (true);
		videoPlayer[1].SetActive (true);
		GetComponent<AudioSource> ().volume =0;			
		alreadyWaitingTwo = true;
		yield return new WaitForSeconds (10f);
		timerText.enabled = false;
//		LociLoadImages [1].SetActive (false);
//		videoPlayer[1].SetActive (false);
		GetComponent<AudioSource> ().volume =0.901f;
//		alreadyWaitingTwo = true;



	}

	IEnumerator	 WaitThree()
	{

		entered = true;
		LociLoadImages [2].SetActive (true);
		videoPlayer[2].SetActive (true);
		GetComponent<AudioSource> ().volume =0;			
		alreadyWaitingThree = true;
		yield return new WaitForSeconds (10f);
		timerText.enabled = false;
//		LociLoadImages [2].SetActive (false);
//		videoPlayer[2].SetActive (false);
		GetComponent<AudioSource> ().volume =0.901f;
//		alreadyWaitingThree = true;



	}

	IEnumerator	 Waitfore()
	{


		entered = true;
		LociLoadImages [3].SetActive (true);
		videoPlayer[3].SetActive (true);
		GetComponent<AudioSource> ().volume =0;			
		alreadyWaitingfore = true;
		yield return new WaitForSeconds (10f);
		timerText.enabled = false;
//		LociLoadImages [3].SetActive (false);
//		videoPlayer[3].SetActive (false);
		GetComponent<AudioSource> ().volume =0.901f;
//		alreadyWaitingfore = true;



	}

	IEnumerator	 Waitfive()
	{


		start = false;
		GetComponent<AudioSource> ().volume =0;

		videoPlayer[4].SetActive (true);

		LociLoadImages [4].SetActive (true);
	
		alreadyWaitingfore = true;
		yield return new WaitForSeconds (10f);
		timerText.enabled = false;
		print (start);
		LociLoadImages [4].SetActive (false);

		videoPlayer[4].SetActive (false);

		start = true;
		print (Time.time);

		GetComponent<AudioSource> ().volume =0.901f;
		alreadyWaitingFive = true;



	}

	IEnumerator	 WaitSixPointOne()
	{


		start = false;
		GetComponent<AudioSource> ().volume =0;

		videoPlayer[5].SetActive (true);

		LociLoadImages [5].SetActive (true);
	
		alreadyWaitingSixPointOne = true;
		yield return new WaitForSeconds (10f);
		timerText.enabled = false;
		print (start);
		LociLoadImages [5].SetActive (false);

		videoPlayer[5].SetActive (false);

		start = true;
		print (Time.time);

		GetComponent<AudioSource> ().volume =0.901f;
		alreadyWaitingSixPointOne = true;



	}





	IEnumerator	 WaitSix()
	{


		start = false;
		GetComponent<AudioSource> ().volume =0;

		videoPlayer[5].SetActive (true);

		LociLoadImages [5].SetActive (true);
	
		alreadyWaitingfore = true;
		yield return new WaitForSeconds (10f);
		timerText.enabled = false;
		print (start);
		LociLoadImages [5].SetActive (false);

		videoPlayer[5].SetActive (false);

		start = true;
		print (Time.time);

		GetComponent<AudioSource> ().volume =0.901f;
		alreadyWaitingSix = true;



	}

	IEnumerator	 WaitSeven()
	{


		start = false;
		GetComponent<AudioSource> ().volume =0;

		videoPlayer[6].SetActive (true);

		LociLoadImages [6].SetActive (true);
	//	AlertSound[6].Play ();
		alreadyWaitingfore = true;
		yield return new WaitForSeconds (10f);
		timerText.enabled = false;
		print (start);
		LociLoadImages [6].SetActive (false);

		videoPlayer[6].SetActive (false);

		start = true;
		print (Time.time);

		GetComponent<AudioSource> ().volume =0.901f;
		alreadyWaitingSeven = true;



	}

	IEnumerator	 WaitEight()
	{


		start = false;
		GetComponent<AudioSource> ().volume =0;

		videoPlayer[7].SetActive (true);

		LociLoadImages [6].SetActive (true);
	//	AlertSound[7].Play ();
		alreadyWaitingfore = true;
		yield return new WaitForSeconds (10f);
		timerText.enabled = false;
		print (start);

		videoPlayer[7].SetActive (false);

		start = true;
		print (Time.time);

		GetComponent<AudioSource> ().volume =0.901f;
		alreadyWaitingEight = true;



	}






	void OnDrawGizmos()
	{
		if(path.Length > 0)
			for (int i = 0; i < path.Length; i++) 
			{
				if(path[i] !=null)
				{
					Gizmos.DrawSphere(path[i].position,reachDist);
				}
			}
	}








	public void LociBtn1()
	{
		if (entered = true && !alreadyWaitingPointTwo) 
		{			
			StartCoroutine ("WaitPointTwo");	
		}

		
	}



	public void LociBtn2()
	{
		if (entered = true && !alreadyWaitingTwo) 
		{
			//start = false;
			Debug.Log ("hellooooo");
			StartCoroutine ("WaitTwo");	
		}


	}


	public void LociBtn3()
	{
		if (entered = true && !alreadyWaitingThree) 
		{
			StartCoroutine ("WaitThree");
		}
	}


	public void LociBtn4()
	{
		if (entered = true && !alreadyWaitingfore) 
		{
			StartCoroutine ("Waitfore");
		}
	}




	public void locationChngBtn()
	{	
		GazePointerRing.SetActive (false);	
		Playbtn.Play ();
				start = true;
				SelectionPanel.SetActive (false);

			skybx.RotateBtn = false;
		
		//skybx.RotateBtn = false;

	}







	public void locationbtn()
	{
		if (currentPoint == path.Length) 
		{ 
			
			start = true;

		}
	}
	}

