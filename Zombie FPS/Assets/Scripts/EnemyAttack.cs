using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void OnDamageTaken()
    {
        Debug.Log(name + "I also know i was attacked");
    }
    public void AttackHitEvent()
    {
        if(target==null) return;
        target.ProcessAttack(damage);
        Debug.Log("Wipe your self up man , you bleeding");
    }
}
