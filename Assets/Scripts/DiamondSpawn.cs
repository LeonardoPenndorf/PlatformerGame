using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSpawn : MonoBehaviour
{
    public int chance;
    public GameObject diamond, healingHeart;
    public Rigidbody2D rb;
    public float yOffset, launch;

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
            int y = Random.Range(0, 2); // either 0 or 1

            if (y == 1)
                spawnDiamond();
            else
                spawnHealingHeart();

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


}
