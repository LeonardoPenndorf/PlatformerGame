using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeScript : MonoBehaviour
{
    public GameObject explosion; // sis spawned when killing an enemy

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject newExplosion = Instantiate(explosion) as GameObject;
            newExplosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            Destroy(collision.gameObject); // destroy enemy

            Destroy(gameObject); // destroy self
        }
        else if (collision.gameObject.CompareTag("MainCamera"))
        {
            Destroy(gameObject);
        }
    }
}
