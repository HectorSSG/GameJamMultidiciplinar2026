using UnityEngine;
using System.Collections;

public class fallObject : MonoBehaviour
{
    [SerializeField] private float responseTime = 0.5f;
    [SerializeField] private float raycastDistance = 3f;
    [SerializeField] private LayerMask playerLayer;
    public DeathManager deathPlayer;

    public Rigidbody objectRB;
    public bool activated = false;
    private void Update()
    {
        if (activated) return;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, playerLayer))
        { 
                activated = true;
                StartCoroutine(ActivateObject());
        }
    }
    IEnumerator ActivateObject() 
    {
        yield return new WaitForSeconds(responseTime);
        objectRB.isKinematic = false;
        objectRB.useGravity = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * raycastDistance);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            deathPlayer.isDeath = true;
        }
    }
}