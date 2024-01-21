using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokleCloudScript : MonoBehaviour
{
    public float destroyDelay; // Set the desired delay in seconds

    private float creationTime;

    private void Start()
    {
        creationTime = Time.time; // Record the time when the object is created
    }

    private void Update()
    {
        // Check if enough time has passed since the creation
        if (Time.time - creationTime >= destroyDelay)
        {
            Destroy(gameObject);
        }
    }
}
