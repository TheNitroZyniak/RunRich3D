using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour{

    public static UIManager instance;

    public TextMeshProUGUI coinsText;
    [SerializeField] GameObject tutorial;
    [SerializeField] RectTransform hand;


    [SerializeField] GameObject losePopup, victoryPopup;


    private void Awake() {
        if (instance == null) {
            instance = this;
        } 
        else
            Destroy(gameObject);
    }


    private void Start() {
        CoinsManager.instance.onCoinsChange.AddListener(UpdateCoinsText);
        hand.DOLocalMoveX(300, 1).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void UpdateCoinsText(int coins) {
        if (!coinsText.gameObject.activeInHierarchy)
            coinsText.gameObject.SetActive(true);
        if (coins >= 0)
            coinsText.text = coins.ToString();
        else {
            coinsText.text = "0";

        }
    }


    public void OpenLosePopup() {
        losePopup.SetActive(true);
    }


    public void OpenVictoryPopup() {
        victoryPopup.SetActive(true);
    }

    public void DeactivateTutor() {
        tutorial.SetActive(false);
    }

    private void OnDestroy() {
        CoinsManager.instance.onCoinsChange.RemoveListener(UpdateCoinsText);
    }


    public void Restart() {
        ObjectPooler.Instance.DeactivateAll();
        SceneManager.LoadScene(0);
    }
}
