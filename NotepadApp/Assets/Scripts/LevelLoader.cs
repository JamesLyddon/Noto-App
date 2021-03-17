using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public bool transitionPlay = false;

    public float transitionTime = 1f;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            transitionPlay = false;
        } else
        {
            StartCoroutine(EntryWait());
        }
    }

    //Input.GetMouseButtonDown(0) && 

    void Update()
    {
        if (transitionPlay == true)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator EntryWait()
    {
        yield return new WaitForSeconds(3.5f);
        transitionPlay = true;
    }
}
