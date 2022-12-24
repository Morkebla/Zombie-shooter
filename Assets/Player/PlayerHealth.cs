using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float Health = 100;
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
