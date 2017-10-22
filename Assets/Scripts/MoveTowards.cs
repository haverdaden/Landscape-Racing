using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{

    public Vector3 MoveTo;
    private Vector3 StartPosition;
    public int Speed;
    private bool reached;
    private bool doneWaiting = true;
        

    private void Start()
    {
        //Get Start Position
        StartPosition = transform.position;
    }

    void Update ()
	{
        //Move platform to set position
	    if (!reached && doneWaiting)
	    {

            transform.position = Vector3.MoveTowards(transform.position, MoveTo, Time.deltaTime * Speed);

	        if (Vector3.Distance(transform.position,MoveTo) <= 2)
	        {//
                doneWaiting = false;
	            StartCoroutine(Wait());
	            reached = true;

            }
        }
        //Move platform back to start position
	    else if (reached && doneWaiting)
	    {

	        transform.position = Vector3.MoveTowards(transform.position, StartPosition, Time.deltaTime * Speed);

	        if (transform.position == StartPosition)
	        {
	            doneWaiting = false;
                StartCoroutine(Wait());
                reached = false;
	        }
        }

	}
    //Platform wait
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        doneWaiting = true;

    }
}

