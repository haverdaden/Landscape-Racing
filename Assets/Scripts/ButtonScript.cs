using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public AudioSource Source;
    public AudioClip Hover;
    public AudioClip Click;

    public void OnHover()
    {
        Source.PlayOneShot(Hover);
    }

    public void OnClick()
    {
        Source.PlayOneShot(Click);
    }

}
