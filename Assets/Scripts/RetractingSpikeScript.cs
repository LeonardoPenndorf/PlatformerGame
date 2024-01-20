using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetractingSpikeScript : MonoBehaviour
{
    public BoxCollider2D box;
    
    public void spikeUp()
    {
        box .enabled = true;
    }

    public void spikeDown()
    {
        box.enabled = false;
    }
}
