using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBallFire : MonoBehaviour
{
   public AudioClip audioClip;
   void Start(){
    AudioSource.PlayClipAtPoint(audioClip, transform.position);
   }
}
