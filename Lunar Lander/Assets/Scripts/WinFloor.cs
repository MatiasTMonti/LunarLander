using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFloor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ganaste");
        }
    }
}
