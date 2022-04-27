using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bottomText;

    public IEnumerator GameOverWin()
    {
        
        bottomText.text = "Llegaste a destino";
        yield return new WaitForSeconds(2.0f);
        Debug.Log("Reiniciar");
    }

    public IEnumerator GameOverLose()
    {
        bottomText.text = "Perdiste el control de la nave";
        yield return new WaitForSeconds(2.0f);
        Debug.Log("Reiniciar.2");
    }
}
