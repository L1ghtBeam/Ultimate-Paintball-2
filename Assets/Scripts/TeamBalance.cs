using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking ;
 
public class TeamBalance : MonoBehaviour {
    public static TeamBalance instance;
    public NetworkManager matchSettings;
    public delegate void OnPlayerKilledCallback(string player, string action, string source);
    public OnPlayerKilledCallback onPlayerKilledCallback;
    public static int bears;
    public static int cats;
    public static int playersNumber;
 
 
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }
 
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one manager in the scene.");
        }
        else
        {
            instance = this;
        }
 
    }
    private const string PLAYER_ID_PREFIX = "Player ";
 
 
    private static Dictionary<string, NetworkManager> players = new Dictionary<string, NetworkManager>();
 
    public static void RegisterPlayer(string netId, NetworkManager player)
    {
        string playerId = PLAYER_ID_PREFIX + netId;
 
        players.Add(playerId, player);
 
        player.transform.name = playerId;
    }
 
    public static void UnRegisterPlayer(string playerId)
    {
        players.Remove(playerId);
    }
 
    public static NetworkManager GetPlayer(string playerId)
    {
        return players[playerId];
    }
}