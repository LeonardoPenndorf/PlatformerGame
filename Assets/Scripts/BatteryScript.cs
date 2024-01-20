using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


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
