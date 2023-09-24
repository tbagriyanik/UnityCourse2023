using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button buton;
    private gameManager5 gameManager;
    public int difficulty = 1;

    // Start is called before the first frame update
    void Start()
    {
        buton = GetComponent<Button>();
        buton.onClick.AddListener(setDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager5>();     
    }

    private void setDifficulty()
    {
        gameManager.StartGame(difficulty);
    }  
}
