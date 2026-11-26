using UnityEngine;
 
[RequireComponent(typeof(CharacterController))]
public class IndoorPlayerController : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 5.5f;
    public float gravity = -18f;
    public float turnSpeed = 12f;
 
    private CharacterController controller;
    private Animator animator;
    private float verticalVelocity;
 
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
 
    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 moveInput = Vector3.ClampMagnitude(
            new Vector3(h, 0f, v), 1f);
 
        bool running = Input.GetKey(KeyCode.LeftShift);
        float moveSpeed = running ? runSpeed : walkSpeed;
 
        if (moveInput.sqrMagnitude > 0.01f)
        {
            Quaternion facing = Quaternion.LookRotation(moveInput);
            transform.rotation = Quaternion.Slerp(
                transform.rotation, facing, turnSpeed * Time.deltaTime);
        }
 
        if (controller.isGrounded && verticalVelocity < 0f)
            verticalVelocity = -2f;
 
        verticalVelocity += gravity * Time.deltaTime;
        Vector3 velocity = moveInput * moveSpeed +
                           Vector3.up * verticalVelocity;
        controller.Move(velocity * Time.deltaTime);
 
        if (animator != null)
        {
            float animationSpeed = moveInput.magnitude *
                                   (running ? 1f : 0.5f);
            animator.SetFloat("Speed", animationSpeed);
        }
    }
}