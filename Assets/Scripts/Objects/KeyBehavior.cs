using UnityEngine;

public class KeyBehavior : MonoBehaviour
{

    [SerializeField] private GameObject key;
    [SerializeField] private GameObject door;
    
    public void ActiveDoor()
    {
        Debug.Log("Se activó la puerta " + gameObject.name);
        door.SetActive(true);
        key.SetActive(false);
    }
}
