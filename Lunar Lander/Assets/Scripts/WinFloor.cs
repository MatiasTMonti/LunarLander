using UnityEngine;

public class WinFloor : MonoBehaviour
{
    [SerializeField] private ShipMovement player;

    [SerializeField] private GameObject GameoverLosePanel;
    [SerializeField] private GameObject GameoverWinPanel;
    [SerializeField] private GameObject fuelBar;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && player.GetComponent<ShipMovement>())
        {
            Destroy(player.GetComponent<ShipMovement>());

            if (collision.relativeVelocity.magnitude > 3 && player.GetComponent<ShipMovement>())
            {
                GameoverLosePanel.SetActive(true);
            }
            else if (Vector3.Angle(transform.up, player.gameObject.transform.up) < 30)
            {   
                GameoverWinPanel.SetActive(true);
            }
            else
            {
                GameoverLosePanel.SetActive(true);
            }

            fuelBar.SetActive(false);
            Destroy(this);
        }
    }
}
