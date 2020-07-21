using SimpleJSON;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScoreList : MonoBehaviour
{
    public GameObject scoreItemPrefab;

    public Transform scoreListTransform;
    private GameObject[] scores;

    private readonly string BOX_CROSSING_GAME_SERVER_URL = "http://ec2-3-23-127-210.us-east-2.compute.amazonaws.com/scores";

    IEnumerator GetScores(string uri)
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
                scores = new GameObject[result.Count];
                for (int i = 0; i < result.Count; i++) {
                    scores[i] = Instantiate(scoreItemPrefab, scoreListTransform.position + new Vector3(0, -70 * i, 0), Quaternion.identity);
                    scores[i].transform.SetParent(scoreListTransform);
                    scores[i].GetComponent<ScoreItem>().name.text = result[i]["data"]["name"];
                    scores[i].GetComponent<ScoreItem>().score.text = result[i]["data"]["score"];
                }
            }
        }
    }

    void Start()
    {
        StartCoroutine(GetScores(BOX_CROSSING_GAME_SERVER_URL));
    }
}
