using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptWorm : MonoBehaviour
{
    public GameObject Lazer;
    public GameObject Pellet;

    private Camera SelfCamera;

    public bool isCurrentPlayer = false;

    private float speed = 5f;
    private Rigidbody characterBody;

    private Transform leg1; //The legs are "animated" whenever the player moves
    private Transform leg2;

    private bool isJumping = false;

    public int HitPoints = 5;

    public void Start()
    {
        SelfCamera = GetComponent<Camera>();
        characterBody = GetComponent<Rigidbody>();
        leg1 = transform.Find("Leg1");
        leg2 = transform.Find("Leg2");
    }

    public void EnableControls()
    {
        isCurrentPlayer = true;
        SelfCamera.enabled = true;
    }

    public void DisableControls()
    {
        isCurrentPlayer = false;
        SelfCamera.enabled = false;
    }

    public void Derp()
    {
        Debug.Log("DERP");
    }

    public void LazerHit()
    {
        if (isCurrentPlayer != true)
        {
            HitPoints -= 3;
            Debug.Log(HitPoints);
            //Debug.Log("ZAPPP");
            DeathCheck();
        }
    }

    public void PelletHit()
    {
        if (isCurrentPlayer != true)
        {
            HitPoints -= 1;
            Debug.Log(HitPoints);
            //Debug.Log("BOOOM");
            DeathCheck();
        }
    }

    public void DeathCheck()
    {
        if (HitPoints < 0)
        {
            Object.Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (isCurrentPlayer == true)
            {
            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));
                leg1.transform.Rotate(0.5f, 0.5f, 0.0f);
                leg2.transform.Rotate(0.5f, 0.5f, 0.0f);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0f, 0.1f, 0f);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0f, -0.1f, 0f);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //Reset Rotation
            {
                leg1.transform.eulerAngles = new Vector3(90, 90, 90);
                leg2.transform.eulerAngles = new Vector3(90, 90, 90);
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"));
                leg1.transform.Rotate(0.5f, 0.5f, 0.0f);
                leg2.transform.Rotate(0.5f, 0.5f, 0.0f);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
            {
                characterBody.AddForce(Vector3.up * 300f);
                isJumping = true;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameObject LazerInstance = Instantiate(Lazer, transform.position, transform.rotation);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject PelletInstance1 = Instantiate(Pellet, transform.position, transform.rotation);
                GameObject PelletInstance2 = Instantiate(Pellet, transform.position, transform.rotation);
                GameObject PelletInstance3 = Instantiate(Pellet, transform.position, transform.rotation);
                GameObject PelletInstance4 = Instantiate(Pellet, transform.position, transform.rotation);
                GameObject PelletInstance5 = Instantiate(Pellet, transform.position, transform.rotation);
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isJumping = false;
    }
}
