using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDiamonds : MonoBehaviour
{
    public int diamonds;
    public int highscoreDiamonds = 0;
    public Text counter;

    public void Start()
    {
        if (PlayerPrefs.HasKey("Diamonds"))
            highscoreDiamonds = PlayerPrefs.GetInt("Diamonds");
    }

    public void updateCounter()
    {
        counter.text = diamonds.ToString();
    }

    public void saveDiamonds()
    {
        if (diamonds > highscoreDiamonds)
        {
            PlayerPrefs.SetInt("Diamonds", diamonds);
            PlayerPrefs.Save();
        }
    }
}
