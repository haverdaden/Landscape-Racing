using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStone : MonoBehaviour
{

    public Collider2D CarBody;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == CarBody.gameObject.name)
        {
            Destroy(gameObject);
        }
    }
}
