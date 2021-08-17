using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float HitPoints = 100f;


    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        HitPoints-=damage;
        if(HitPoints<=0)
        {
            Destroy(gameObject);
        }
        
    }
}
