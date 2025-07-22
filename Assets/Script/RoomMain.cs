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
        Debug.Log("�� ���� AWake");
    }

    public void Init()
    {
        Debug.Log("�� ���� Init ");
        Debug.Log($"��[{PhotonNetwork.LocalPlayer.NickName}]�� �����ΰ�? : {PhotonNetwork.IsMasterClient}");
        if (PhotonNetwork.IsMasterClient == true)
        {
            //�÷��̾� 1�� �־������
            player1NickNameTEXT.text = PhotonNetwork.LocalPlayer.NickName;
        }
        else
        {
            //�÷��̾� 2�� �־����
            player2NickNameTEXT.text = PhotonNetwork.LocalPlayer.NickName;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�� ���� Start");
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //�մ���
        player2NickNameTEXT.text = newPlayer.NickName;
        Debug.Log($"[RoomMain] �ٸ� �÷��̾ �뿡 ���� �߽��ϴ�. : {newPlayer}");
    }

    public override void OnJoinedRoom()
    {
        //����
        Debug.Log($"[RoomMain] �濡 �����߽��ϴ�.");
        Debug.Log($"���̸� : {PhotonNetwork.CurrentRoom.Name}");
        Debug.Log($"�濡�ִ� ����� : {PhotonNetwork.PlayerList.Length}");
        Debug.Log($"����({PhotonNetwork.LocalPlayer.NickName}) �����ΰ�? {PhotonNetwork.IsMasterClient}");

        player2NickNameTEXT.text = PhotonNetwork.NickName;
        player1NickNameTEXT.text = PhotonNetwork.MasterClient.NickName;
    }

}
