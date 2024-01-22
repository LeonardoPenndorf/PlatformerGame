using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSpawn : MonoBehaviour
{
    public int chance;
    public GameObject diamond, healingHeart, bomb; // may spawn diamonds, heraling hearts or bombs
    public Rigidbody2D rb;
    public float yOffset, launch; // obly applies to the ddiamond and the healing heart
    public float bombYoffset, bombXOffset; // determines where the bomb spawns

    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(1, chance + 1);

        if (x != chance)
        {
            Destroy(gameObject.GetComponent<DiamondSpawn>());  // destroy script to only spawn one diamond
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int randomNumber = Random.Range(0, 3); // determines which game object is spawned


            int currentHealth = collision.gameObject.GetComponent<PlayerHealth>().currentHealth;
            int maxHealth = collision.gameObject.GetComponent<PlayerHealth>().maxHealth;

            if (randomNumber == 0 && (currentHealth < maxHealth)) // only spanw healing hearts, if current health < max health
            {
                spawnHealingHeart();
            }
            else if (randomNumber == 1)
            {
                spawnBomb();
            }    
            else
                spawnDiamond();

            Destroy(gameObject.GetComponent<DiamondSpawn>()); // destroy script to only spawn one diamond
        }
    }

    private void spawnDiamond()
    {
        GameObject newDiamond = Instantiate(diamond) as GameObject;

        newDiamond.transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
        rb = newDiamond.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, launch);
    }

    private void spawnHealingHeart()
    {
        GameObject newHealingHeart = Instantiate(healingHeart) as GameObject;

        newHealingHeart.transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
        rb = newHealingHeart.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, launch);
    }

    private void spawnBomb()
    {
        GameObject newBomb = Instantiate(bomb) as GameObject;
        newBomb.transform.position = new Vector3(transform.position.x + Random.Range(-bombXOffset, bombXOffset), transform.position.y + bombYoffset, transform.position.z);
    }


}
