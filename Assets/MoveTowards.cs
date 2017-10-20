using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{

    public Vector3 MoveTo;
    public Vector3 StartPosition;
    public int Speed;
    private bool reached;
    private bool doneWaiting = true;
        

    // Update is called once per frame
    private void Start()
    {
        StartPosition = transform.position;
    }

    void Update ()
	{
	    if (!reached && doneWaiting)
	    {
	        transform.position = Vector2.MoveTowards(transform.position, MoveTo, Time.deltaTime * Speed);

	        if (transform.position == MoveTo)
	        {
	            doneWaiting = false;
	            StartCoroutine(Wait());
	            reached = true;
	        }
        }
	    else if (reached && doneWaiting)
	    {
	        transform.position = Vector2.MoveTowards(transform.position, StartPosition, Time.deltaTime * Speed);

	        if (transform.position == StartPosition)
	        {
	            doneWaiting = false;
                StartCoroutine(Wait());
                reached = false;
	        }
        }

	}
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        doneWaiting = true;

    }
}

