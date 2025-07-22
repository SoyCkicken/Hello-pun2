using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyMain : MonoBehaviourPunCallbacks
{
    //�ۿ��� �κ�� �� ��ȯ�� �Ǿ��ٰ� �ذ� ������ ������ ������ ������ �������� �񵿱��̱� ������ Ȯ���� �Ұ�����
    //�׷��� ���� ������� ��ȯ�� �ϰ� ������ �ۿ��� ������ ������ ����-> �κ� ����-> �� ��ȯ �ϴ� ������ �ϸ� �Ǳ���
    //�׷��� �ļ��δ� �κ���� ��ȯ�� �ϰ� �ٸ� ��ư�� ������ 1�� ���� �ε��ٸ� �����༭ �κ� �ε��� ���� ������ ����
    //�����ϰ� �ϸ� �ǰ� �ϴ� ������ �ϴ� ����� ����
    //��Ʈ��ũ�� ��Ȳ�� ���� ������ ����� ��쵵 ����
    //

    public TMP_InputField RoomINPUTFIELD;
    public Button createRoom;
    public Button joinRoom;

    public void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        createRoom.onClick.AddListener(() =>
        {
            
            if (string.IsNullOrEmpty(RoomINPUTFIELD.text))
            {
                Debug.Log("�� �̸��� �Է� �� �ּ���");
            }
            else
            {
                Debug.Log($"�� �̸� {RoomINPUTFIELD.text}");
                string room = RoomINPUTFIELD.text;
                RoomOptions options = new RoomOptions {MaxPlayers = 2};
                PhotonNetwork.CreateRoom(room, options);
            }
        });

        joinRoom.onClick.AddListener(() =>
        {
        });
    }
    public void Init()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        //base.OnCreateRoomFailed(returnCode, message);
        Debug.Log($"�� ���� ���� {returnCode} {message}");
    }
    public override void OnCreatedRoom()
    {
        //base.OnCreatedRoom();
        Debug.Log($"�� ���� ����");
    }
    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();
        Debug.Log($"�� ���� ����");
        var asyncOperation = SceneManager.LoadSceneAsync("RoomScene");
        asyncOperation.completed += operation =>
        {
            GameObject.FindObjectOfType<RoomMain>().Init();
        };
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        //base.OnJoinRoomFailed(returnCode, message);
        Debug.Log($"�� ���� ���� {returnCode} {message}");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log($"onroomListUpdate {roomList}");
    }
}
