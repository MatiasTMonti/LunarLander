using UnityEngine;

public class RotateFBXMenu : MonoBehaviour
{
    [SerializeField] private float velocity = 0.0f; 

    void Update()
    {
        transform.Rotate(Vector3.up * velocity * Time.deltaTime);
    }
}
