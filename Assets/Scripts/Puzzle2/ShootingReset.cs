using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingReset : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ButtonSequence.isShooting = true;
        }
    }
}
