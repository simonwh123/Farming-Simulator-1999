using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour
{
    public AnimationClip openAnim;
    public AnimationClip closeAnim;
    public Animation anim;

    public AudioSource sound;

    public bool open = false;
    public void openFence()
    {
        if (open == false && sound.isPlaying == false)
        {
            anim.clip = openAnim;
            anim.Play();
            open =! open;
            sound.Play();
            sound.pitch = 1;
        }
        else
        {
            if (sound.isPlaying == false)
            {
                anim.clip = closeAnim;
                anim.Play();
                open = !open;
                sound.Play();
                sound.pitch = 0.8f;
            }
        }
    }
}
