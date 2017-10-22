using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallSpawner : MonoBehaviour {

    private bool SnowBallReady = true;
    public GameObject SnowBallPrefab;
    public float SpawnTime = 1;


    // Update is called once per frame
	void Update ()
	{

	    SpawnSnowBall();

	}

    private void SpawnSnowBall()
    {
        if (SnowBallReady)
        {
            StartCoroutine(Spawn());
        }

    }

    private IEnumerator Spawn()
    {
        SnowBallReady = false;
        Instantiate(SnowBallPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(SpawnTime);
        SnowBallReady = true;
    }
}
