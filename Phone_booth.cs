
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;






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


	//Timer displayed at speicific current points 
	private float timer;
	public Image _timerRef;
	public int startTime ;
	public Text timerText ;
	public bool entered;

	//public GameObject backgroundpoint9;
	//this game object hide the blue target pointer when we assign to this
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
    private bool alreadyWaitingNine = false;
    private bool alreadyWaitingTen = false;
    public Test_Animation_image[] btnMOvement;

	//Rotation is used to rotate player movement at some specific point 
	public float rotateObj = -90;
//	public float rotateObj1 = 34.6434f;


	//Restart Panel at the end of journey
	public GameObject RestartPanel;
	//gameobject for video panel raw image array is used 
	public GameObject[] videoPlayer;
	//at reacing current point phone booth will turn active
	public GameObject[] Phone_Booth;
	 

	public Text[] Loci_text;

	public GameObject[] Button_Loci;

//	public GameObject SecondBooth;

// calling button movement object from other class
//	public Test_Animation_image butoon_movement;

	public Button lociBtn;
    //start buttons active when reached at current point
    public Button[] LociStartBtn;
	public GameObject lociBtn1_hide;

	public GameObject[] lociCloseBtn;

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

		Loci_text [0].enabled = false;
		Loci_text [1].enabled = false;
        Loci_text[2].enabled = false;
        Loci_text[3].enabled = false;
        Loci_text[4].enabled = false;
        //		SecondBooth.SetActive (false);

        Button_Loci [0].SetActive (false);

        Phone_Booth[0].SetActive(false);
        Phone_Booth[1].SetActive(false);
        Phone_Booth[2].SetActive(false);
        Phone_Booth[3].SetActive(false);
        Phone_Booth[4].SetActive(false);

        LociStartBtn[0].enabled = false;
        LociStartBtn[1].enabled = false;
        LociStartBtn[2].enabled = false;
        LociStartBtn[3].enabled = false;
        LociStartBtn[4].enabled = false;
    }
	 


	void Update () 
	{



		if (entered == true) 
		{
			
			timer -= Time.deltaTime;
			timerText.text = timer.ToString ("00");
			_timerRef.fillAmount = timer * 0.1f;

			if (timer <= 0 ) 
			{
				timer = startTime;


				entered = false;
			}
		}
		


	


		
		if (start == true) {

			GazePointerRing.SetActive (false);



			Vector3 dir =   path [currentPoint].position - transform.position ;
			transform.position += dir * Time.deltaTime * speed;


			if (dir.magnitude <= reachDist)
			{
				currentPoint++;

			}

			if (currentPoint == 1 && !alreadyWaiting ) 
			{
				StartCoroutine ("StopOne");
                LociStartBtn[0].enabled = true;
            }


			if (currentPoint == 2 && !alreadyWaitingTwo ) 
			{

				StartCoroutine ("StopTwo");
                LociStartBtn[0].enabled = false;
                Loci_text [0].enabled = true;
				LociLoadImages [0].SetActive (true);
                videoPlayer[0].SetActive(true);
                //			timerText.enabled = true; 
                //			Video360sphere.SetActive (true);
                //			videoPlayer [3].SetActive (true);


                //				entered = true;
            }

			if (currentPoint == 3 && !alreadyWaitingfore) 
			{
				
				StartCoroutine ("StopThree");
                LociStartBtn[1].enabled = true;
                LociStartBtn[0].enabled = false;
            }


			if (currentPoint == 4 && !alreadyWaitingFive ) 
			{
				StartCoroutine ("StopFore");
                LociStartBtn[1].enabled = false;
                Loci_text[1].enabled = true;
                LociLoadImages[1].SetActive(true);
                videoPlayer[1].SetActive(true);
                //				SecondBooth.SetActive (true);

            }

			if (currentPoint == 5  && !alreadyWaitingSix) 
			{
                StartCoroutine("StopFive");
             
                LociStartBtn[2].enabled = true;
                LociStartBtn[1].enabled = false;
                LociStartBtn[0].enabled = false;

            }

            if (currentPoint == 6 && !alreadyWaitingSeven)
            {

                StartCoroutine("StopSix");
                LociLoadImages[3].SetActive(true);
                Loci_text[2].enabled = true;
                
                videoPlayer[2].SetActive(true);
            }

            if(currentPoint == 7 && !alreadyWaitingEight)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + rotateObj, transform.rotation.z);
                StartCoroutine("StopSeven");
                               LociStartBtn[3].enabled = true;
            }

            if (currentPoint == 8  && !alreadyWaitingNine)
            {
                StartCoroutine("StopEight");
             //   LociLoadImages[4].SetActive(true);
                Loci_text[3].enabled = true;
            }
            if (currentPoint == 9)
            {

            }

            if (currentPoint == 10 && !alreadyWaitingTen)
            {
               
                StartCoroutine("StopNine");
                LociLoadImages[4].SetActive(true);
                LociStartBtn[4].enabled = true;
            }

            if (currentPoint == 11)
            {

            }

            if (currentPoint>=path.Length)
			{
 		
				currentPoint = 11;
				start = false;
	

			}

		}

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            RestartPanel.SetActive(true);
           // SceneManager.LoadScene(0);
        }

	}

	IEnumerator	 StopOne()
	{
		start = false;
		alreadyWaiting = true;
		GazePointerRing.SetActive (true);
		alreadyWaiting = true;
		yield return("StopOne");

	}

	IEnumerator	 StopTwo()
	{
		start = false;
		alreadyWaitingTwo = true;
		GazePointerRing.SetActive (true);
		yield return("StopTwo");

	}


	IEnumerator	 StopThree()
	{
		start = false;
		alreadyWaitingfore = true;

		GazePointerRing.SetActive (true);
		yield return("StopThree");

	}

	IEnumerator	 StopFore()
	{
		start = false;
		alreadyWaitingFive = true;
		GazePointerRing.SetActive (true);
		yield return("StopFore");

	}

    IEnumerator StopFive()
    {
        start = false;
        alreadyWaitingSix = true;
        GazePointerRing.SetActive(true);
        yield return ("StopFive");

    }

    IEnumerator StopSix()
    {
        start = false;
        alreadyWaitingSeven = true;
        GazePointerRing.SetActive(true);
        yield return ("StopSix");
    }

    IEnumerator StopSeven()
    {
        start = false;
        alreadyWaitingEight = true;
        GazePointerRing.SetActive(true);
        yield return ("StopSeven");
    }

    IEnumerator StopEight()
    {
        start = false;
        alreadyWaitingNine = true;
        GazePointerRing.SetActive(true);
        yield return ("StopEight");
    }

    IEnumerator StopNine()
    {
        start = false;
        alreadyWaitingTen = true;
        GazePointerRing.SetActive(true);
        yield return ("StopNine");
    }


    IEnumerator	 StartOne()
	{
		start = true;
		alreadyWaitingThree = true;
		GazePointerRing.SetActive (true);
		Playbtn.Play ();

			yield return("StartOne");

	}

	IEnumerator	 StartTwo()
	{
		start = true;
		alreadyWaitingFive = true;
		GazePointerRing.SetActive (true);
        Playbtn.Play();
        yield return("StartTwo");

	}

    IEnumerator StartThree()
    {
        start = true;
        GazePointerRing.SetActive(true);
        Playbtn.Play();
        yield return ("StartThree");
    }

    IEnumerator StartFour()
    {
        start = true;
        GazePointerRing.SetActive(true);
        Playbtn.Play();
        yield return ("StartThree");
    }

    IEnumerator	 Wait()
	{


		start = true;
		Button_Loci [1].SetActive (false);
		Button_Loci [0].SetActive (false);
		alreadyWaiting = true;
		yield return new WaitForSeconds (10f);
		Button_Loci [0].SetActive (true);
		timerText.enabled = false;
		GazePointerRing.SetActive (true);
		start = false;
		GazePointerRing.SetActive (true);
//		GetComponent<AudioSource> ().volume =0.901f;		 	
		alreadyWaiting = true;



	
	}


	IEnumerator	 Waiting()

	{   
		btnMOvement [0].btnStart = true;
        Phone_Booth[0].SetActive(true);
//		butoon_movement.btnStart = true;
		start = true;
//		entered = true;
		Phone_Booth[0].SetActive (true);
		//commented  to check wheather it opens on current point or not
// 		Loci_text [0].enabled = true;
//		LociLoadImages [0].SetActive (true);
//		timerText.enabled = true;
//		videoPlayer [3].SetActive (true);
		Playbtn.Play ();
//		GetComponent<AudioSource> ().volume =0;
		// commenting for testing by linking with button 
		#region commenting for testing by linking with button
		yield return new WaitForSeconds (10f);
//		lociBtn1_hide.SetActive (false);
//		Phone_Booth[0].SetActive (false);
//		lociBtn.enabled = false;
		videoPlayer [3].SetActive (false);
//		Button_Loci [0].SetActive (true);
//		timerText.enabled = false;
//		Loci_text [0].enabled = false;
//		LociLoadImages [0].SetActive (false);
		#endregion
//		yield return ("waiting");
////		start = false;

	




	}


	IEnumerator	 WaitingTwo()

	{
		btnMOvement [1].btnStart_2 = true;
        Phone_Booth[1].SetActive(true);
//		alreadyWaitingThree = true;
//		butoon_movement.btnStart_2 = true;
		start = true;
//		entered = true;
//		Loci_text [1].enabled = true;
//		LociLoadImages [1].SetActive (true);
//		timerText.enabled = true;
//		videoPlayer [4].SetActive (true);
		Playbtn.Play ();
		yield return new WaitForSeconds (10f);
//		LociLoadImages [1].SetActive (false);
		videoPlayer [4].SetActive (false);
////		Button_Loci [0].SetActive (true);
//		timerText.enabled = false;
//		Loci_text [1].enabled = false;
	
//		yield return  ("WaitingTwo");

	}

    IEnumerator WaitingThree()
    {
        btnMOvement[2].btnStart_3 = true;
        Phone_Booth[2].SetActive(true);
        start = true;
        Loci_text[2].enabled = true;
        LociLoadImages[2].SetActive(true);
    //    videoPlayer[4].SetActive(true);
        yield return ("WaitingThree");
    }
    IEnumerator WaitingFour()
    {
        btnMOvement[3].btnStart_4 = true;
        Phone_Booth[3].SetActive(true);
        start = true;
      //  Loci_text[3].enabled = true;
     //   LociLoadImages[3].SetActive(true);
   //     videoPlayer[4].SetActive(true);
        yield return ("WaitingFour");
    }

    IEnumerator WaitingFive()
    {
        btnMOvement[4].btnStart_5 = true;
        Phone_Booth[4].SetActive(true);
        start = true;
        Loci_text[4].enabled = true;
       LociLoadImages[4].SetActive(true);
        //     videoPlayer[4].SetActive(true);
        yield return ("WaitingFive");
    }

    IEnumerator WaitingSix()
    {
        btnMOvement[4].btnStart_5 = true;
        Phone_Booth[4].SetActive(true);
        start = true;
        Loci_text[4].enabled = true;
        LociLoadImages[4].SetActive(true);
        //     videoPlayer[4].SetActive(true);
        yield return ("WaitingSix");
    }


    //   void OnDrawGizmos()
    //{
    //	if(path.Length > 0)
    //		for (int i = 0; i < path.Length; i++) 
    //		{
    //			if(path[i] !=null)
    //			{
    //				Gizmos.DrawSphere(path[i].position,reachDist);
    //			}
    //		}
    //}

    #region buttons 

    public void LociBtn1()
	{
		StartCoroutine ("Waiting");
			
	}


	public void LociBtn2()
	{
		StartCoroutine ("WaitingTwo");
     //   LociLoadImages[1].SetActive(true);
	}

    public void LociBtn3()
    {
        StartCoroutine("WaitingThree");
     //   LociLoadImages[2].SetActive(true);
    }

    public void LociBtn4()
    {
        StartCoroutine("WaitingFour");
    //    LociLoadImages[3].SetActive(true);
    }
    public void LociBtn5()
    {
        StartCoroutine("WaitingFive");
   //     LociLoadImages[4].SetActive(true);
    }



    public void StartAgain()
	{
		StartCoroutine ("StartOne");
	}

	public void StartAgainTwo()
	{
		StartCoroutine ("StartTwo");
	}

    public void StartAgainThree()
    {
        StartCoroutine("StartThree");
    }
    public void StartAgainFour()
    {
        StartCoroutine("StartFour");
    }


	//button use to start game and off the panels
	public void locationChngBtn()
	{	
				GazePointerRing.SetActive (false);	
				Playbtn.Play ();
				start = true;
				SelectionPanel.SetActive (false);

				skybx.RotateBtn = false;
	}


	public void loci_one_close()
	{
        Loci_text[0].enabled = false;
        Phone_Booth[0].SetActive(false);
        lociBtn1_hide.SetActive (false);
		lociBtn.enabled = false;
		videoPlayer [3].SetActive (false);
		Button_Loci [0].SetActive (true);
		timerText.enabled = false;
		
		LociLoadImages [0].SetActive (false);

		lociCloseBtn[0].SetActive (false);
        Playbtn.Play();
    }

	public void loci_two_close()
	{
        Loci_text[1].enabled = false;
        LociLoadImages [1].SetActive (false);
        Phone_Booth[1].SetActive(false);
        videoPlayer [3].SetActive (false);
        ////		Button_Loci [0].SetActive (true);
        lociCloseBtn[1].SetActive(false);
        Playbtn.Play();

    }

    public void loci_three_close()
    {
        Loci_text[2].enabled=false;
        LociLoadImages[2].SetActive(false);
        Phone_Booth[2].SetActive(false);
        videoPlayer[3].SetActive(false);
        ////		Button_Loci [0].SetActive (true);
        lociCloseBtn[2].SetActive(false);
        Playbtn.Play();
    }

    public void Loci_Four_Close()
    {
        Loci_text[3].enabled = false;
        LociLoadImages[3].SetActive(false);
        Phone_Booth[3].SetActive(false);
        videoPlayer[4].SetActive(false);
        lociCloseBtn[3].SetActive(false);
        Playbtn.Play();
    }

    public void Loci_Five_Close()
    {
        Loci_text[3].enabled = false;
        LociLoadImages[4].SetActive(false);
        Phone_Booth[4].SetActive(false);
        videoPlayer[5].SetActive(false);
        Playbtn.Play();
    }




    public void locationbtn()
	{
		if (currentPoint == path.Length) 
		{ 
			
			start = true;

		}
	}

	#endregion end buttons 

	}

