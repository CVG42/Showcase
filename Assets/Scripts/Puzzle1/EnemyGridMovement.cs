using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGridMovement : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.position += new Vector3(0f, 2f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.position += new Vector3(2f, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(-1f, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.position += new Vector3(1f, -2f, 0f);
        }
    }
}
