using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetCar : MonoBehaviour
{
    public GameObject CarToReset;
    public Transform ResetPosition;


    void Update()
    {
        //IF R is presset restart level.
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reset(0));

        }
    }

    public IEnumerator Reset(int ResetTime)
    {
        yield return new WaitForSeconds(ResetTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
