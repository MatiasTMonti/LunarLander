using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private ParticleSystem botton;
    [SerializeField] private float amount = 5f;

    private float h;
    private float v;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal") * amount * Time.deltaTime;
        v = Input.GetAxis("Vertical") * amount * Time.deltaTime;
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

        rb.AddTorque(transform.right * h);
        rb.AddTorque(transform.up * v);
    }
}
