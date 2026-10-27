using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    public float interactionDistance = 3f;
    private InputAction interactionAction;
    [SerializeField] private LayerMask interactableObject;
    [SerializeField] private GameObject interactionPanel;
    [SerializeField] private GameObject lookObject;


    private void Start()
    {
        interactionAction = transform.parent.GetComponentInParent<PlayerInput>().actions["Interact"];
    }
    private void Update()
    {
        Ray rayUI = new Ray(transform.position, transform.forward);
        RaycastHit hit1;
        if (Physics.Raycast(rayUI, out hit1, interactionDistance, interactableObject))
        {
            if (hit1.collider.gameObject != lookObject)
            {
                lookObject = hit1.collider.gameObject;
            }
            if (interactionPanel != null) interactionPanel.SetActive(true);
        }
        else 
        {
            if (lookObject != null)
            {
                lookObject = null;
            }
            if (interactionPanel != null) interactionPanel.SetActive(false);
        }

            if (interactionAction.WasPressedThisFrame())
            {
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, interactionDistance, interactableObject))
                {
                    interactionPanel.SetActive(true);
                    Interactable objectScript = hit.collider.GetComponent<Interactable>();
                    if (objectScript != null)
                    {
                        objectScript.ActiveObject();
                    }
                }
            }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * interactionDistance);
    }
}