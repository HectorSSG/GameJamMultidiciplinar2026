using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    public bool canDisappear = true;

    private SpawnObject spawnManager;

    private void Start()
    {
        spawnManager = FindAnyObjectByType<SpawnObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (!canDisappear)
            return;

        spawnManager.ObjectVanished();
    }
}