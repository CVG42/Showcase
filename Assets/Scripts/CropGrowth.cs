using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropGrowth : MonoBehaviour
{
    [SerializeField] GameObject[] crops;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            crops[0].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            crops[1].SetActive(true);
            crops[0].SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            crops[2].SetActive(true);
            crops[1].SetActive(false);

        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            crops[3].SetActive(true);
            crops[2].SetActive(false);
        }

       
    }
}
