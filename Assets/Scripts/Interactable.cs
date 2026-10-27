using UnityEngine;

public class Interactable : MonoBehaviour
{
    public void ActiveObject()
    {
        Debug.Log("Raycast leído" + gameObject.name); //Me dio pereza dibujar gizmos
    }
}
