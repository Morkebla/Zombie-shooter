using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] int ammoAmount = 30;
    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        { 
            other.GetComponent<Ammunition>().IncreaseCurrentAmmo(ammoType,ammoAmount);
            //FindObjectOfType<Ammunition>().IncreaseCurrentAmmo(ammoType,ammoAmount);
            Debug.Log(" you have picked up ammo");
            Destroy(gameObject);
        }
    }
}
