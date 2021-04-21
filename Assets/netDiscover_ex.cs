using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Discovery
{
    public class netDiscover_ex : MonoBehaviour
    {

        public Dictionary<long, ServerResponse> discoveredServers = new Dictionary<long, ServerResponse>();
        public NetworkDiscovery networkDiscovery;
        public networklobbymanagerext networkLobby;

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

        public void discoverServer() {
            discoveredServers.Clear();
            networkDiscovery.StartDiscovery();
        }

        public void host() {
            
            discoveredServers.Clear();
            networkLobby.StartHost();
            networkDiscovery.AdvertiseServer();
        }

        public void server() {
            discoveredServers.Clear();
            networkLobby.StartServer();

            networkDiscovery.AdvertiseServer();
        }


        private void Update()
        {


            if (discoveredServers.Count > 1) {
                Debug.Log("Found " + discoveredServers.Count.ToString() + " severs");

                //UI Setup
                //foreach (ServerResponse info in discoveredServers.Values)
                    //info.EndPoint.Address.ToString()
                     //   Connect(info);


            }
        }

        public void Connect() {
            networkLobby.networkAddress = "172.26.80.1";
            networkLobby.StartClient();

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
        }
    }

}