using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchObject : MonoBehaviour
{

    public float LaunchForce = 80000f;
    public Vector3 LaunchDirection;
    public Rigidbody2D ObjectToLaunch;
    public ParticleSystem Particles;
    private bool OnCoolDown;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == ObjectToLaunch.gameObject.name)
        {
            if (!OnCoolDown)
            {
                print(other);
                StartCoroutine(CoolDown());
                StartCoroutine(Launch(other));
            }
            
        }




    }

    private IEnumerator Launch(Collider2D other)
    {
        yield return new WaitForSeconds(2);
        Particles.Play();
        var rb = other.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce((LaunchDirection - rb.transform.position) * LaunchForce,ForceMode2D.Force);
    }

    private IEnumerator CoolDown()
    {
        OnCoolDown = true;
        yield return new WaitForSeconds(4);
        OnCoolDown = false;
    }
}
