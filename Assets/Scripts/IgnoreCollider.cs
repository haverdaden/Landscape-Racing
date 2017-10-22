using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollider : MonoBehaviour
{

    public Collider2D ColliderToIgnore;
    public LayerMask LayerToignore;

	// Use this for initialization
	void Start () {

	    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), ColliderToIgnore);
        if (ColliderToIgnore)
	    {

	        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerToignore.value, true);
        }


  

	}
	

}
