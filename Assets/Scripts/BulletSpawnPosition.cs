using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnPosition : MonoBehaviour
{
    [SerializeField]
    private GameObject barrel;

    [SerializeField]
    private float impulseForce;

    public Vector3 calculateSpawnDirection()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDir = mousePos - barrel.gameObject.transform.position;
        mouseDir.z = 0.0f;
        mouseDir = mouseDir.normalized;

        Debug.Log(mousePos);


        
            Debug.Log("mouse down");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
                Debug.Log(Input.mousePosition);

        return new Vector3();
    }
}
