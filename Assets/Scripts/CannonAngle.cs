using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Main.BaseObject;

public class CannonAngle : BaseObject
{

    [SerializeField] private GameObject cannonPivotPos;

    [SerializeField] private float mouseSens = 100f;
    [SerializeField] private float minRot = -46f;
    [SerializeField] private float maxRot = 46f;

    Rect topLeft = new Rect(0, 290, Screen.width, Screen.height);

    private void FixedUpdate()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;    
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, minRot, maxRot);
        Quaternion rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, mouseSens * Time.deltaTime);
        //transform.localRotation = Quaternion.Slerp(transform.rotation, rotation, mouseSens * Time.deltaTime);

        if (topLeft.Contains(Input.mousePosition))
        {
            cannonPivotPos.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, mouseSens * Time.deltaTime);
        }
        
        
    }
    
        
}