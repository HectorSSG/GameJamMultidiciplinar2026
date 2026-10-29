using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Jugador")]
    private float playerSpeed = 5f;
    private Rigidbody playerRB;
    private InputAction moveAction;
    private InputAction sprintAction;

    [Header("Camara")]
    [SerializeField] private Transform cameraTransform;
    public float sensitivity = 0.1f;
    private InputAction lookAction;
    public float rotationX = 0f;
    public AudioSource runEffect;
    public AudioSource walkEffect;
    public AudioClip run;
    public AudioClip walk;

    private void Start()
    {
        var playerInput = GetComponent<PlayerInput>();
        playerRB = GetComponent<Rigidbody>();
        moveAction = GetComponent<PlayerInput>().actions["Move"];
        sprintAction = GetComponent<PlayerInput>().actions["Sprint"];
        lookAction = GetComponent<PlayerInput>().actions["Look"];

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


    }
    private void Update()
    {
        Vector2 mouseInput = lookAction.ReadValue<Vector2>() * sensitivity;
        transform.Rotate(Vector3.up * mouseInput.x);
        rotationX -= mouseInput.y;
        rotationX = Math.Clamp(rotationX, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        if (moveAction.WasPressedThisFrame())
        {
            Invoke(nameof(OnWalkState), 0f);
        }
        else if (sprintAction.IsPressed())
        {
            Invoke(nameof(OnRunState), 0f);
        }
        if (moveAction.WasReleasedThisFrame() || sprintAction.WasReleasedThisFrame())
        {
            walkEffect.Stop();
        }
    }
    private void FixedUpdate()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        float actualSpeed = sprintAction.IsPressed() ? (playerSpeed * 2f) : playerSpeed;
        Vector3 direction = (transform.forward * input.y) + (transform.right * input.x);
        playerRB.linearVelocity = new Vector3(direction.x * actualSpeed, playerRB.linearVelocity.y, direction.z * actualSpeed);
    }
    void OnRunState()
    {
        runEffect.Stop();
        walkEffect.clip = run;
        walkEffect.Play();
    }
    void OnWalkState()
    {
        walkEffect.Stop();
        walkEffect.clip = walk;
        walkEffect.Play();
    }
}