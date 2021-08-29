using UnityEngine;
using UnityEngine.UI;
using MLAPI;
using MLAPI.SceneManagement;
using TMPro;
using MLAPI.Transports.PhotonRealtime;

public class SC_MainMenu : MonoBehaviour {

    void Start () {
        

    }

    #region Online Play
    public GameObject onlinePlayPanel;
    public InputField matchCode;
    public TMP_Dropdown onlineDeckChoice;

    public void Host () {

        Host (onlineDeckChoice);

    }

    void Host (TMP_Dropdown deckC) {

        (NetworkManager.Singleton.NetworkConfig.NetworkTransport as PhotonRealtimeTransport).RoomName = "MadDelivery_" + matchCode.text;
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
        NetworkManager.Singleton.StartHost ();        
        NetworkSceneManager.SwitchScene ("Play_Scene");      

    }

    private void ApprovalCheck (byte[] connectionData, ulong clientId, NetworkManager.ConnectionApprovedDelegate callback) {

        callback (true, null, true, null, null);

    }

    public void Join () {

        Join (onlineDeckChoice);

    }

    void Join (TMP_Dropdown deckC) {

        (NetworkManager.Singleton.NetworkConfig.NetworkTransport as PhotonRealtimeTransport).RoomName = "MadDelivery_" + matchCode.text;
        NetworkManager.Singleton.StartClient ();

    }
    #endregion

}
