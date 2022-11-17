using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] ParticleSystem fire;
    [SerializeField] ParticleSystem smoke;
    [SerializeField] MeshRenderer missile;
    [SerializeField] CapsuleCollider cp;


    private Vector3 shootDir;

    private DetermineAttack DA;
    private BossMissile BM;
    // Start is called before the first frame update
    void Start()
    {
        DA = GameObject.FindWithTag("Boss").GetComponent<DetermineAttack>();
        BM = GameObject.FindWithTag("Boss").GetComponent<BossMissile>();
        fire.Play();
        smoke.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }
    public void Setup(Vector3 shootDir)
    {
        this.shootDir = shootDir;
        //transform.eulerAngles = new Vector3(rotation.x, rotation.y, 90);
        
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cp.enabled = false;
            other.GetComponent<PlayerHealth>().damagePlayer();
            print("Exploded");
            StartCoroutine(explosion());
        }
        else
        {
            cp.enabled = false;
            StartCoroutine(explosion());
        }
    }
    private IEnumerator explosion()
    {
        DA.cooldown();
        missile.enabled = false;


        yield return new WaitForSeconds(1f);
        BM.Target.SetActive(false);
        Destroy(this.gameObject);
    }
}
