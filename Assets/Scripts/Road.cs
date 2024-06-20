using UnityEngine;

public class Road : MonoBehaviour{
    [SerializeField] private Transform[] PointsForItems;


    private void Start() {
        for(int i = 0; i < PointsForItems.Length; i++) {
            GameObject go = Instantiate(RoadManager.Instance.RandomPart(), PointsForItems[i].position, Quaternion.identity);
            Fill(go.transform);
        }
    }

    public void Fill(Transform tr) {
        int goodOrBad = Random.Range(0, 2);
        GameObject go;

        for (int i = 0; i < tr.childCount; i++) {
            if (goodOrBad == 0) 
                go = ObjectPooler.Instance.SpawnFromPool("bills", tr.GetChild(i).position, Quaternion.identity);
            else
                go = ObjectPooler.Instance.SpawnFromPool("bottle", tr.GetChild(i).position, Quaternion.identity);
        }
    }
}
