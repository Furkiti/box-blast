using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    TextMesh targetValue;
    private float size;
    private String color;
    private int health;

    private void Update()
    {
        targetValue = GetComponentInChildren<TextMesh>();
        targetValue.text = "9";
    }
}
