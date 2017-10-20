using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSticker : MonoBehaviour
{
    public GameObject CarBody;
    public GameObject Wheel1;
    public GameObject Wheel2;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == CarBody || other.gameObject == Wheel1 || other.gameObject == Wheel2)
        {
            CarBody.transform.parent.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject == CarBody || other.gameObject == Wheel1 || other.gameObject == Wheel2)
        {
            CarBody.transform.parent.parent = null;
        }
    }
}
