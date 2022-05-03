using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFloor : MonoBehaviour
{
    [SerializeField] private ShipMovement player;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject GameoverPanel;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && player.GetComponent<ShipMovement>())
        {

            if (Vector3.Angle(transform.up, player.gameObject.transform.up) < 10)
            {
                Debug.Log("Ganaste");
                StartCoroutine(gameManager.GameOverWin());
            }
            else
            {

                Destroy(player.GetComponent<ShipMovement>());
                
                Debug.Log("Perdiste");
                GameoverPanel.SetActive(true);
                StartCoroutine(gameManager.GameOverLose());
                Destroy(this);
            }
        }

        if (collision.relativeVelocity.magnitude > 3 && player.GetComponent<ShipMovement>())
        {
            Destroy(player.GetComponent<ShipMovement>());
            GameoverPanel.SetActive(true);
            StartCoroutine(gameManager.GameOverLose());
            Destroy(this);
        }
    }
}
