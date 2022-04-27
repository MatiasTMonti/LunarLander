using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Camera cam;

    [SerializeField] private ParticleSystem botton;
    [SerializeField] private float amount = 0.1f;

    private float h;
    private float v;

    [SerializeField] private Slider fuelBar;
    [SerializeField] private float fuel = 1.0f;

    private void Start()
    {
        fuelBar.value = fuel;

        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal") * amount;
        v = Input.GetAxis("Vertical") * amount;
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Jump") > 0.01f && fuel > 0.0f)
        {
            fuel += -0.1f * Time.deltaTime;
            fuelBar.value = fuel;

            rb.AddForce(transform.up * 6.0f);

            if (!botton.isPlaying)
            {
                botton.Play();
            }
        }
        else if (botton.isPlaying)
        {
            botton.Stop();
        }

        rb.AddTorque(cam.transform.forward * h);
        rb.AddTorque(cam.transform.right * v);
    }
}
