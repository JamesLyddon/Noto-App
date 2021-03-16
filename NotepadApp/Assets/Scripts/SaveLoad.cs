using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    public string theText;
    public GameObject ourNote;
    public GameObject placeHolder;
    public GameObject savedAnim;

    private void Start()
    {
        theText = PlayerPrefs.GetString("NoteContents");
        placeHolder.GetComponent<InputField>().text = theText;
    }

    public void SaveNote()
    {
        theText = ourNote.GetComponent<Text>().text;
        PlayerPrefs.SetString("NoteContents", theText);
        StartCoroutine(SaveTextRoll());
    }

    IEnumerator SaveTextRoll ()
    {
        savedAnim.GetComponent<Animator>().Play("SavedAnim");
        yield return new WaitForSeconds(1);
        savedAnim.GetComponent<Animator>().Play("New State");
    }
}
