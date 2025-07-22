using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomMain : MonoBehaviourPunCallbacks
{
    /*
     * 마스터에게 알려주는 방법
     * RPC 메서드를 사용하는 방법
        * 포톤 뷰 컴포넌트가 붙어야 사용이 가능해서 일단 붙여서 사용할 예정
     * 플레이어 프로퍼티 업데이트
     * 룸 프로퍼티 업데이트
     * 이벤트 쏴서 보내주기
     * 
     */

    public TMP_Text player1NickNameTEXT;
    public TMP_Text player2NickNameTEXT;
    public Button startButton;
    public Button readyButton;
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
            startButton.gameObject.SetActive(true);
            startButton.interactable = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("룸 메인 Start");
        readyButton.onClick.AddListener(() => {
        //마스터한테 준비가 되었다고 알려줘야하고
        readyButton.interactable = false;
            GetComponent<PhotonView>().RPC("RPC_OnClickReadyButton", RpcTarget.MasterClient);
        });
        startButton.onClick.AddListener(() => { 
        //손님이 준비가 되어 있을때 눌를수 있어야됨
        });
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

        readyButton.gameObject.SetActive(true);
        readyButton.interactable = true;
    }

    [PunRPC]
    public void RPC_OnClickReadyButton(PhotonMessageInfo info)
    {
        Debug.Log($"RPC_OnClickReadyButton 이 눌렸습니다 sender : {info.Sender.NickName}, sender is Masster = {info.Sender.IsMasterClient}");
    }
}
