using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using TMPro;

public class AlliSpawn : MonoBehaviour
{
    public TMP_Text buttonText;
    public float cooldownTime = 5f;
    public string textButton = string.Empty;
    public GameObject prefabToSpawn; // Префаб, который будет спавнить кнопка
    public Button spawnButton; // Кнопка для спавна
    public Vector3 Vector3;

    private float timeLeft;

    void Start()
    {
        spawnButton = GetComponentInChildren<Button>();
        if (buttonText == null)
        {
            buttonText = spawnButton.GetComponentInChildren<TMP_Text>();
        }
    }

    public void OnButtonClick()
    {
        var prefabCost = prefabToSpawn.GetComponent<PrefabComponent>().spawnCost;

        if (CoinManager.Instance.SpendCoins(prefabCost))
        {
            Instantiate(prefabToSpawn, Vector3, Quaternion.identity);
            StartCoroutine(Cooldown());
        }

    }

    private IEnumerator Cooldown()
    {
        timeLeft = cooldownTime;
        spawnButton.interactable = false;

        while (timeLeft > 0)
        {
            buttonText.text = $"{Mathf.CeilToInt(timeLeft)}";
            yield return new WaitForSeconds(1f);
            timeLeft -= 1f;
        }

        buttonText.text = textButton;
        spawnButton.interactable = true;
    }

}