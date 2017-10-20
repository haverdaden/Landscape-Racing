using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskimoDeath : MonoBehaviour
{
    public Collider2D ObjectToIgnoreCollision;

    private void Start()
    {
        Physics2D.IgnoreCollision(ObjectToIgnoreCollision, GetComponent<Collider2D>());
    }
             
}
