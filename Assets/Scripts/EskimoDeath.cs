using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskimoDeath : MonoBehaviour
{

    private HingeJoint2D Joint;
    private AudioSource AudioSource;
    private void Start()
    {
        Joint = GetComponent<HingeJoint2D>();
        AudioSource = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        if (!Joint)
        {
            AudioSource.Play();
            Destroy(this);
        }
    }
}
