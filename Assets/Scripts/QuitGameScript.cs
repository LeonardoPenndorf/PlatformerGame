using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameScript : MonoBehaviour
{
    public void quitGame()
    {
        Debug.Log("Quit Game!")
        Application.Quit();
    }
}
