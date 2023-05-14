using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    #region _UNITY FUNCTION
    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }
    #endregion

    #region _FUNCTION
    private void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
#if UNITY_EDITOR
        Debug.Log("Try Connect To Server...");
#endif
    }
    #endregion

    #region _OVERRIDE FUNCTION
    public override void OnConnectedToMaster()
    {
#if UNITY_EDITOR
        Debug.Log("Connected To Server.");
#endif
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
#if UNITY_EDITOR
        Debug.Log("Joined a Room");
#endif
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
#if UNITY_EDITOR
        Debug.Log("A new player joined the room");
#endif
        base.OnPlayerEnteredRoom(newPlayer);
    }
    #endregion
}
