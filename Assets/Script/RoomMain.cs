using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class RoomMain : MonoBehaviour
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

    
}
