using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerLives;
    [SerializeField] TMP_Text healthText;
    [SerializeField] GameObject DeathPanel;



    public void damagePlayer()
    {
        playerLives -= 1;
        healthText.text = playerLives.ToString() + "/5";
        if (playerLives <= 0)
        {
            // CONNOR DEATH GOES HERE
            print("Player has died");
            DeathPanel.SetActive(true);
            //time stop
            Time.timeScale = 0;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        healthText.text = playerLives.ToString() + "/5";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
