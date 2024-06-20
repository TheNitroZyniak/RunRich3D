using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour{

    public static RoadManager Instance;

    [SerializeField] GameObject[] ItemsParts;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public GameObject RandomPart() {
        return ItemsParts[Random.Range(0, ItemsParts.Length)];
    }
}
