using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsPanel : MonoBehaviour
{
    public GameObject buttons, controls;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void openControlsPanel()
    {
        controls.gameObject.SetActive(true);
        buttons.gameObject.SetActive(false);

    }

    public void closeControlsPanel()
    {
        controls.gameObject.SetActive(false);
        buttons.gameObject.SetActive(true);
    }
}
