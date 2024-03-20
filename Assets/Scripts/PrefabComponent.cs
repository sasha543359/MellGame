using UnityEngine;

public class PrefabComponent : MonoBehaviour
{
    public int health = 100; // ��������
    public int damage = 20; // ����
    public int spawnCost = 50; // ���� ������
    public float movementSpeed = 5.0f; // �������� ��������
    public bool moveRight = true; // ����������� �������� (true - ������, false - �����)

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // ���������� ����������� �������� � ����������� �� moveRight
        float moveDirection = moveRight ? 1.0f : -1.0f;
        // ��������� �������� � Rigidbody2D ��� ��������, �������� ������� ������������ ��������
        rb.velocity = new Vector2(moveDirection * movementSpeed, rb.velocity.y);
    }

    // ����� ��� ��������� �����
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    // ����� ����������, ����� �������� ������� ������ �� 0
    private void Die()
    {
        Destroy(gameObject); // ���������� ������
    }
}
