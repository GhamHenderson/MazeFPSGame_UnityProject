using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public float speed;
    private float dist;
    public float howclose;
    private Transform player;
    Animator zomb;
    public float enemyhealth = 100;
   float lastEnteranceTime = -100f;

    // Start is called before the first frame update
    void Start()
    {
        zomb = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);

        if (dist <= howclose)
        {
            MoveInPlayerDirection();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyDamage();
        }

        if (other.CompareTag("Bullet"))
        {

            if (Time.time - lastEnteranceTime > 10)
            {
                enemyhealth -= 35;
                if (enemyhealth <= 0)
                {
                    enemyhealth = 100;
                    Destroy();

                }
                lastEnteranceTime = Time.time;
            }
        }
    }

    private void ApplyDamage()
    {
        HealthBar.health -= 10;
       
    }

    private void Destroy()
    {
        Object.Destroy(this.gameObject);
    }

    private void MoveInPlayerDirection()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.LookAt(player);
    }


}        
    
