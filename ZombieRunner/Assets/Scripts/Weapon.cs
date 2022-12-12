using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range;
    [SerializeField] int damage = 30;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Ammo ammoSlot;
    bool canShoot;
    [SerializeField] float timeBwShots = 1f;

    //stores the spark effect game object: explosion
    [SerializeField] GameObject hitEffect;
    private void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && ammoSlot.GetCurrentAmmo()>0 && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        canShoot = false;
        PlayMuzzleFlash();
        ProcessRaycast();
        ammoSlot.ReduceCurrentAmmo();
        yield return new WaitForSeconds(timeBwShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        Debug.Log("Muzzle flash played");
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            Debug.Log($"I hit this {hit.transform.name}");
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null)
            {
                return;
            }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject hitEff;
        hitEff = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        //time for which we need the spark to be there 
        var hitEffectTime = 0.1f;
        Destroy(hitEff, hitEffectTime);
    }
}
