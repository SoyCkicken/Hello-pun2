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

    
}
