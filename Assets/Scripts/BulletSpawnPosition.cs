using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnPosition : MonoBehaviour
{
    [SerializeField]
    private GameObject barrel;

    [SerializeField]
    private float impulseForce;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDir = mousePos - barrel.gameObject.transform.position;
        mouseDir.z = 0.0f;
        mouseDir = mouseDir.normalized;

        Debug.Log(mousePos);
        
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse down");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
                Debug.Log(Input.mousePosition);
        }
    }
}
