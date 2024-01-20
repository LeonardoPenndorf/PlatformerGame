using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurtainScript : MonoBehaviour
{
    public Animator anim;
    public void deactivate()
    {
        gameObject.SetActive(false);
    }
    public void fadeTo()
    {
        anim.SetBool("FadeOut", true);
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
