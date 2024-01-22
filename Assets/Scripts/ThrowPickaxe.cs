using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;


public class ThrowPickaxe : MonoBehaviour
{
    public float cooldown, maxCooldown; // after throwing the pick axe, wait for cooldown to end
    public GameObject pickaxe; // projectile
    public Rigidbody2D rb;
    public float velocity, offset; // velocity and x offset of the pickaxe
    public Image pickaxeIcon; // pickaxe icon in the UI

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0.0f; // Initialize cooldown to 0

    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0.0f && Input.GetKeyDown(KeyCode.Return)) // the player can onyl throw pickaxes when the cooldown is 0
        {
            spawnPickAxe();
            cooldown = maxCooldown;
            pickaxeIcon.color = new Color(pickaxeIcon.color.r, pickaxeIcon.color.g, pickaxeIcon.color.b, 0.2f); // pickaxe icon becomes transparent when on cooldown
        }

        cooldown -= Time.deltaTime; // countdown cooldown

        if(cooldown <= 0.0f) // remove transparency
        {
            pickaxeIcon.color = new Color(pickaxeIcon.color.r, pickaxeIcon.color.g, pickaxeIcon.color.b, 1);
        }
    }

    void spawnPickAxe() // spawns a new pickaxe and laucnhes it in the direction the player is facing
    {
        GameObject newPickAxe = Instantiate(pickaxe) as GameObject;
        float newVelocity = velocity;
        float newOffset = offset;

        if (transform.rotation.eulerAngles.y == 180.0)
        {
            newVelocity = -newVelocity;
            newOffset = -newOffset;

            newPickAxe.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }


        newPickAxe.transform.position = new Vector3(transform.position.x + newOffset, transform.position.y + newOffset, transform.position.z);
        rb = newPickAxe.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(newVelocity, velocity);
    }
}
