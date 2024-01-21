using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    public float minY, maxY; // random height
    public float minTime, maxTime; // random interval between spawns
    public float offset;
    public GameObject[] clouds;
    public float minSpeed, maxSpeed; // random speed
    public Transform boundaryLeft;
    public Transform backgroundStorage; // empty object used to store background objects



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnDelay());
    }

    IEnumerator spawnDelay()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        spawnCloud();
    }

    public void spawnCloud()
    {
        GameObject newCloud = Instantiate(clouds[Random.Range(0, clouds.Length)]) as GameObject;
        newCloud.transform.SetParent(backgroundStorage);
        newCloud.transform.position = new Vector3(transform.position.x + offset, Random.Range(minY, maxY), 0);
        newCloud.GetComponent<SkyObject>().velocity = -Random.Range(minSpeed, maxSpeed);
        newCloud.GetComponent<SkyObject>().isTravelingRight = false;
        newCloud.GetComponent<SkyObject>().boundary = boundaryLeft;

        StartCoroutine(spawnDelay());
    }
}
