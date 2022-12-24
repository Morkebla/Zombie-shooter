using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;
    [SerializeField] ParticleSystem muzzleFlashVFX;
    [SerializeField] Camera FPSCamera;
    [SerializeField] float range = 100;
    [SerializeField] float damage = 1;
    [SerializeField] Ammunition ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float shootDelay = 0.07f;

    bool canShoot = true;

    void Update()
    {
        if (Input.GetMouseButton(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            RayCastCalculation();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

    private void RayCastCalculation()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth zombie = hit.transform.GetComponent<EnemyHealth>();
            if (zombie == null) { return; }
            zombie.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }
    private void PlayMuzzleFlash()
    {
        muzzleFlashVFX.Play();
    }
    private void CreateHitImpact(RaycastHit hit)
    {
       GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
       Destroy(impact,0.3f);
    }
}
