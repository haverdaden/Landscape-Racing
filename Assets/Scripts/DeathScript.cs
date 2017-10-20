using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {

    public GameObject Car;
   // private bool IsDead;
    private AudioSource Audiosource;
    public ResetCar ResetCar;
    public Sprite BloodSprite;
    public Sprite FreezeSprite;
    private int ResetTime = 3;

    // Use this for initialization
    void Start()
    {
        Audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Kill()
    {
        Audiosource.Play();
        Destroy(Car.GetComponent<CarMotor>());
        Destroy(Car.GetComponent<AudioSource>());

    }
    public void Freeze()
    {
        Kill();
        Car.gameObject.GetComponent<SpriteRenderer>().sprite = FreezeSprite;
        var CarRb = Car.GetComponent<Rigidbody2D>();

        foreach (Transform child in Car.transform)
        {
            child.GetComponent<Rigidbody2D>().angularVelocity = 0;
        }

        CarRb.gravityScale = 0.1f;
        CarRb.velocity = CarRb.velocity * 0.1f;

        //Reset Vehicle
        StartCoroutine(ResetCar.Reset(ResetTime));
    }
    public void Crash()
    {
        Kill();
        Car.gameObject.GetComponent<SpriteRenderer>().sprite = BloodSprite;
        Car.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        //DESTROY THE CAR
        foreach (WheelJoint2D WheelJoint in Car.GetComponents<WheelJoint2D>())
        {
            Destroy(WheelJoint);
        }

        //Reset Vehicle
        StartCoroutine(ResetCar.Reset(ResetTime));
    }
}
