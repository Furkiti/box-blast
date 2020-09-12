using UnityEngine;
using System.Collections;
using Main.BaseObject;

public class SmoothMovement : BaseObject
{
    
    private GameObject boxDestPos;
    [SerializeField] private float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        boxDestPos = GameObject.Find("BoxDestPos");
    }
    private void FixedUpdate()
    {

        Vector3 direction = new Vector3(transform.position.x,boxDestPos.transform.position.y,boxDestPos.transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, direction, ref velocity, smoothTime);
    }
}