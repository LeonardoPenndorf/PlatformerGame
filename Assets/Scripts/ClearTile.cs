using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTile : MonoBehaviour
{
    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x - cam.position.x) <= -25)
            Destroy(gameObject);

    }
}
