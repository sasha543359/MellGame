using UnityEngine;
using UnityEngine.Video;

public class ChangeVideoOnCollision : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip newVideoClip1;
    public VideoClip newVideoClip2;
    public VideoClip originalVideoClip;

    private bool isCollidingWithEnemy = false;
    private bool isCollidingWithMellStroy = false;

    private void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponentInChildren<VideoPlayer>();
        }

        if (videoPlayer != null)
        {
            originalVideoClip = videoPlayer.clip;
        }
        else
        {
            Debug.LogError("VideoPlayer component not found on this object or its children.");
        }
    }

    void Update()
    {
        if (!isCollidingWithMellStroy && !isCollidingWithEnemy)
        {
            ChangeVideo(originalVideoClip);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем столкновение с объектом MellStroy
        if (collision.gameObject.CompareTag("MellStroy"))
        {
            isCollidingWithMellStroy = true;
            // Если уже есть столкновение с Enemy, меняем видео на newVideoClip1
            if (isCollidingWithEnemy)
            {
                ChangeVideo(newVideoClip1);
            }
            else
            {
                ChangeVideo(newVideoClip2);
            }
        }

        // Проверяем столкновение с объектом Enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isCollidingWithEnemy = true;
            // Если уже есть столкновение с MellStroy, меняем видео на newVideoClip1
            if (isCollidingWithMellStroy)
            {
                ChangeVideo(newVideoClip2);
            }
            else
            {
                ChangeVideo(newVideoClip1);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // При завершении столкновения с MellStroy
        if (collision.gameObject.CompareTag("MellStroy"))
        {
            isCollidingWithMellStroy = false;
        }

        // При завершении столкновения с Enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isCollidingWithEnemy = false;
        }
    }

    void ChangeVideo(VideoClip videoClip)
    {
        if (videoPlayer != null && videoClip != null)
        {
            videoPlayer.clip = videoClip;
            videoPlayer.Play();
        }
    }
}