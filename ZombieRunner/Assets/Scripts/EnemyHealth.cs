using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int hitPoints = 100;

    public int GetHealth()
    {
        return hitPoints;
    }
  

    public void TakeDamage(int damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
    }
}
