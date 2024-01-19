using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour
{
    public BoxCollider2D box1, box2;

    public void batteryOf()
    {
        box1.enabled = false;
        box2.enabled = false;
    }

    public void batteryOn()
    {
        box1.enabled = true;
        box2.enabled = true;
    }
}
