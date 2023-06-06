using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCWalkSides : MonoBehaviour
{
    public Transform posA, posB;
    public int speed;
    Vector2 targetPos;
    public bool mustFlip;

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject button;
    public float wordSpeed;
    public bool playerIsClose;
    public bool isTalking;

    void Start()
    {
        targetPos = posB.position;
        mustFlip = false;
    }

    void Update()
    {
        if(!isTalking)
        {
            if (Vector2.Distance(transform.position, posA.position) < .1f) targetPos = posB.position;
            if (Vector2.Distance(transform.position, posB.position) < .1f) targetPos = posA.position;

            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
                isTalking = true;
            }
        }

        if (dialogueText.text == dialogue[index])
        {
            button.SetActive(true);
        }

        //Flip();

    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        isTalking = false;
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        button.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }

    /*
    void Flip()
    {
        if(mustFlip == false && transform.position == posB.position || mustFlip == true && transform.position == posA.position)
        {
            mustFlip = !mustFlip;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
     
    }*/
}
