using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammo = 30;

    public int GetCurrentAmmo()
    {
        return ammo;
    }
    public void ReduceAmmo()
    {
        ammo--;
    }
}
