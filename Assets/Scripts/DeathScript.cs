using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class DeathScript : MonoBehaviour {

    public GameObject Car;
    public GameObject BloodPrefab;
    private AudioSource Audiosource;
    public PlayerReset PlayerReset;
    public Sprite BloodSprite;
    public Sprite FreezeSprite; 
    private int ResetTime = 3;
    private bool IsDead;

    // Use this for initialization
    void Start()
    {
        print(PlayerValues.Player.UseBlood);
        Audiosource = GetComponent<AudioSource>();
    }

    private void Kill()
    {
        Audiosource.Play();
        Destroy(Car.GetComponent<CarMotor>());
        Destroy(Car.GetComponent<AudioSource>());
        IsDead = true;

    }
    public void Freeze()
    {
        if (IsDead) return;

        Kill();
        Car.gameObject.GetComponent<SpriteRenderer>().sprite = FreezeSprite;
        var CarRb = Car.GetComponent<Rigidbody2D>();
        CarRb.gravityScale = 0.1f;
        CarRb.velocity = CarRb.velocity * 0.1f;

        foreach (Transform child in Car.transform)
        {
            if (child.GetComponent<Rigidbody2D>())
            {
                Destroy(child.GetComponent<Rigidbody2D>());
            }
        }//

        //Reset Vehicle
        StartCoroutine(PlayerReset.Reset(ResetTime));
    }
    public void Crash()
    {
        if (IsDead) return;
        Kill();

        if (PlayerValues.Player.UseBlood)
        {
            //Spawn Blood
            Instantiate(BloodPrefab, Car.transform.position, Quaternion.identity);
            Car.gameObject.GetComponent<SpriteRenderer>().sprite = BloodSprite;
        }

        Car.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        //DESTROY THE CAR
        foreach (WheelJoint2D WheelJoint in Car.GetComponents<WheelJoint2D>())
        {
            Destroy(WheelJoint);
        }

        //Reset Vehicle
        StartCoroutine(PlayerReset.Reset(ResetTime));
    }
    public void Crush()
    {
        if (IsDead) return;
        Kill();

        if (PlayerValues.Player.UseBlood)
        {
            //Spawn Blood
            Instantiate(BloodPrefab, Car.transform.position, Quaternion.identity);
            Car.gameObject.GetComponent<SpriteRenderer>().sprite = BloodSprite;
        }


        //DESTROY THE CAR
        foreach (WheelJoint2D WheelJoint in Car.GetComponents<WheelJoint2D>())
        {
            Destroy(WheelJoint);
        }

        //Reset Vehicle
        StartCoroutine(PlayerReset.Reset(ResetTime));
    }

    }

