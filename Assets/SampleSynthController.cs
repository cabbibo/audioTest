using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Crosstales.FB;

public class SampleSynthController : MonoBehaviour
{
  public SampleSynth synth;
  public AudioClip clip;

  private AudioSource testSource;

  public Slider length;
  public Slider lengthRandomness;
  public Slider pitch;
  public Slider pitchRandomness;
  public Slider location;
  public Slider locationRandomness;
  public Slider speed;
  public Slider speedRandomness;

  public Text clipName;

  public void Update(){

    synth.clip = clip;

    synth.pitch = pitch.value * 3 + .1f;
    synth.pitchRandomness = pitchRandomness.value * synth.pitch;
    synth.location = location.value * clip.length;
    synth.locationRandomness = locationRandomness.value * clip.length;
    synth.speed = speed.value;
    synth.speedRandomness = speedRandomness.value;
    synth.length = length.value;
    synth.lengthRandomness = lengthRandomness.value;


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
