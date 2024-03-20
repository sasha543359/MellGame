using UnityEngine;
using UnityEngine.UI;

public class PrefabSpawnerButton : MonoBehaviour
{
    public GameObject prefabToSpawn; // Префаб, который будет спавнить кнопка
    private Button spawnButton; // Кнопка для спавна
    public Vector3 Vector3;

    private void Start()
    {
        spawnButton = GetComponentInChildren<Button>(); // Предполагается, что кнопка является дочерним объектом
        spawnButton.onClick.AddListener(SpawnPrefab);
    }

    private void Update()
    {
        // Проверяем стоимость префаба и доступное количество монет
        int prefabCost = prefabToSpawn.GetComponent<PrefabComponent>().spawnCost;

        // Устанавливаем активность дочерней кнопки в зависимости от количества монет
        spawnButton.gameObject.SetActive(CoinManager.Instance.coins >= prefabCost);
    }

    private void SpawnPrefab()
    {
        int prefabCost = prefabToSpawn.GetComponent<PrefabComponent>().spawnCost;

        if (CoinManager.Instance.SpendCoins(prefabCost))
        {
            Instantiate(prefabToSpawn, Vector3, Quaternion.identity);
        }
    }
}
