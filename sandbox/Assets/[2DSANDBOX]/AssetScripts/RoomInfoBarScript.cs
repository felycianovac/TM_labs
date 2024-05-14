using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomInfoBarScript : MonoBehaviour
{
    public Text serverName;
    public Text roomPlayers;
    public Text creatorName;
    public RoomInfo roomInfo;
    public Button joinButton;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	public void UpdateRoomInfo()
    {
        serverName.text = roomInfo.Name;
        roomPlayers.text = roomInfo.PlayerCount + "/" + roomInfo.MaxPlayers;
        creatorName.text = roomInfo.Name;
        if(roomInfo.PlayerCount >= roomInfo.MaxPlayers)
        {
            joinButton.interactable = false;
        }
        else
        {
            joinButton.interactable = true;
        }
	}

    public void OnJoinButtonClicked()
    {
        NetworkLobbyPun.lobbyInstance.JoinRoomClient(roomInfo.Name);
    }
}
