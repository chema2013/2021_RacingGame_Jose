using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    //serialize = transforming object state/data into format that can be stored
    [SerializeField] private string VersionName = "0.1";
    [SerializeField] private GameObject UsernameMenu;
    [SerializeField] private GameObject ConnectPanel;

    [SerializeField] private InputField UsernameInput; //entering username
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    [SerializeField] private GameObject PlayButtons;
    [SerializeField] private GameObject MultiplayerMenu;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionName); //connecting to photon servers(?)
    }

    private void Start()
    {
        UsernameMenu.SetActive(true);
        MultiplayerMenu.SetActive(false); //hide multiplayer menu & play buttons (single player & multiplayer)
        PlayButtons.SetActive(false);
    }

    //connecting to photon servers (?)
    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    //USERNAME INPUT
    public void ChangeUserNameInput()
    {   //username input required to play game
        if(UsernameInput.text.Length >= 1) //if minimum 1 letter for username
        {
            PlayButtons.SetActive(true);
        }
        else
        {
            PlayButtons.SetActive(false);
        }
    }

    //setting username & starting game
    public void SetUserName()
    {
        UsernameMenu.SetActive(false);
        PhotonNetwork.playerName = UsernameInput.text;
    }

    //Samuel's part (starting & quitting game)
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void MultiplayerMenuOpen()
    {
        PlayButtons.SetActive(false);
        MultiplayerMenu.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        PlayButtons.SetActive(true);
        MultiplayerMenu.SetActive(false);
        UsernameMenu.SetActive(true);
    }

    //CREATE & JOIN GAMES
    public void CreateGame()
    {
        /*if(CreateGameInput.text == 4)
        {
            return;
        }*/
        PhotonNetwork.CreateRoom(CreateGameInput.text, new RoomOptions() { maxPlayers = 10 }, null);
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 10;
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("ForestMulti"); //loads named scene
    }
}
