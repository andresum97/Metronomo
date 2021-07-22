using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Metronomo : MonoBehaviour
{
    
   [Header("Metronome Sound")]
    public AudioSource[] MetroSound;
    [Header("Beat Interval")]
    public double Interval; //The interval between the ticks
    [Header("Set the Tempo")]
    public InputField BPM_input;
    
    private double BPM;
    private string BPM_text;
    //public double BPM = 120; //The number set in the inspector to set the desired Tempo
    [Header("Count How Many Beats Go By")]
    public int Counter; // Set in the inspector how much time is ellapsed.
    [Header("Set Your Duration Needed")]
    public int setTheTime = 1000;
    
    // [Header("Place Your GameObject Here")]
    // public GameObject Cube; //Place the game object you wish to change colour here
    [Header("This will change the number of beats in the bar. For Example ~ 4/4 , 5/4 , 6/4")]
    public InputField BeatsInBar_input;
    private int NumberOfBeatsInBar = 4;

    private IEnumerator coroutine;


    public void Awake()
    {
        BPM = 120;
        //We set ticks to divide the Tempo by 60(which represents a minute, to get the number between the beats). We do this in the awake function so this information is set before the first frame of the game.
        Interval = 60.0f / BPM;
        coroutine = Tick();
    }

    public void Update()
    {
        BPM_text = BPM_input.text;
        if (BPM_text != ""){
            BPM = double.Parse(BPM_text);
            if(BPM < 30){
                BPM = 30;
            }
            Interval = 60.0f / BPM;

            Debug.Log("Esto es BPM"+BPM);
        }else{
            // BPM_input.text = "30";
            BPM_text = "30";
            BPM = 30;
            Interval = 60.0f / BPM;
        }
        if(BeatsInBar_input.text != "")
        {
            NumberOfBeatsInBar = int.Parse(BeatsInBar_input.text);
            if(NumberOfBeatsInBar < 2)
            {
                NumberOfBeatsInBar = 2;
            }else
            if(NumberOfBeatsInBar >  7)
            {
                NumberOfBeatsInBar = 7;
            }
        }else
        {
            NumberOfBeatsInBar = 4;
        }
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     StartCoroutine(Tick()); //Starting our coroutine by pressing spacebar
        // }            
        
    }

    public void StartMethod()
    {
        Debug.Log("Llego al metodo");
        StartCoroutine(coroutine);
    }

    public void StopMethod()
    { 
        StopCoroutine(coroutine);  
    }

    IEnumerator Tick()
    {
        //While the time is less than 1000( You can use any number for this, but it seems to multiply it by 2 what ever you pick) this is the amount of time the metronome runs for
        while (Time.time < setTheTime) //decided to use a while statement because it seemed like the bst option for a continuingly playing beat
        {
            Counter++;
            if (Counter % NumberOfBeatsInBar == 1)             //on the first beat I want to play a different sound, then repeat that pattern every 4 beats 1(Accent), 2, 3, 4, 1(Accent), 2, 3, 4.... etc.  In this case I have used a modulas operator. 
            {
                MetroSound[0].Play();
                // Cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                Debug.Log("Up Beat");
            }
            else
            {
                MetroSound[1].Play();
                // Cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                Debug.Log("Down Beat");
            }
            yield return new WaitForSecondsRealtime((float)Interval); // Because I decided to use doubles for the ticks and BPM to be more acurate with time, we have to explicitly imply it as a float for the WaitForSecondsRealtime method to recognose it.
        }
    }
}
