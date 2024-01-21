using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public ParticleSystem ps;
    public SpriteRenderer sprite;
    public bool collected = false; // checks if the diamond was already collected
    public AudioManagerScript ams;

    public void Start()
    {
        ams = GameObject.Find("AudioManager").GetComponent<AudioManagerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collected)
        {
            ams.playSound(ams.sfx[3]); // play diamond collect sound
            ps.Play();

            collision.GetComponent<PlayerDiamonds>().diamonds += 1;
            collision.GetComponent<PlayerDiamonds>().updateCounter(); // update UI

            collected = true;
            sprite.enabled = false;

        } else if(collision.gameObject.CompareTag("MainCamera"))
        {
            Destroy(gameObject);
        }
    }
}
