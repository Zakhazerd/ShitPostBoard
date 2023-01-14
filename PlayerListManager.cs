
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using System.Collections;
using System;


public class PlayerListManager : UdonSharpBehaviour
{
    public Text boardText;
    string[] playerList = new string[81];
    VRCPlayerApi[] worldPlayers = new VRCPlayerApi[81];
    string richText = "<color=#FF0000FF>{0}</color>";
    [UdonSynced]
    public int currentPlayer = 0;
    [UdonSynced]
    string boardString;

    private void Start()
    {
        if (Networking.IsOwner(gameObject))
            UpdatePlayerList();
        else
            UpdateBoard();
    }
    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        UpdatePlayerList();
    }
    public override void OnPlayerLeft(VRCPlayerApi player)
    {
        for (int i = 0; i < VRCPlayerApi.GetPlayerCount(); i++)
        {
            if (worldPlayers[i] == player && currentPlayer > i)
            {
                currentPlayer--;
                break;
            }
        }
        SendCustomEventDelayedFrames("UpdatePlayerList", 0, VRC.Udon.Common.Enums.EventTiming.Update);

    }


    public void UpdatePlayerList()
    {
        if (Networking.IsOwner(gameObject))
        {
            VRCPlayerApi.GetPlayers(worldPlayers);
            for (int i = 0; i < VRCPlayerApi.GetPlayerCount(); i++)
            {
                playerList[i] = worldPlayers[i].displayName;
            }
            currentPlayer = currentPlayer % VRCPlayerApi.GetPlayerCount();
            int temp1 = currentPlayer - 1;
            if (temp1 < 0)
            {
                temp1 = temp1 + VRCPlayerApi.GetPlayerCount();
            }
            int temp2 = currentPlayer + 1;
            temp2 = temp2 % VRCPlayerApi.GetPlayerCount();
            boardString = "";
            boardString = string.Concat(boardString, playerList[temp1] + "\n");
            boardString = string.Concat(boardString, string.Format(richText, playerList[currentPlayer]) + "\n");
            boardString = string.Concat(boardString, playerList[temp2] + "\n");
            UpdateBoard();
            RequestSerialization();
        }
    }
    public void NextPlayer()
    {
        currentPlayer++;
        currentPlayer = currentPlayer % VRCPlayerApi.GetPlayerCount();
        UpdatePlayerList();
        
    }
    public override void OnDeserialization()
    {
        UpdateBoard();
    }
    public void UpdateBoard()
    {
        
        boardText.text = boardString;

    }


}