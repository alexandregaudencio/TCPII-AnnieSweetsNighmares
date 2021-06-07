using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectmenu : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;
    // Start is called before the first frame update
    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);
    }

    // Update is called once per frame
    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }
}
