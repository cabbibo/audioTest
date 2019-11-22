﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.IO;
using Crosstales.FB;

public class ArpController : MonoBehaviour
{
  

  public arp synth;
  public AudioClip clip;

  public Slider speed;
  public Slider speedRandomness;

  public Toggle randomize;
  public Toggle up;

  public Text clipName;


  public void Update(){

    synth.clip = clip;

    synth.speed = speed.value;
    synth.speedRandomness = speedRandomness.value;
    synth.randomize = randomize.isOn;
    synth.up = up.isOn;


  }


    public void ChooseClip(){

  string path = FileBrowser.OpenSingleFile("wav");
 if( path.Length > 0 ){
    StartCoroutine(loadMusic(path));
  }

}


IEnumerator loadMusic(string path){
  var www = new WWW("file://" + path);
  yield return www; // code will wait till file is completely read
  clip= www.GetAudioClip();

  string projectName = Path.GetFileName(path);
  clipName.text = projectName;

}
 
}