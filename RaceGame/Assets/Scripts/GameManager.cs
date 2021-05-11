using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    //public GameObject GameCanvas;
    public GameObject PlayerUI;
    public GameObject SceneCamera;
    public GameObject RespawnPoint;

    private void Awake()
    {
        //GameCanvas.SetActive(true);
        PlayerUI.SetActive(false);
    }

    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-1, 1); //random range where player will spawn
        /*PlayerPrefab.transform.position = RespawnPoint.transform.position;
        PlayerPrefab.transform.rotation = RespawnPoint.transform.rotation;*/

        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(this.transform.position.x * randomValue, this.transform.position.y), Quaternion.identity, 0);
        //GameCanvas.SetActive(false);
        SceneCamera.SetActive(false); //scene camera off when player spawned
        PlayerUI.SetActive(true);
    }
}
