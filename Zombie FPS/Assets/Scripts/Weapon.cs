using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float Range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] Camera FPCamera;
    [SerializeField] ParticleSystem muzzleflash;
    [SerializeField] GameObject HitEffect;

    [SerializeField] float fireRate = 10f;

    [SerializeField] Ammo ammoSlot;

    float nextTimeToShoot=0f;
    void Update()
    {
        if(Input.GetButton("Fire1")&& nextTimeToShoot <=Time.time )
        {
            nextTimeToShoot = Time.time + 1f/fireRate;
            Shoot();
        }
        else{
            GetComponent<Animator>().SetBool("Fire",false);
        }
    }
    void Shoot()
    {
        if(ammoSlot.GetCurrentAmmo() > 0)
        {
            GetComponent<Animator>().SetBool("Fire",true);
            PlayMuzzleaFlash();
            ProcessRaycast();
            ammoSlot.ReduceAmmo();

        }
    }

    private void PlayMuzzleaFlash()
    {
        muzzleflash.Play();
    }

    
    private void ProcessRaycast()
    {
        RaycastHit Hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out Hit, Range))
        {
            CreateHitImpact(Hit);
            EnemyHealth target = Hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(damage);
        }
        else { return; }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(HitEffect,hit.point,Quaternion.LookRotation(hit.normal));
        Destroy(impact , .1f);

    }
}
