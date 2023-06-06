using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public TMP_Text dText;
    public bool dialogActive;
    public string[] dialogLines;
    public int currentLine;


    void Start()
    {

    }


    void Update()
    {


        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;
        }


        if (currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;
            currentLine = 0;
        }


        if (currentLine < dialogLines.Length)
        {
            dText.text = dialogLines[currentLine];
        }

    }


    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
    }

}
