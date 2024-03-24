using UnityEngine;
using UnityEngine.Video;

public class ChangeVideoOnCollision : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip newVideoClip;
    private VideoClip originalVideoClip;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ChangeVideo(newVideoClip);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ChangeVideo(originalVideoClip);
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