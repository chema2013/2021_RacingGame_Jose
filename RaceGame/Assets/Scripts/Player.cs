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
    private IGraphRoot Movement;
    

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
        var graphReference = GraphReference.New(Movement, true);
    }
}
