﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

public class SampleSynth : MonoBehaviour
{

    public AudioPlayer player;
    public AudioClip clip;

    public AudioMixer mixer;

    public float pitch;
    public float pitchRandomness;
    public float location;
    public float locationRandomness;
    public float length;
    public float lengthRandomness;


  public float speed;
  public float speedRandomness;

  public float lastTime;
  public int currentStep;
  public int currentStepID;

  public float randomOffset;


  public void Start(){
    currentStep = 0;
    currentStepID = 0;
    lastTime = 0;
    randomOffset = 0;
  }


  public void Update(){

    if( Time.time - lastTime  > speed + randomOffset ){
      lastTime = Time.time;

      randomOffset = speedRandomness * Random.Range( -.5f, .5f);

      float fLocation = location + locationRandomness * Random.Range( -.5f, .5f);
      float fLength = length + lengthRandomness * Random.Range( -.5f, .5f);
      float fPitch = pitch + pitchRandomness * Random.Range( -.5f, .5f);

      player.Play( clip , fPitch , 1 , fLocation , fLength , mixer, "Master");


    } 

  }


   
}
