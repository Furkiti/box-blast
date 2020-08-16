using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZoneCollider : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collide");
        if (collision.gameObject.tag == "target")
        {
            Destroy(collision.gameObject);
        }
    }

}
