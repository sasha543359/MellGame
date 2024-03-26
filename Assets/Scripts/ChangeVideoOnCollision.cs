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
        // ��������� ������������ � �������� MellStroy
        if (collision.gameObject.CompareTag("MellStroy"))
        {
            isCollidingWithMellStroy = true;
            // ���� ��� ���� ������������ � Enemy, ������ ����� �� newVideoClip1
            if (isCollidingWithEnemy)
            {
                ChangeVideo(newVideoClip1);
            }
            else
            {
                ChangeVideo(newVideoClip2);
            }
        }

        // ��������� ������������ � �������� Enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isCollidingWithEnemy = true;
            // ���� ��� ���� ������������ � MellStroy, ������ ����� �� newVideoClip1
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
        // ��� ���������� ������������ � MellStroy
        if (collision.gameObject.CompareTag("MellStroy"))
        {
            isCollidingWithMellStroy = false;
        }

        // ��� ���������� ������������ � Enemy
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