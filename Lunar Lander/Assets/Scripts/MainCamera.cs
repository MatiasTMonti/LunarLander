using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private const float X_ANGLE_MIN = 0.0f;
    private const float X_ANGLE_MAX = 50.0f;

    [SerializeField] private Transform lookAt;
    [SerializeField] private Transform camTransform;

    private Camera cam;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

    private void Update()
    {
        currentY += Input.GetAxis("Mouse X");
        currentX += Input.GetAxis("Mouse Y");

        currentX = Mathf.Clamp(currentX, X_ANGLE_MIN, X_ANGLE_MAX);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentX, currentY, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
