using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionSave : MonoBehaviour
{
    public Transform player;
    Vector2 playerPosition;

    void Start()
    {
        if (PlayerPrefs.HasKey("playerStarted"))
        {
            player.gameObject.SetActive(false);
            player.position = new Vector2(PlayerPrefs.GetFloat("playerPositionX"), PlayerPrefs.GetFloat("playerPositionY"));
            player.gameObject.SetActive(true);
        }
        if (!PlayerPrefs.HasKey("playerStarted"))
        {
            PlayerPrefs.SetInt("playerStarted", 1);
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        playerPosition = player.position;
        PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
        PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
        PlayerPrefs.Save();
    }
}
