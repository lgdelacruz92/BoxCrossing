
using UnityEngine;
public class ScoreList : MonoBehaviour
{
    public GameObject scoreItemPrefab;

    public Transform scoreListTransform;
    private GameObject[] scores;

    void Start()
    {
        scores = new GameObject[3];
        for (int i = 0; i < 3; i++) {
            scores[i] = Instantiate(scoreItemPrefab, scoreListTransform.position + new Vector3(0, -70 * i, 0), Quaternion.identity);
            scores[i].transform.SetParent(scoreListTransform);
        }
    }
}
