using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetCar : MonoBehaviour
{
    public GameObject CarToReset;
    public Transform ResetPosition;
    public 


    void Update()
    {
        //IF R is presset restart level.
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reset(0));

        }
    }

    //RESTART LEVEL
    public IEnumerator Reset(int ResetTime)
    {
        yield return new WaitForSeconds(ResetTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //RESTART FROM CHECKPOINT
    public IEnumerator ResetToCheckPoint(int ResetTime)
    {
        yield return new WaitForSeconds(ResetTime);
       // CarToReset.transform.position = CheckPoint

        //Set dead false
    }
}
