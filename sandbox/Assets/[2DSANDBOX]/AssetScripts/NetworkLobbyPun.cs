using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkLobbyPun : Photon.PunBehaviour
{
    public static NetworkLobbyPun lobbyInstance = null;
    public List<RoomInfo> roomInfo = new List<RoomInfo>();

    public RectTransform roomListContent;
    public GameObject noRoomText;
    public byte MaximumPlayersInRoom = 2;
    public InputField roomNameInput;
    public GameObject roomInfoObject;
    public GameObject waitingPanel;

    /// <summary>Connect automatically? If false you can set this to true later on or call ConnectUsingSettings in your own scripts.</summary>
    public bool AutoConnect = true;

    public byte Version = 1;

    /// <summary>if we don't want to connect in Start(), we have to "remember" if we called ConnectUsingSettings()</summary>
    private bool ConnectInUpdate = true;


    public void Start()
    {
        lobbyInstance = this;
        PhotonNetwork.autoJoinLobby = true;    // we join randomly. always. no need to join a lobby to get the list of rooms.
        noRoomText.SetActive(true);
        waitingPanel.SetActive(false);
    }

    public void Update()
    {
        if (ConnectInUpdate && AutoConnect && !PhotonNetwork.connected)
        {
            Debug.Log("Update() was called by Unity. Scene is loaded. Let's connect to the Photon Master Server. Calling: PhotonNetwork.ConnectUsingSettings();");

            ConnectInUpdate = false;
            PhotonNetwork.ConnectUsingSettings(Version + "." + SceneManagerHelper.ActiveSceneBuildIndex);
        }
    }


    // below, we implement some callbacks of PUN
    // you can find PUN's callbacks in the class PunBehaviour or in enum PhotonNetworkingMessage


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.automaticallySyncScene = true;
        Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
        //PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby(). This client is connected and does get a room-list, which gets stored as PhotonNetwork.GetRoomList(). This script now calls: PhotonNetwork.JoinRandomRoom();");
        //PhotonNetwork.JoinRandomRoom();
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = MaximumPlayersInRoom }, null);
    }

    // the following methods are implemented to give you some context. re-implement them as needed.

    public override void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.LogError("Cause: " + cause);
    }

    public void JoinRoomClient(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.automaticallySyncScene = true;
        Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");
        //if(PhotonNetwork.isMasterClient)
        //{
        //PhotonNetwork.LoadLevel("MultiplayerTest");
        //}
        waitingPanel.SetActive(true);
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (PhotonNetwork.room.PlayerCount == MaximumPlayersInRoom)
            {
                PhotonNetwork.LoadLevel("MultiplayerTest");
            }
        }
    }

    public void OnMaxPlayerClick(Toggle toggle)
    {
        if(toggle.isOn)
        {
            MaximumPlayersInRoom = byte.Parse(toggle.gameObject.name);
        }
    }

    public void OnCreateRoomButton()
    {
        if(roomNameInput.text!=null)
        {
            PhotonNetwork.CreateRoom(roomNameInput.text, new RoomOptions() { MaxPlayers = MaximumPlayersInRoom }, null);
        }
        else
        {
            PhotonNetwork.CreateRoom("Default" + DataManager.playerName, new RoomOptions() { MaxPlayers = MaximumPlayersInRoom }, null);
        }
    }

    public override void OnReceivedRoomListUpdate()
    {
        if(roomInfo!=null)
        {
            roomInfo.Clear();
        }
        
        foreach (RoomInfo room in PhotonNetwork.GetRoomList())
        {
            roomInfo.Add(room);
            Debug.Log(string.Format("{0} {1}/{2}", room.Name, room.PlayerCount, room.MaxPlayers));
        }
        StartCoroutine(EraseRoomList(roomInfo));
    }

    IEnumerator EraseRoomList(List<RoomInfo> info)
    {
        yield return null;
        foreach(RectTransform child in roomListContent.transform)
        {
            Destroy(child.gameObject);
        }
        StartCoroutine(UpdateRoomList(roomInfo));
    }

    IEnumerator UpdateRoomList(List<RoomInfo> info)
    {
        yield return null;
        if (roomInfo != null && roomInfo.Count > 0)
        {
            noRoomText.SetActive(false);
            Debug.Log("roominfo is not null" + roomInfo.Count);
            foreach (RoomInfo tempInfo in info)
            {
                GameObject temp = Instantiate(roomInfoObject) as GameObject;
                temp.transform.SetParent(roomListContent.transform);
                temp.GetComponent<RoomInfoBarScript>().roomInfo = tempInfo;
                temp.transform.localScale = new Vector3(1, 1, 1);
                yield return null;
                temp.GetComponent<RoomInfoBarScript>().UpdateRoomInfo();
            }
        }
        else
        {
            noRoomText.SetActive(true);
        }
    }
}
