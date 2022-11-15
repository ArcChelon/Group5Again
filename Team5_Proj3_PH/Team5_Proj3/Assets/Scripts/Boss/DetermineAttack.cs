using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetermineAttack : MonoBehaviour
{
    [SerializeField] float coolDown;
    private int previous;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(attackCoolDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator attackCoolDown()
    {
        print("Cooldown");
        yield return new WaitForSeconds(coolDown);
        determineAttack();
    }
    private void determineAttack()
    {
        int choice = Random.Range(1, 4);
        //int choice = 2;
        if(choice == 1)
        {
            gameObject.GetComponent<BossShoot>().determineLanes();
            
        }
        else if(choice == 2)
        {
            gameObject.GetComponent<BossLaser>().determineLane();
        }
        else
        {
            
        }
    }
    public void cooldown()
    {
        StartCoroutine(attackCoolDown());
    }
}
