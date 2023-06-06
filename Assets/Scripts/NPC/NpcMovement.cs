using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    
    private Rigidbody2D npcRb;
    
    public bool isWalking;
    private bool hasWalkZone;
    
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int walkDirection;

    public Collider2D walkZone;

    public bool canMove;
    private DialogueManager dManager;

    void Start()
    {
        npcRb = GetComponent<Rigidbody2D>();
        dManager = FindObjectOfType<DialogueManager>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

        if(walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }

        canMove = true;

    }

    void Update()
    {
        if(!dManager.dialogActive)
        {
            canMove = true;
        }

        if(!canMove)
        {
            npcRb.velocity = Vector2.zero;
            return;
        }

        if(isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch(walkDirection)
            {
                case 0:
                    npcRb.velocity = new Vector2(0, moveSpeed);
                    if(hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 1:
                    npcRb.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 2:
                    npcRb.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y < maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 3:
                    npcRb.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x < maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
            }
            
            if(walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            npcRb.velocity = Vector2.zero;

            if(waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    private void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
