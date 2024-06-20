using UnityEngine;

public class RoadManager : MonoBehaviour{

    public static RoadManager Instance;

    [SerializeField] private GameObject[] ItemsParts;

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
