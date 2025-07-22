using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomMain : MonoBehaviourPunCallbacks
{
    public TMP_Text player1NickNameTEXT;
    public TMP_Text player2NickNameTEXT;
   // public TMP_Text roomNameTEXT;   

    private void Awake()
    {
        Debug.Log("룸 메인 AWake");
    }

    public void Init()
    {
        Debug.Log("룸 메인 Init ");
        Debug.Log($"내[{PhotonNetwork.LocalPlayer.NickName}]가 방장인가? : {PhotonNetwork.IsMasterClient}");
        if (PhotonNetwork.IsMasterClient == true)
        {
            //플레이어 1에 넣어버리고
            player1NickNameTEXT.text = PhotonNetwork.LocalPlayer.NickName;
        }
        else
        {
            //플레이어 2에 넣어버림
            player2NickNameTEXT.text = PhotonNetwork.LocalPlayer.NickName;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("룸 메인 Start");
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //손님임
        player2NickNameTEXT.text = newPlayer.NickName;
        Debug.Log($"[RoomMain] 다른 플레이어가 룸에 입장 했습니다. : {newPlayer}");
    }

    public override void OnJoinedRoom()
    {
        //나임
        Debug.Log($"[RoomMain] 방에 입장했습니다.");
        Debug.Log($"방이름 : {PhotonNetwork.CurrentRoom.Name}");
        Debug.Log($"방에있는 사람들 : {PhotonNetwork.PlayerList.Length}");
        Debug.Log($"내가({PhotonNetwork.LocalPlayer.NickName}) 방장인가? {PhotonNetwork.IsMasterClient}");

        player2NickNameTEXT.text = PhotonNetwork.NickName;
        player1NickNameTEXT.text = PhotonNetwork.MasterClient.NickName;
    }

}
