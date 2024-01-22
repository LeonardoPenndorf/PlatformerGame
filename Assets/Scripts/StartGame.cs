using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public CameraMovement cameraMovement;
    public CameraAcceleration cameraAcceleration;
    public MapGeneration mapGeneration;
    public Animator UIAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mapGeneration.beginGame();
            cameraMovement.speed = cameraMovement.cameraSpeed;
            cameraAcceleration.begin();
            UIAnim.SetTrigger("Start");
        }
    }
}
