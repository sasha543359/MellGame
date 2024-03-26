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
        // Определяем направление движения в зависимости от moveRight
        float moveDirection = moveRight ? 1.0f : -1.0f;
        // Применяем скорость к Rigidbody2D для движения, сохраняя текущую вертикальную скорость
        rb.velocity = new Vector2(moveDirection * movementSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isCollidingWithEnemy)
        {
            isCollidingWithEnemy = true;
            StartCoroutine(DamageOverTime(20, 1f)); // начать наносить урон, пока объект в контакте с врагом
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isCollidingWithEnemy = false; // прекратить нанесение урона, когда контакт прекращается
        }
    }

    private IEnumerator DamageOverTime(int damage, float delay)
    {
        while (isCollidingWithEnemy)
        {
            health -= damage; // нанести урон
            healthAudioSource.Play();
            if (health <= 0)
            {
                Destroy(gameObject); // уничтожить объект, если здоровье меньше или равно нулю
                break; // выйти из цикла
            }
            yield return new WaitForSeconds(delay); // подождать перед нанесением следующего урона
        }
    }
}