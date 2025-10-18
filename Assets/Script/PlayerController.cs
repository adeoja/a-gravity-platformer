using System;
using System.Collections.Generic;
using UnityEngine;

// Main player controller managing character movement, state transitions, and gravity mechanics.
public class PlayerController : MonoBehaviour
{
    
    // Implements a finite state machine for clean state management and supports unique gravity-flip gameplay
    private enum PlayerState
    {
        Idle,
        Run,
        Jump,
        GravityAbility,
        OnCeiling
    };
    
    private PlayerState currentState;

    [Header("Player Movement")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityForce;
    
    private Rigidbody rb;
    private Animator anim;
    
    [SerializeField] private Transform characterTransform;
    [SerializeField] private Transform cameraTransform;
    
    [Header("Bullet Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpawnDistance;
    [SerializeField] private float bulletSpawnHeight;
    [SerializeField] private float fireBulletCooldown;
    private float nextFireTime;
    
    [SerializeField] private MovingPlatform triggerPlatform;
    
    // state tracking variables
    private bool isGrounded = true;
    private bool onCeilingWithGravity;
    private bool touchingCeiling;
    private bool abilityActive;
    private float xInput;
    private float yInput;
    private bool isRunning;
    private bool jumpPressed;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        
        ChangeState(PlayerState.Idle);
    }

    private void Update()
    {
        CheckStateTransition();
        
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Z))
        {
            abilityActive = !abilityActive;
            print("Ability Status: " + abilityActive);
        }
        
        // adjust player rotation based on camera
        transform.eulerAngles = new Vector3(0, cameraTransform.eulerAngles.y, 0);
        
        if(Input.GetKeyDown(KeyCode.Space) && onCeilingWithGravity && touchingCeiling)
            jumpPressed = true;
        
        FireBullet();
    }

    

    private void FixedUpdate()
    {
        HandleStateLogic();
    }

    private void ChangeState(PlayerState newState)
    {
        if (currentState == newState) return;
        ExitState();
        currentState = newState;
        EnterState(currentState);
        print("State: " + currentState);
    }

