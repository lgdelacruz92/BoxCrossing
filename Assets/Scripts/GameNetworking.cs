using SimpleJSON;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameNetworking {
    private readonly string BOX_CROSSING_GAME_SERVER_URL = "http://ec2-3-23-127-210.us-east-2.compute.amazonaws.com/scores";

    public static IEnumerator GetScores(string uri, Text text)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                JSONNode result = JSON.Parse(webRequest.downloadHandler.text);
            }
        }
    }
}