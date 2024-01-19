using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDiamonds : MonoBehaviour
{
    public int diamonds;
    public int highscoreDiamonds;
    public Text counter;

    public void updateCounter()
    {
        counter.text = diamonds.ToString();
    }
}
