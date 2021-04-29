using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mirror.Discovery
{
    public class netDiscover_ex : MonoBehaviour
    {

        public Dictionary<long, ServerResponse> discoveredServers = new Dictionary<long, ServerResponse>();
        public NetworkDiscovery networkDiscovery;
        public networklobbymanagerext networkLobby;

        public Transform serverList;
        public GameObject ConnectionObj;
        public GameObject Panel;
        public GameObject LobbyPanel;

#if UNITY_EDITOR
        void OnValidate()
        {
            if (networkDiscovery == null)
            {
                networkDiscovery = GetComponent<NetworkDiscovery>();
                UnityEditor.Events.UnityEventTools.AddPersistentListener(networkDiscovery.OnServerFound, OnDiscoveredServer);
                UnityEditor.Undo.RecordObjects(new Object[] { this, networkDiscovery }, "Set NetworkDiscovery");
            }
        }
#endif

        public void discoverServer()
        {
            discoveredServers.Clear();

            foreach (Transform child in serverList)
            {
                Destroy(child.gameObject);
            }
            networkDiscovery.StartDiscovery();
        }

        public void host()
        {

            discoveredServers.Clear();
            networkLobby.StartHost();
            networkDiscovery.AdvertiseServer();
        }

        public void server()
        {
            discoveredServers.Clear();
            networkLobby.StartServer();

            networkDiscovery.AdvertiseServer();

        }


        private void Update()
        {


            if (discoveredServers.Count > 1)
            {
                Debug.Log("Found " + discoveredServers.Count.ToString() + " severs");


                //UI Setup



            }
        }

        public void Connect(ServerResponse information)
        {
            //networkLobby.networkAddress = "172.26.80.1";
            //networkLobby.networkAddress = "23.241.6.7";
            Panel.SetActive(false);
            LobbyPanel.SetActive(true);
            //networkLobby.StartClient();
            networkLobby.StartClient(information.uri);

            //if (discoveredServers.Count > 1)
            //{
            //    networkLobby.networkAddress = "172.26.80.1";
            //networkLobby.StartClient(discoveredServers[0].uri);
            //    networkLobby.StartClient();
            //}
            //else {
            //    Debug.Log("No server found");
            //}
        }

        public void OnDiscoveredServer(ServerResponse info)
        {
            // Note that you can check the versioning to decide if you can connect to the server or not using this method
            discoveredServers[info.serverId] = info;

            if (GameObject.Find("Server_" + info.serverId.ToString()) == null)
            {

                GameObject newConnectionString = Instantiate(ConnectionObj, serverList);
                newConnectionString.name = "Server_" + info.serverId.ToString();
                newConnectionString.GetComponentInChildren<Text>().text = "Server_" + info.serverId.ToString() + "_" + info.EndPoint.Address.ToString();
                newConnectionString.GetComponentInChildren<Button>().onClick.AddListener(delegate { Connect(info); });
            }
        }
    }

}