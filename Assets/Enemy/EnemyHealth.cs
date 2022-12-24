using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float currentHealth = 4;
    Animator animator;
    bool isDead = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
           die();
        }
    }
    private void die()
    {
        if (!isDead == false) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
