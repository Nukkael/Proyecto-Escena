using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSounds : MonoBehaviour
{

    AudioSource animationSoundPlayer;

    
   void Start()
    {
        //Llama al componente de audio
        animationSoundPlayer = GetComponent<AudioSource>();
    }


    private void PlayerFootstepSound()
    {
        animationSoundPlayer.Play();
    }
}
