using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public float force = 100;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
    }


    public float Timer = 10;
    void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            Object.Destroy(this.gameObject); //Destroys object after timer runs out
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ScriptWorm>() != null)
        {
            other.GetComponent<ScriptWorm>().LazerHit();
        }
    }
}