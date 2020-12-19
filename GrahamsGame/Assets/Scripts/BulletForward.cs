using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForward : MonoBehaviour
{

    public float speed;
    public float timeToLive = 2f;
    private float lifetimer;


    // Start is called before the first frame update
    void Start()
    {
        lifetimer = timeToLive;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyBullet();
    }

    void DestroyBullet()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        lifetimer -= Time.deltaTime;
        if (lifetimer < -0)
        {
            Destroy(gameObject);
        }
    }
}
