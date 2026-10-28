using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject key;
    private void Awake()
    {
        door.SetActive(false);
    }
    public void ActiveDoor()
    {
        Debug.Log("Se activó la puerta " + gameObject.name);
        door.SetActive(true);
        key.SetActive(false);
    }
}
