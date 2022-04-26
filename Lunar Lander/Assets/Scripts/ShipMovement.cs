using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Camera cam;

    [SerializeField] private ParticleSystem botton;
    [SerializeField] private float amount = 0.1f;

    private float h;
    private float v;

    private void Start()
    {
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
        if (Input.GetAxis("Jump") > 0.01f)
        {
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
