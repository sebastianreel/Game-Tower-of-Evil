using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField]
    PlayerMovementActions PA;
    [SerializeField]
    CharacterController CC;
    //[SerializeField]
    //PauseMenu PM;
    [SerializeField]
    private float gravityMultiplier = 1;
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float jumpPower = 5.0f;
    [SerializeField]
    private float velocity = 0.0f;
    [SerializeField]
    private float mouseSensitivity = 100.0f;
    [SerializeField]
    private Camera mCamera;
    #endregion

    #region Private variables
    private Vector2 moveInput;//used to take in Vector2 from controller
    private Vector3 moveDir;//used to apply Vector3 direction
    private Vector2 rotationInput;
    private float verticalRotation = 0.0f;
    private float gravity = -9.81f;
    private int numJumps = 0;
    #endregion

    #region Public variables
    #endregion

    #region Unity Functions
    private void Awake()
    {
        PA = new PlayerMovementActions();
        CC = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        PA.Enable();
        PA.Player.Jump.performed += Jump_performed;
        PA.Player.Start.performed += Start_performed;
    }

    // Update is called once per frame
    void Update()
    {
        applyGravity();
        rotatePlayer();
        movePlayer();
        finishedJump();
    }
    #endregion

    #region Event Listener Functions
    private void Jump_performed(InputAction.CallbackContext obj)
    {
        if (!CC.isGrounded && numJumps > 0) return;
        else
        {
            numJumps ++;
            velocity = jumpPower;
        }
    }

    private void Start_performed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }
    #endregion

    #region movement, rotation, and jump functions
    private void rotatePlayer()
    {
        rotationInput = PA.Player.Look.ReadValue<Vector2>();
        transform.Rotate(0f, rotationInput.x, 0f);
        if(Mathf.Abs(rotationInput.y) > 0.1f)
        {
            verticalRotation -= rotationInput.y * mouseSensitivity * Time.deltaTime;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
            mCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        }
    }
    private void setMoveDirection()
    {
        moveInput = PA.Player.Move.ReadValue<Vector2>();
        moveDir = transform.forward * moveInput.y + transform.right * moveInput.x + transform.up * velocity;
    }

    private void movePlayer()
    {
        setMoveDirection();
        CC.Move(moveDir * speed * Time.deltaTime);
    }

    private void applyGravity()
    {
        if (CC.isGrounded && velocity < 0.0f)
        {
            velocity = -1.0f;
        }
        else
        {
            velocity += gravity * gravityMultiplier * Time.deltaTime;
        }
    }

    private void finishedJump()
    {
        if(numJumps > 0)
        {
            if (CC.isGrounded)
            {
                numJumps = 0;
            }
        }
    }
    #endregion
}
