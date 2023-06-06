using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
    }

    private void OnEnable()
    {
        rb.velocity = Vector2.right * bulletSpeed;
    }

    private void OnCollisionEnter2D()
    {
        gameObject.SetActive(false);
    }
}
