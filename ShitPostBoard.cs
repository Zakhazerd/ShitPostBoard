﻿
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;



public class ShitPostBoard : UdonSharpBehaviour
{
    private string[] shitPostArray = new string[]
    {
        "Pick a number 1-15. The person who guesses furthest from the number has to strip one article of clothing",
        "Everyone DRINKS!",
        "Describe in detail the last hentai doujin you read or porn video you watched",
        "If you could lewd one person in this room that you haven't before, who would it be?",
        "Group decides what you set your status to tonight",
        "Wild Card\nYou can do or ask whatever",
        "When was the last time you leweded? Top or bottom?",
        "Smolest boobs and largest boobs drink alcohol, Everyone else drinks water",
        "Put a METAL song on",
        "FURRIES OR RANDOS\nAsk everyone who they hate more and the minority drink",
        "Group decides on a dare for you",
        "Group decides on a truth for you",
        "REVERSE UNO\nClothed people strip nude people put on clothes",
        "The person that got this drinks. Everyone else drinks water",
        "Switch into a shitpost avatar unil next turn",
        "You are now hidden in the asylum. Go mute for 5 turns",
        "DEV CARD\nKizzy takes two shots for making me write all these",
        "How much monney is in your bank account? If the group considers you poor drink",
        "Put your FAVORITE song of all time on the video player!",
        "Put some BLACK PEOPLE MUSIC on",
        "What's your favorite fetish weirdo?",
        "Get nakey untul your next turn",
        "The person who got this drinks water everyone else alcohol",
        "Group decides on whose lap you sit on until your next turn",
        "Strip IRL",
        "Rate everyones voices from 1-10",
        "In one word describe everyone in the room",
        "RANDO TUESDAY CARD\nTake a drink if there's someone here that you truely do not know. If you know everyone, then everyone drinks",
        "Suggest a new player for the /vrg/ soccer team",
        "Put a WEEB song on",
        "QUIT HAVING FUN! Lay down until your next turn",
        "Group decides a dare for you",
        "Group decides on a truth for you",
        "Everyone puts on a piece of clothing",
        "Everyone DRINKS!",
        "Hello fellow wanner. End each sentence with wan",
        "Is the video player working? Put on a song!",
        "Play on your knees until next turn",
        "It's Karaoku time! Put on one karaoke song for the group",
        "NEVER HAVE I EVER...\n If you have, take a drink.\nSince i have space to call you a retard they are saying they haven't done something and if you have done that thing you drink you actual monkey brain",
        "Futafaggots get the rope (and have to drink!). If you don't got a cock drink some water you pure angel you",
        "Put a VIDEO GAME song on",
        "SMILE!\nEveryone take a picture of you!",
        "Truth {0}",
        "Play rock paper scissors with {0}. Loser Strips",
        "Order {0} to sit in your lap unit your next turn",
        "Switch avatars with {0}",
        "Dare {0}",
        "Truth {0}",
        "Give {0} a kissu",
        "Dare {0}",
        "Describe a time where you were jerking it to something and it turned into something weird and you said to yourself \"fuck it\" and nutted to it anyway.",
        "What is something you joked about ironically but is now not ironic at all.",
        "When you were a kid, if you made up a playground rumor about video games, what was it. If you never did then what is a playground rumor that you believed in the most.",
        "Did you forget to clean your onahole from night?",
        "Raise your hand if you have a lovense",
        "Send a message to the last person you dm'd that isnt in the instance that you thought they are cute.",
        "Anyone standing drinks",
        "Anyone sitting drinks",
        "Read aloud the last dm you sent",
        "Tits out, pretty self explanatory",
        "Play the first video recommended to you by youtube thats under 5 minutes.",
        "Motorboat the largest tiddies in the instance",
        "Put your head on someones thighs until your next turn",
        "Everyone takes off their shoes and puts their feet in your face",
        "Post a picture of your drink in the thread and caption it \"cheers\" if you aren't drinking post your toilet with the same caption",
        "Change your status to \"whiskey dick\"",
        "Heatpat the closest person with animal ears",
        "Lick the closest elf ears",
        "Couples drink twice",
        "Take a shot if you're single",
        "Drink if you came before coming to this instance",
        "Drink if your tits are smaller than kizzy's",
        "Drink if your tits are bigger than kizzy's",
        "Talk with a girly voice until your next turn",
        "Give {0} a lap dance.",
        "Go to the hotub with {0}",
        "Go upstairs to the bedroom with {0}",
        "What video game would you want to experiance for the first time again",
        "In your opinion, would {0}'s avatar top or bottom",
        "What is the worst model you've made",
        "Would you rather ERP with {0} or {1}",
        "Make {0} or {1} take two drinks",
        "Deman {0} and {1} do something",
    };

    public Text boardText;
    [UdonSynced]
    private string syncString = "";
    [UdonSynced]
    private string playerName;
    [UdonSynced]
    private string playerName2;
    VRCPlayerApi[] worldPlayers = new VRCPlayerApi[81];

    private void Start()
    {
        UpdateBoard();
    }

   
    public void DisplayString()
    {
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        syncString = shitPostArray[Random.Range(0, shitPostArray.Length)];
        playerName = GetName();
        playerName2 = GetName2();
        UpdateBoard();
        RequestSerialization();
    }
    public override void OnDeserialization()
    {
        UpdateBoard();
    }
    public string GetName()
    {

        VRCPlayerApi.GetPlayers(worldPlayers);
        for(int i = 0; i < 10; i++)
        {
            int j = Random.Range(0, VRCPlayerApi.GetPlayerCount());
            if (worldPlayers[j].displayName == Networking.LocalPlayer.displayName)
                continue;
            else
                return worldPlayers[j].displayName;

        }
        return Networking.LocalPlayer.displayName;
    }
    public string GetName2()
    {
        VRCPlayerApi.GetPlayers(worldPlayers);
        for (int i = 0; i < 10; i++)
        {
            int j = Random.Range(0, VRCPlayerApi.GetPlayerCount());
            if (worldPlayers[j].displayName == Networking.LocalPlayer.displayName || worldPlayers[j].displayName == playerName)
                continue;
            else
                return worldPlayers[j].displayName;

        }
        return Networking.LocalPlayer.displayName;
    }
    public void UpdateBoard()
    {
        if(syncString.Contains("{1}"))
            boardText.text = string.Format(syncString, playerName, playerName2);

        else if (syncString.Contains("{0}"))
            boardText.text = string.Format(syncString, playerName);
        else
        boardText.text = syncString;
    }
}
