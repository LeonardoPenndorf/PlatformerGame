using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // destroy enemy
        }
    }

void selfDestruct() // is called at the end of the explosion animation
    {
        Destroy(gameObject);
    }
}
