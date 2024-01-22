using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public GameObject smokeCloud;
    public AudioManagerScript ams;

    public void Start()
    {
        ams = GameObject.Find("AudioManager").GetComponent<AudioManagerScript>();
        ams.playSound(ams.sfx[4]); // play explosion sound

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // destroy enemy
        }
    }
    void selfDestruct() // is called at the end of the explosion animation
    {
        Destroy(gameObject); // destroy explosion
    }

    void spawnSmokeCloud() // is called at the end of the explosion animation
    {
        GameObject newSmokeCloud = Instantiate(smokeCloud) as GameObject;
        newSmokeCloud.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
