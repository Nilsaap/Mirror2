﻿using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class networklobbymanagerext : NetworkRoomManager
{
    public TMP_InputField joinIpadress;
    public Text ipadresstext;
    public string address;
    
    public playerchatwindow chatWindow;
    public string PlayerName { get; set; }

    public void host()
    { 

        address = networkAddress;
        //StartServer();
        Debug.Log("Server Has Begun!!!!!");
        StartHost();
    }

    //public class CreatePlayerMessage : MessageBase
    //{
    //    public string name;
    //}

    public override void OnStartServer()
    {
        base.OnStartServer();
        //NetworkServer.RegisterHandler<CreatePlayerMessage>(OnCreatePlayer);
    }
    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        
        // tell the server to create a player with this name
        //conn.Send(new CreatePlayerMessage { name = PlayerName });
    }
    void OnCreatePlayer(NetworkConnection connection)
    {
        // create a gameobject using the name supplied by client
         
        NetworkRoomPlayer playergo = Instantiate(roomPlayerPrefab);
        Debug.Log(playergo.name);
        
        //playergo.GetComponent<networkroomplayerext>().usernamename = createPlayerMessage.name;

        // set it as the player
        NetworkServer.AddPlayerForConnection(connection, playergo.gameObject);
        Debug.Log(roomSlots.Count);

    }

    public override void OnServerSceneChanged(string newSceneName)
    {

        if (newSceneName == RoomScene)
        {
            ipadresstext = GameObject.FindGameObjectWithTag("Ip").GetComponent<Text>();
            ipadresstext.text = address;
        }
    }
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);
        Debug.Log("Hola");
    }

    public void Client()
    {
        //todo: get text for ip adress
        networkAddress = joinIpadress.text;
        StartClient();
    }
    public void Update()
    {
        
        
    }

}
