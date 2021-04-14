using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UIElements;

public class Character_movement : MonoBehaviour
{
    public float speedX = 2.0f;
    float yaw = 0;
    
    void Update()
    {
        yaw += speedX * Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(0, yaw, 0);
    }
}
