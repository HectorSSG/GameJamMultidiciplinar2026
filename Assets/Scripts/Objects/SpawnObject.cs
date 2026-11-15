using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject actualObject;
    public Transform[] spawnPoints;

    [SerializeField] private AudioSource vanishedEffect;
    [SerializeField] private AudioClip soundVanish;

    private int actualPoint = 0;
    private int disappearCount = 0;

    private GameObject newObject;

    private void Start()
    {
        Spawn();
    }

    public void ObjectVanished()
    {
        if (disappearCount >= 9)
            return;

        disappearCount++;

        vanishedEffect.PlayOneShot(soundVanish);

        Destroy(newObject);

        actualPoint++;

        if (actualPoint >= spawnPoints.Length)
            actualPoint = 0;

        Spawn();
    }

    private void Spawn()
    {
        newObject = Instantiate(actualObject, spawnPoints[actualPoint].position, spawnPoints[actualPoint].rotation);

        newObject.GetComponent<ObjectTrigger>().canDisappear = disappearCount < 9;
    }
}