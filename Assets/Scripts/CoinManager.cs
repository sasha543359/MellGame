using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI ����������

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance; // �������� ��� ������� �� ������ ��������

    public int coins = 0; // ��������� ���������� �����
    public TMP_Text coinText; // UI ������� ��� ����������� �����
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
        StartCoroutine(AddCoinsOverTime(coinsPerSecond, 1)); // ������ ������� ��������� x �����
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
            coinText.text = "������: " + coins;
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