    private void HandleStateLogic()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                HandleIdleLogic();
                break;
            case PlayerState.Run:
                HandleRunLogic();
                break;
            case PlayerState.Jump:
                HandleJumpLogic();
                break;
            case PlayerState.GravityAbility:
                HandleGravityAbilityLogic();
                break;
            case PlayerState.OnCeiling:
                HandleOnCeilingLogic();
                break;
        }
    }

    private void CheckStateTransition()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                if((xInput != 0 || yInput != 0) && isGrounded)
                    ChangeState(PlayerState.Run);
                if(isGrounded && Input.GetKeyDown(KeyCode.Space))
                    ChangeState(PlayerState.Jump);
                if(abilityActive)
                    ChangeState(PlayerState.GravityAbility);
                break;
            
            case PlayerState.Run:
                if(xInput == 0 && yInput == 0 && !abilityActive && isGrounded)
                    ChangeState(PlayerState.Idle);
                if(isGrounded && Input.GetKeyDown(KeyCode.Space))
                    ChangeState(PlayerState.Jump);
                if(abilityActive)
                    ChangeState(PlayerState.GravityAbility);
                break;
            
            case PlayerState.Jump:
                if(xInput == 0 && yInput == 0 && !abilityActive && isGrounded)
                    ChangeState(PlayerState.Idle);
                if((xInput != 0 || yInput != 0) && isGrounded && rb.linearVelocity.y <= 0)
                    ChangeState(PlayerState.Run);
                if(abilityActive)
                    ChangeState(PlayerState.GravityAbility);
                break;
            
            case PlayerState.GravityAbility:
                if(!abilityActive && !isGrounded)
                    ChangeState(PlayerState.Jump);
                else if(!abilityActive && isGrounded && xInput != 0 && yInput != 0)
                    ChangeState(PlayerState.Run);
                else if(!abilityActive && isGrounded && xInput == 0 && yInput == 0)
                    ChangeState(PlayerState.Idle);
                else if(abilityActive && onCeilingWithGravity)
                    ChangeState(PlayerState.OnCeiling);
                break;
            
            case PlayerState.OnCeiling:
                if(!abilityActive && !isGrounded)
                    ChangeState(PlayerState.Jump);
                break;
            
            
        }
    }

    private void EnterState(PlayerState newState) // called once when entering a new state
    {
        switch (newState)
        {
            case PlayerState.Idle: 
                break;
            case PlayerState.Run:
                anim.SetBool("isRunning", true);
                break;
            case PlayerState.Jump:
                anim.SetTrigger("jump");
                characterTransform.localScale = new Vector3(1, 1, 1);
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
                isGrounded = false;
                break;
            case PlayerState.GravityAbility:
                anim.SetTrigger("jump");
                break;
            case PlayerState.OnCeiling:
                break;
        }
    }
    
    private void ExitState() // called once after exiting a state
    {
        switch (currentState)
        {
            case PlayerState.Idle: 
                break;
            case PlayerState.Run:
                anim.SetBool("isRunning", false);
                break;
            case PlayerState.Jump:
                break;
            case PlayerState.GravityAbility:
                Physics.gravity = new Vector3(0, -gravityForce, 0);
                break;
            case PlayerState.OnCeiling:
                Physics.gravity = new Vector3(0, -gravityForce, 0);
                characterTransform.localScale = new Vector3(1, 1, 1);
                onCeilingWithGravity = false;
                break;
        }
    }

    private void HandleIdleLogic()
    {
        // stop movement when idle
        rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
    }
    private void HandleRunLogic()
    {
        EnableMovement();
    }
    private void HandleJumpLogic()
    {
        EnableMovement();
    }

    private void EnableMovement()
    {
        Vector3 moveDirection = (transform.right * xInput + transform.forward * yInput).normalized;
        rb.linearVelocity = new Vector3(moveDirection.x * walkSpeed, rb.linearVelocity.y, moveDirection.z * walkSpeed);
    }

    private void HandleGravityAbilityLogic()
    {
        EnableMovement();
        Physics.gravity = new Vector3(0, gravityForce, 0);
    }

    private void HandleOnCeilingLogic()
    {
        characterTransform.localScale = new Vector3(transform.localScale.x, -1, transform.localScale.z);
        Physics.gravity = new Vector3(0, gravityForce, 0);
        EnableMovement();
        
        if(xInput !=0 || yInput != 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);
    }
    
    private void FireBullet()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireBulletCooldown;
            
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
            Vector3 targetPoint;
            
            if (Physics.Raycast(ray, out RaycastHit hitPoint, 10000, ~0, QueryTriggerInteraction.Ignore))
            {
                targetPoint = hitPoint.point;
            }
            else
            {
                targetPoint = ray.GetPoint(1000);
            }
            
            Vector3 bulletSpawnPosition = transform.position + transform.forward * bulletSpawnDistance + transform.up * bulletSpawnHeight;
            Vector3 shootDirection = (targetPoint - bulletSpawnPosition).normalized;
            
            Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.LookRotation(shootDirection));
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ceiling"))
        {
            onCeilingWithGravity = true;
            touchingCeiling = true;
        }
        
        if (other.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ceiling") && jumpPressed && abilityActive)
        {
            anim.SetTrigger("jump");
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, -jumpForce, rb.linearVelocity.z);
            jumpPressed = false;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ceiling"))
            touchingCeiling = false;
        if(other.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            print("Obstacles Touched!!");
            transform.position = CheckpointSystem.Instance.GetActiveCheckpoint().transform.position;
            abilityActive = false;
        }

        CheckpointSystem.Instance.activeCheckpoint = CheckpointSystem.Instance.SetActiveCheckpoint(other);

        if (other.gameObject.CompareTag("Tutorial Trigger"))
        {
            UIManager.Instance.DisplayHint(other.gameObject);

            if (other.gameObject.name == "Hint 2")
            {
                triggerPlatform.StartMoving();
            }
        }
    }
    
}