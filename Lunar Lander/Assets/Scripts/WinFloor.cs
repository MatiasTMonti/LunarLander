using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFloor : MonoBehaviour
{
    [SerializeField] private ShipMovement player;

    [SerializeField] private GameManager gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (Vector3.Angle(transform.up, player.gameObject.transform.up) < 10)
            {
                Debug.Log("Ganaste");
                StartCoroutine(gameManager.GameOverWin());
            }
            else
            {
                Debug.Log("Perdiste");
                Destroy(collision.gameObject);
                StartCoroutine(gameManager.GameOverLose());
            }
        }

        if (collision.relativeVelocity.magnitude > 3)
        {
            Destroy(collision.gameObject);
            StartCoroutine(gameManager.GameOverLose());
        }
    }
}
