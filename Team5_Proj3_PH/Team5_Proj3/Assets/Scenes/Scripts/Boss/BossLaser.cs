using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [SerializeField] GameObject laserTop;
    [SerializeField] GameObject laserBot;

    [SerializeField] GameObject warningTop;
    [SerializeField] GameObject warningBot;

    [SerializeField] Transform bTop;
    [SerializeField] Transform bBot;

    [SerializeField] Transform BarTop;
    [SerializeField] Transform BarBot;

    [SerializeField] float laserTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void determineLane()
    {
        GameObject laser;
        GameObject warning;
        int random = Random.Range(1, 3);
        if(random == 1)
        {
            laser = laserTop;
            warning = warningTop;
        }
        else
        {
            laser = laserBot;
            warning = warningBot;
        }
        StartCoroutine(warningLaser(laser, warning));
        
    }
    private IEnumerator warningLaser(GameObject Laser, GameObject warning)
    {
        warning.SetActive(true);
        yield return new WaitForSeconds(3f);
        warning.SetActive(false);
        Laser.SetActive(true);
        StartCoroutine(laserDuration(Laser, warning));

    }
    private IEnumerator laserDuration(GameObject laser, GameObject warning)
    {
        yield return new WaitForSeconds(laserTime);
        laser.SetActive(false);
        gameObject.GetComponent<DetermineAttack>().cooldown();
    }
   
}
