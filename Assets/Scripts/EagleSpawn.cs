using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawn : MonoBehaviour
{
    public float minY, maxY; // random height
    public float minTime, maxTime; // random interval between spawns
    public float offset;
    public GameObject eagle;
    public float minSpeed, maxSpeed; // random speed
    public Transform boundaryRight;
    public Transform backgroundStorage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnDelay());   
    }

    IEnumerator spawnDelay()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        spawnEagle();
    }

    public void spawnEagle()
    {
        GameObject newEagle = Instantiate(eagle) as GameObject;
        newEagle.transform.SetParent(backgroundStorage);
        newEagle.transform.position = new Vector3(transform.position.x + offset, Random.Range(minY, maxY), 0);
        newEagle.GetComponent<SkyObject>().velocity = Random.Range(minSpeed, maxSpeed);
        newEagle.GetComponent<SkyObject>().isTravelingRight = true;
        newEagle.GetComponent<SkyObject>().boundary = boundaryRight;

        StartCoroutine(spawnDelay());
    }
}
