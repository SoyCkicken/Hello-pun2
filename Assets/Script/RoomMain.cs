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
     * �����Ϳ��� �˷��ִ� ���
     * RPC �޼��带 ����ϴ� ���
        * ���� �� ������Ʈ�� �پ�� ����� �����ؼ� �ϴ� �ٿ��� ����� ����
     * �÷��̾� ������Ƽ ������Ʈ
     * �� ������Ƽ ������Ʈ
     * �̺�Ʈ ���� �����ֱ�
     * 
     */

    public TMP_Text player1NickNameTEXT;
    public TMP_Text player2NickNameTEXT;
    public Button startButton;
    public Button readyButton;
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
            startButton.gameObject.SetActive(true);
            startButton.interactable = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�� ���� Start");
        readyButton.onClick.AddListener(() => {
        //���������� �غ� �Ǿ��ٰ� �˷�����ϰ�
        readyButton.interactable = false;
            GetComponent<PhotonView>().RPC("RPC_OnClickReadyButton", RpcTarget.MasterClient);
        });
        startButton.onClick.AddListener(() => { 
        //�մ��� �غ� �Ǿ� ������ ������ �־�ߵ�
        });
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

        readyButton.gameObject.SetActive(true);
        readyButton.interactable = true;
    }

    [PunRPC]
    public void RPC_OnClickReadyButton(PhotonMessageInfo info)
    {
        Debug.Log($"RPC_OnClickReadyButton �� ���Ƚ��ϴ� sender : {info.Sender.NickName}, sender is Masster = {info.Sender.IsMasterClient}");
    }
}
