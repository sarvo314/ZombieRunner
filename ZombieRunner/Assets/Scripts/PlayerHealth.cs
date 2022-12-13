using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]float hitPoints = 1000;
    DeathHandler deathHandle;
    private void Start()
    {
        deathHandle = GetComponent<DeathHandler>();
    }

    public void TakeDamage(float damage)
    {
        if(hitPoints > 0)
        {
            hitPoints -= damage;
            Debug.Log("Hit points of player is" + hitPoints);
        }
        if(hitPoints <= 0)
        {
            Debug.Log("Player is dead");
            deathHandle.HandleDeath();

        }
    }
}
