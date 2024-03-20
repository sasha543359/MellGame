using UnityEngine;
using UnityEngine.UI;

public class PrefabSpawnerButton : MonoBehaviour
{
    public GameObject prefabToSpawn; // ������, ������� ����� �������� ������
    private Button spawnButton; // ������ ��� ������
    public Vector3 Vector3;

    private void Start()
    {
        spawnButton = GetComponentInChildren<Button>(); // ��������������, ��� ������ �������� �������� ��������
        spawnButton.onClick.AddListener(SpawnPrefab);
    }

    private void Update()
    {
        // ��������� ��������� ������� � ��������� ���������� �����
        int prefabCost = prefabToSpawn.GetComponent<PrefabComponent>().spawnCost;

        // ������������� ���������� �������� ������ � ����������� �� ���������� �����
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
