using UnityEngine;
using UnityEngine.Events;

public class CoinsManager : MonoBehaviour {
    public static CoinsManager instance;
    private int coins = 0;
    [HideInInspector]
    public UnityEvent<int> onCoinsChange = new UnityEvent<int>();

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddCoins(int amount) {
        coins += amount;
        onCoinsChange?.Invoke(coins);
        AudioManager.instance.PlaySound(1);
    }

    public void SubtractCoins(int amount) {
        coins -= amount;
        onCoinsChange?.Invoke(coins);
        AudioManager.instance.PlaySound(0);
    }

    public int GetCoins() {
        return coins;
    }
}