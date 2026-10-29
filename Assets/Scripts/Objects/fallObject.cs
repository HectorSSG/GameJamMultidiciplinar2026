using UnityEngine;
using System.Collections;

public class fallObject : MonoBehaviour
{
    private float responseTime = 0.2f;
    [SerializeField] private float raycastDistance = 3f;
    [SerializeField] private LayerMask playerLayer;
    public DeathManager deathPlayer;

    public Rigidbody objectRB;
    public bool activated = false;
    public bool damage = true;

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            activated = true;
            StartCoroutine(ActivateObject());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        //{

        //}

        if (collision.gameObject.CompareTag("Player") && damage)
        {
            deathPlayer.isDeath = true;
        }
        if (collision.gameObject.CompareTag("Respawn"))
        {
            damage = false;
        }
    }
}