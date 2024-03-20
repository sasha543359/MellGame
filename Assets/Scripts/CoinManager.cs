using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Для работы с UI элементами

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance; // Синглтон для доступа из других скриптов

    public int coins = 0; // Начальное количество монет
    public TMP_Text coinText; // UI элемент для отображения монет
    public int coinsPerSecond = 1;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(AddCoinsOverTime(coinsPerSecond, 1)); // Каждую секунду добавляет x монет
    }

    private IEnumerator AddCoinsOverTime(int amount, float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            coins += amount;
            UpdateCoinDisplay();
        }
    }

    public void UpdateCoinDisplay()
    {
        if (coinText != null)
        {
            coinText.text = "Монеты: " + coins;
        }
    }

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            UpdateCoinDisplay();
            return true;
        }
        return false;
    }
}
