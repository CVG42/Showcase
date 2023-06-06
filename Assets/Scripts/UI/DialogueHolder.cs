using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public string dialogue;
    private DialogueManager dMan;
    public string[] dialogueLines;

    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
    }


    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.name == "Player")
        {

            if (Input.GetKeyUp(KeyCode.Space))
            {

                if (!dMan.dialogActive)
                {
                    dMan.dialogLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }

                if(transform.parent.GetComponent<NpcMovement>() != null)
                {
                    transform.parent.GetComponent<NpcMovement>().canMove = false;
                }

            }
        }
    }
}
