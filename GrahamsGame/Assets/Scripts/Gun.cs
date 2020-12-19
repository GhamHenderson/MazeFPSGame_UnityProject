using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Camera playerCamera;
    public Animator animatorShoot;
    public float shotVolume;
    public AudioClip clip;
    private AudioSource playerAudio;
    public ParticleSystem MuzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        animatorShoot = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {  
                Shoot();
                animatorShoot.SetBool("Shoot", false);
        }
    }


    void Shoot()
    {
        animatorShoot.SetBool("Shoot", true);
        GameObject bulletObject = Instantiate (bulletPrefab);
        bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
        bulletObject.transform.forward = playerCamera.transform.forward;
        playerAudio.PlayOneShot(clip, shotVolume);
        MuzzleFlash.Play();
    }

    
}

