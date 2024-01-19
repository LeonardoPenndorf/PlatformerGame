using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerDiamonds>().diamonds += 1;
            collision.GetComponent<PlayerDiamonds>().updateCounter(); // update UI

            Destroy(gameObject);
        } else if(collision.gameObject.CompareTag("MainCamera"))
        {
            Destroy(gameObject);
        }
    }
}
