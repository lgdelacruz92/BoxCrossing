using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour
{
    public Text scoreFeedback;
    public GameObject roadPrefab;
    public GameObject vehiclePrefab;

    private List<GameObject> roadDictionary;

    private readonly int roadSize = 10;

    void Start()
    {
        Vector3 startPos = new Vector3(0, -5.5f, 2);
        roadDictionary = new List<GameObject>();
        for (int i = 0; i < roadSize; i++) {
            GameObject road = Instantiate(roadPrefab, startPos + new Vector3(0, 0, i * 2), Quaternion.identity);
            road.GetComponent<MeshRenderer>().material.color = ColorUtils.RandomColor();
            roadDictionary.Add(road);
        }
    }
}
