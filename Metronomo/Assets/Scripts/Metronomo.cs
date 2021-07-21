using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronomo : MonoBehaviour
{
    
   [Header("Metronome Sound")]
    public AudioSource[] MetroSound;
    [Header("Beat Interval")]
    public double Interval; //The interval between the ticks
    [Header("Set the Tempo")]
    public double BPM = 120; //The number set in the inspector to set the desired Tempo
    [Header("Count How Many Beats Go By")]
    public int Counter; // Set in the inspector how much time is ellapsed.
    [Header("Set Your Duration Needed")]
    public int setTheTime = 1000;
    [Header("Place Your GameObject Here")]
    public GameObject Cube; //Place the game object you wish to change colour here
    [Header("This will change the number of beats in the bar. For Example ~ 4/4 , 5/4 , 6/4")]
    public int NumberOfBeatsInBar = 4;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator
}
