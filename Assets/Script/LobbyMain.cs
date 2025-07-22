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
    //앱에서 로비로 씬 변환이 되었다고 해고 마스터 서버에 접속을 했을지 안했을지 비동기이기 때문에 확인이 불가능함
    //그래서 동기 방식으로 변환을 하고 싶으면 앱에서 마스터 서버에 접속-> 로비 접속-> 씬 전환 하는 식으로 하면 되긴함
    //그래서 꼼수로는 로비씬을 전환을 하고 다른 버튼을 누를때 1초 정도 로딩바를 보여줘서 로비 로딩이 거의 끝내고 나서
    //실행하게 하면 되게 하는 식으로 하는 방법도 있음
    //네트워크에 상황에 따라 연결이 끊기는 경우도 있음
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
                Debug.Log("방 이름을 입력 해 주세요");
            }
            else
            {
                Debug.Log($"방 이름 {RoomINPUTFIELD.text}");
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
        Debug.Log($"룸 생성 실패 {returnCode} {message}");
    }
    public override void OnCreatedRoom()
    {
        //base.OnCreatedRoom();
        Debug.Log($"룸 생성 성공");
    }
    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();
        Debug.Log($"룸 접속 성공");
        var asyncOperation = SceneManager.LoadSceneAsync("RoomScene");
        asyncOperation.completed += operation =>
        {
            GameObject.FindObjectOfType<RoomMain>().Init();
        };
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        //base.OnJoinRoomFailed(returnCode, message);
        Debug.Log($"룸 접속 실패 {returnCode} {message}");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log($"onroomListUpdate {roomList}");
    }
}
