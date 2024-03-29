using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxInvTime, invTime;
    public SpriteRenderer sprite;
    public float colorChangeTime;
    public float transparency, invDelay;
    public int maxHealth, currentHealth;
    public Sprite dead;
    public bool isDead;
    public float yOffset; // move up slightly when dead
    public AudioManagerScript ams;
    public CameraAcceleration cameraAcceleration; // camera acceleration script is imported for the saveTime function

    public Sprite[] hearts;
    public Image heartsIcon;

    public GameObject curtain;

    public ParticleSystem ps; // play particle effect on death

    private void Start()
    {
        isDead = false;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(invTime > 0)
        {
            invTime -= Time.deltaTime;
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        ams.playSound(ams.sfx[1]); // play take damge sound
        checkDead();
    }

    void checkDead() 
    { 
        if(currentHealth <= 0 && !isDead)
            death();
        
        else if( !isDead )
        {
            invTime = maxInvTime;
            StartCoroutine(takeDamageEffect());
            StartCoroutine(invicibilityTime());

            heartsIcon.sprite = hearts[currentHealth];
        }
    }

    void death() 
    {
        isDead = true;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.GetComponent<SpriteRenderer>().sprite = dead;
        GameObject.Find("MainCamera").GetComponent<CameraMovement>().speed = 0;

        heartsIcon.sprite = hearts[0];
        StartCoroutine(reloadDelay());
        gameObject.GetComponent<PlayerDiamonds>().saveDiamonds(); // save diamonds highscore
        cameraAcceleration.saveTime(); // save time highscore

        ams.playSound(ams.sfx[2]); // play game over sound when dead
        ps.Play();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy") || collision.CompareTag("Explosion")) && (invTime <= 0)) // if collison is enemy or explosion, take damage
        {
            takeDamage(collision.gameObject.GetComponent<EnemyInfo>().PlayerDamage);
        }
        else if (collision.CompareTag("Healing")) // if collision is healing, heal
        {
            bool collected = collision.gameObject.GetComponent<HealingHeart>().collected;
            if (currentHealth < maxHealth && !collected)
            {
                currentHealth += 1;
                heartsIcon.sprite = hearts[currentHealth];

                ams.playSound(ams.sfx[3]); // play diamond collect sound when healing

                collision.gameObject.GetComponent<HealingHeart>().collected = true; // prevent double healing
            }
        } else if (collision.CompareTag("MainCamera") && !isDead) // die when toucngi camera collider
        {
            death();
        }
    }

    IEnumerator takeDamageEffect()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(colorChangeTime);
        sprite.color = Color.white;
    }

    IEnumerator invicibilityTime()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, transparency);
        yield return new WaitForSeconds(invDelay);
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
        yield return new WaitForSeconds(invDelay);

    }

    IEnumerator reloadDelay()
    {
        yield return new WaitForSeconds(1);

        curtain.SetActive(true);
        curtain.GetComponent<CurtainScript>().fadeTo();

    }
}
