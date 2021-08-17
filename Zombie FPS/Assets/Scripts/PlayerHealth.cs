using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float HitPoints = 100f;
    DeathHandler deathHandler;

    void Start()
    {
        deathHandler = GetComponent<DeathHandler>();
    }
    public void ProcessAttack(float damage)
    {
        HitPoints-=damage;
        if(HitPoints<=0)
        {
            deathHandler.HandeDeath();
        }
       
    }
}
