using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBird : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        this.gameObject.AddComponent<Rigidbody2D>();
        Destroy(this.GetComponent<AnimalMovement>());
        Destroy(this);
    }
}
