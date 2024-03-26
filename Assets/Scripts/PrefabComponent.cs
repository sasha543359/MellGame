using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrefabComponent : MonoBehaviour
{
    public int health = 100;
    public int damage = 20;
    public int spawnCost = 50;
    public float movementSpeed = 5.0f;
    public bool moveRight = true;
    public TMP_Text healthText;

    public AudioSource healthAudioSource;

    private bool isCollidingWithEnemy = false;


    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        healthText.text = "Hp: " + health.ToString();
    }

    private void Move()
    {
        // ���������� ����������� �������� � ����������� �� moveRight
        float moveDirection = moveRight ? 1.0f : -1.0f;
        // ��������� �������� � Rigidbody2D ��� ��������, �������� ������� ������������ ��������
        rb.velocity = new Vector2(moveDirection * movementSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isCollidingWithEnemy)
        {
            isCollidingWithEnemy = true;
            StartCoroutine(DamageOverTime(20, 1f)); // ������ �������� ����, ���� ������ � �������� � ������
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isCollidingWithEnemy = false; // ���������� ��������� �����, ����� ������� ������������
        }
    }

    private IEnumerator DamageOverTime(int damage, float delay)
    {
        while (isCollidingWithEnemy)
        {
            health -= damage; // ������� ����
            healthAudioSource.Play();
            if (health <= 0)
            {
                Destroy(gameObject); // ���������� ������, ���� �������� ������ ��� ����� ����
                break; // ����� �� �����
            }
            yield return new WaitForSeconds(delay); // ��������� ����� ���������� ���������� �����
        }
    }
}