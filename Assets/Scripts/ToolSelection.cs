using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] selector;
    [SerializeField] private GameObject[] tool;
    
    public void WateringCan()
    {
        selector[0].SetActive(true);
        selector[1].SetActive(false);
        selector[2].SetActive(false);
        tool[0].SetActive(true);
        tool[1].SetActive(false);
        tool[2].SetActive(false);
    }

    public void Hoe()
    {
        selector[0].SetActive(false);
        selector[1].SetActive(true);
        selector[2].SetActive(false);
        tool[0].SetActive(false);
        tool[1].SetActive(true);
        tool[2].SetActive(false);
    }

    public void Axe()
    {
        selector[0].SetActive(false);
        selector[1].SetActive(false);
        selector[2].SetActive(true);
        tool[0].SetActive(false);
        tool[1].SetActive(false);
        tool[2].SetActive(true);
    }
}
