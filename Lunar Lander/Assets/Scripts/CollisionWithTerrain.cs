using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithTerrain : MonoBehaviour
{
    [SerializeField] private ShipMovement player;
    [SerializeField] private GameObject GameoverLosePanel;
    [SerializeField] private GameObject fuelBar;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && player.GetComponent<ShipMovement>())
        {
            Destroy(player.GetComponent<ShipMovement>());
            GameoverLosePanel.SetActive(true);
            fuelBar.SetActive(false);
            Destroy(this);
        }
    }
}
