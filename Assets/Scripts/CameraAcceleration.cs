using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class CameraAcceleration : MonoBehaviour
{
    public float timeEplapsed = 0;
    public float[] thresholdArray; // increment camera speed at certain thresholds
    public CameraMovement cameraMovement; // camera movement script
    public PlayerHealth playerHealth; // only increment speed when the player is alive
    public bool gameHasBegun = false; // only increment sped when the game has begun
    public int index = 0;
    public float increment; // increments by which the camera sppeds up
    public float startSpeed; // starting speed of the camera
    public int highscoreTime; // longest time player survived
    public Text highscoreCounter;


    public void Start()
    {
        if (PlayerPrefs.HasKey("Time"))
            highscoreTime = PlayerPrefs.GetInt("Time");

        highscoreCounter.text = highscoreTime.ToString();
    } // get highscore time and display it in the UI

    public void begin()
    {
        cameraMovement.cameraSpeed = startSpeed;
        cameraMovement.speed = cameraMovement.cameraSpeed;
        gameHasBegun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameHasBegun && !playerHealth.isDead)
        {
            timeEplapsed += Time.deltaTime;
            if (timeEplapsed > thresholdArray[index + 1])
            {
                index++;
                cameraMovement.cameraSpeed += increment;
                cameraMovement.speed = cameraMovement.cameraSpeed;
            } // increment the speed at set thresholds

            if (timeEplapsed > thresholdArray[thresholdArray.Length - 1])
            {
                gameObject.GetComponent<CameraAcceleration>().enabled = false;
            } // deactivate component once we have reached maximum speed
        }
    }

    public void saveTime()
    {
        int timeEplapsedInt = Mathf.FloorToInt(timeEplapsed);

        if (timeEplapsedInt > highscoreTime)
        {
            PlayerPrefs.SetInt("Time", timeEplapsedInt);
            PlayerPrefs.Save();
        }
    }
}
