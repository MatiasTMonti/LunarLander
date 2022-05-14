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
        MovePlayer();
    }

    private void FixedUpdate()
    {
        RotatePlayer();
    }

    public void MovePlayer()
    {
        h = -Input.GetAxis("Horizontal") * amount;
        v = Input.GetAxis("Vertical") * amount;
    }

    public void RotatePlayer()
    {
        if (Input.GetAxis("Jump") > 0.01f && fuel > 0.0f)
        {
            fuel += -0.05f * Time.deltaTime;
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

        rb.AddTorque(cam.transform.forward * h * Time.deltaTime);
        rb.AddTorque(cam.transform.right * v * Time.deltaTime);
    }

    public void SetFuel(float fuel)
    {
        this.fuel = fuel;
    }
}
