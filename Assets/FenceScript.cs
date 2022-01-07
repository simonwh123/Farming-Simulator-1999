using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour
{
    public Animation anim;
    public bool open = false;
    public void openFence()
    {
        if (open == false)
        {
            anim.Play();
            open = true;
        }
    }
}
