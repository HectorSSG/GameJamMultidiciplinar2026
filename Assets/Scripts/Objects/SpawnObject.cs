using System.Collections;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject actualObject;
    public Transform[] spawnPoints;
    public float spawnTime = 0.1f;
    private int actualPoint;
    [SerializeField] private float visibleTime = 1.5f;
    [SerializeField] private bool vanished = false;
    [SerializeField] private AudioSource vanishedEffect;
    [SerializeField] private AudioClip soundVanish;

    private void Start()
    {
        StartCoroutine(appearancePattern());
    }

    IEnumerator appearancePattern()
    {
        while (true)
        {
            GameObject newObject = Instantiate(actualObject, spawnPoints[actualPoint].position, spawnPoints[actualPoint].rotation);

            yield return new
            WaitForSeconds(visibleTime);
            Destroy(newObject);
            vanished = true;
            AudioActive();
            actualPoint++;

            if (actualPoint >= spawnPoints.Length)
            {
                actualPoint = 0;
            }

            yield return new
            WaitForSeconds(spawnTime);
            vanished = false;
        }
    }
    private void AudioActive()
    {
        if (vanished == true)
        {
            vanishedEffect.PlayOneShot(soundVanish);
        }
        else
        {
            vanishedEffect.Stop();
        }
    }
}