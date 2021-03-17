using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public GameObject theText;
    public AudioSource clearSound;
    public GameObject thePanel;
    public LevelLoader lLoaderScript;

    public void ClearText()
    {
        theText.GetComponent<InputField>().text = "";
        clearSound.Play();
    }

    public void CancelButton()
    {
        thePanel.SetActive(false);
    }

    public void CloseButton()
    {
        thePanel.SetActive(true);
    }

    public void QuitButton()
    {
        StartCoroutine(leaveApp());
    }

    IEnumerator leaveApp()
    {
        lLoaderScript.transitionPlay = true;
        yield return new WaitForSeconds(1);
        Application.Quit();
        Debug.Log("Quit");
    }
}
