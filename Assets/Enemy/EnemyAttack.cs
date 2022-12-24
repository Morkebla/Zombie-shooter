using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float healthLoss = 40f;
    PlayerHealth playerHealth;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        target.TakeDamage(healthLoss);
        if (target == null) return;
        Debug.Log("bang bang");
    }

}
