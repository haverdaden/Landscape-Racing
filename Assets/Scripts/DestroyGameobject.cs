using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameobject : MonoBehaviour
{

    public float DestroyTime = 2f;

	// Update is called once per frame
	void Update () {
        Destroy(gameObject, DestroyTime);
	}
}
