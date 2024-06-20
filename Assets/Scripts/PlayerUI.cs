using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour{

    public Image coinsSlider;

    private void Start() {
        CoinsManager.instance.onCoinsChange.AddListener(UpdateSlider);
    }

    private void UpdateSlider(int coins) {
        if (!coinsSlider.transform.parent.gameObject.activeInHierarchy)
            coinsSlider.transform.parent.gameObject.SetActive(true);
        coinsSlider.fillAmount = (float)coins / 100f;
    }

    private void OnDestroy() {
        CoinsManager.instance.onCoinsChange.RemoveListener(UpdateSlider);
    }


}
