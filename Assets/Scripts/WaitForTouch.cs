using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForTouch : MonoBehaviour
{

    public GameObject GameObjectToTrigger;

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject == GameObjectToTrigger)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}
