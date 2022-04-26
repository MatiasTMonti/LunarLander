using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private ParticleSystem botton;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        rb.AddRelativeForce(new Vector3(0f, 4f, 0f), ForceMode.Impulse);
    //    }
    //}

    private void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0.01f)
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

        if (Input.GetAxis("Horizontal") >0.01f || Input.GetAxis("Horizontal") < 0.01f)
        {
            rb.AddForce((transform.right * 6.0f) * Input.GetAxis("Horizontal"));
        }
    }
}
