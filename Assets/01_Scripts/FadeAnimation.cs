using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimation : MonoBehaviour
{
    public Animator animator;

    public void LoadScene(string name)
    {
        StartCoroutine(Transition(name));
    }

    IEnumerator Transition(string scene)
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        LevelLoader.LoadLevel(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
