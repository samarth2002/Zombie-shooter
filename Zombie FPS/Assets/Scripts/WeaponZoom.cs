using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] int ZoomedOut = 60;
    [SerializeField] int ZoomedIn = 30;
    [SerializeField] Camera camfov;
    RigidbodyFirstPersonController sens;

    [SerializeField] float ZoomedoutSens=2f;
    [SerializeField] float ZoomedinSens =0.5f;
    bool Zoom;

    void Start()
    {
        sens = GetComponent<RigidbodyFirstPersonController>();
    }
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            if(!Zoom)
            {
                Zoom = true;
                camfov.fieldOfView = ZoomedIn;
                sens.mouseLook.XSensitivity = ZoomedinSens;
                sens.mouseLook.YSensitivity = ZoomedinSens;
            }
           
        }
        else
        {
            Zoom = false;
            camfov.fieldOfView = ZoomedOut;
            
                sens.mouseLook.XSensitivity = ZoomedoutSens;
                sens.mouseLook.YSensitivity = ZoomedoutSens;
        }
    }
}
