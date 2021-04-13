using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour {

    public float Speed;

    void Update() {
        PlayerMovement();
    }
    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 PlayerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(PlayerMovement, Space.Self);
    }
}