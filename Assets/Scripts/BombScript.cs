using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player")) // explodes when colliding with enemies and the player
        {
            spawnExplosion();
        }
        else if (collision.gameObject.CompareTag("MainCamera"))
        {
            Destroy(gameObject);
        }
    }

    void spawnExplosion()
    {
        GameObject newExplosion = Instantiate(explosion) as GameObject;
        newExplosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Destroy(gameObject);
    } // booom!
}
