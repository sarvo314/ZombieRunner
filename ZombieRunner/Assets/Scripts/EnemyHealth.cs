using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int hitPoints = 100;
  

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
    }
}
