using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Bolt;
using Ludiq;

public class Player : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public GameObject PlayerCamera;
    public Text PlayerNameText; //to show username
    

    private void Awake()
    {
        if(photonView.isMine) //applies to local player, not everyone in game
        {
            PlayerCamera.SetActive(true);
        }
    }

    private void Update()
    {
        if(photonView.isMine)
        {
            CheckInput(); //checking for player input
        }
    }

    private void CheckInput()
    {
        //transform.position
        if (Input.GetKey(KeyCode.W))
            CustomEvent.Trigger(gameObject, "WPressNetwork");

        if (Input.GetKey(KeyCode.S))
            CustomEvent.Trigger(gameObject, "SPressNetwork");

        if (Input.GetKey(KeyCode.Space))
            CustomEvent.Trigger(gameObject, "SpacePressNetwork");

        if (Input.GetKey(KeyCode.A))
            CustomEvent.Trigger(gameObject, "APressNetwork");

        if (Input.GetKey(KeyCode.S))
            CustomEvent.Trigger(gameObject, "DPressNetwork");
    }
}
