using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BossHealth : MonoBehaviour
{
    [SerializeField] int bossHealth;
    [SerializeField] TMP_Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = bossHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamageBoss()
    {
        bossHealth--;
        healthText.text = bossHealth.ToString();
        if(bossHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
