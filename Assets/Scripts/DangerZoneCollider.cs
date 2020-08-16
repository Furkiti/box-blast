using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZoneCollider : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "target")
        {
            Destroy(other.gameObject);
        }
    }
}
