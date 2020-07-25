using SimpleJSON;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameNetworking
{
    private static readonly string BOX_CROSSING_GAME_SERVER_URL = "http://ec2-3-23-127-210.us-east-2.compute.amazonaws.com";
    // private static readonly string BOX_CROSSING_GAME_SERVER_URL = "http://localhost:80";

    public static IEnumerator GetScores(Action<JSONNode> onSuccess, Action onError)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(BOX_CROSSING_GAME_SERVER_URL + "/scores"))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = BOX_CROSSING_GAME_SERVER_URL.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                JSONNode result = JSON.Parse(webRequest.downloadHandler.text);
                onSuccess(result);
            }
        }
    }

    public static IEnumerator SaveScore(string name, int score, Action onSucces, Action<NetworkingError> onError)
    {
        if (name == "")
        {
            onError(new NetworkingError(NetworkingErrorCode.NAME_IS_EMPTY, "Error: name can't be empty."));
        }
        else
        {
            WWWForm postData = new WWWForm();
            postData.AddField("name", name);
            postData.AddField("score", score);

            string bodyData = JsonUtility.ToJson(postData);

            using (UnityWebRequest webRequest = UnityWebRequest.Post(BOX_CROSSING_GAME_SERVER_URL + "/setscore", postData))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                string[] pages = BOX_CROSSING_GAME_SERVER_URL.Split('/');
                int page = pages.Length - 1;


                if (webRequest.isNetworkError)
                {
                    Debug.Log(pages[page] + ": Error: " + webRequest.error);
                    onError(new NetworkingError(NetworkingErrorCode.NETWORK_ERROR, "Error in network: please double check you have internet connection."));
                }
                else
                {
                    string result = webRequest.downloadHandler.text;
                    Debug.Log(result);
                    onSucces();
                }
            }
        }


    }
}