using UnityEngine;

public class PrefabComponent : MonoBehaviour
{
    public int health = 100; // Здоровье
    public int damage = 20; // Урон
    public int spawnCost = 50; // Цена спавна
    public float movementSpeed = 5.0f; // Скорость движения
    public bool moveRight = true; // Направление движения (true - вправо, false - влево)

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
        // Определяем направление движения в зависимости от moveRight
        float moveDirection = moveRight ? 1.0f : -1.0f;
        // Применяем скорость к Rigidbody2D для движения, сохраняя текущую вертикальную скорость
        rb.velocity = new Vector2(moveDirection * movementSpeed, rb.velocity.y);
    }

    // Метод для получения урона
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    // Метод вызывается, когда здоровье объекта падает до 0
    private void Die()
    {
        Destroy(gameObject); // Уничтожаем объект
    }
}
