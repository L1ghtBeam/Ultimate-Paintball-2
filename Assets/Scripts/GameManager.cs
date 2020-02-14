using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private const string PLAYERIDPREFIX = "Player ";

    private static Dictionary<string, PlayerNetwork> players = new Dictionary<string, PlayerNetwork>();

    public static void RegisterPlayer(string netID, PlayerNetwork playerNetwork)
    {
        string playerID = PLAYERIDPREFIX + netID;
        players.Add(playerID, playerNetwork);
        playerNetwork.transform.name = playerID;
    }

    public static void UnRegisterPlayer(string playerID)
    {
        players.Remove(playerID);
    }

    public static PlayerNetwork GetPlayer(string playerID)
    {
        return players[playerID];
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(200, 200, 200, 500));
        GUILayout.BeginVertical();

        foreach (string _playerID in players.Keys)
        {
            GUILayout.Label(_playerID + " - " + players[_playerID].transform.name);
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
