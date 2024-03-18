using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    public AudioSource audioSource;


    public Vector2 Vector2 = new Vector2(-6.35f, -2.5f);

    public void SpawnPrefab()
    {
        if (prefab != null)
        {
            Instantiate(prefab, Vector2, Quaternion.identity);
            audioSource.Play();
        }
    }
}