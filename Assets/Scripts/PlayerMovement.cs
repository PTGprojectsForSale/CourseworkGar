using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[Range(1f, 100f)]
    //public float runSpeed = 10;
    //[Range(1f, 100f)]
    //public float sideStepSpeed = 5;

    //[Range(0.1f, 10f)]
    //public float acceleration = 3f;
    //[Range(0.1f, 10f)]
    //public float deceleration = 5f;

    //float maxXSpeed;
    //float xSpeed = 0;
    //float maxZSpeed;
    //float zSpeed = 0;

    //Rigidbody rb;
    //Vector3 V;


    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();

    //    maxZSpeed = runSpeed;
    //    maxXSpeed = sideStepSpeed;
    //}

    //void Update()
    //{
    //    float x = Input.GetAxisRaw("Horizontal");
    //    float z = Input.GetAxisRaw("Vertical");

    //    bool sprint = (Input.GetKey(KeyCode.LeftShift));

    //    if (sprint)
    //        maxZSpeed = runSpeed * 1.5f;
    //    else 
    //        maxZSpeed = runSpeed;


    //    if (x != 0)
    //        xSpeed = Mathf.Lerp(xSpeed, x * maxXSpeed, acceleration * Time.deltaTime);
    //    else 
    //        if (xSpeed != 0)
    //        xSpeed = Mathf.Lerp(xSpeed, x * maxXSpeed, deceleration * Time.deltaTime);

    //    if (z != 0)
    //        zSpeed = Mathf.Lerp(zSpeed, z * maxZSpeed, acceleration * Time.deltaTime);
    //    else
    //        if (zSpeed != 0)
    //        zSpeed = Mathf.Lerp(zSpeed, z * maxZSpeed, deceleration * Time.deltaTime);


    //    V = new Vector3(x, 0, z).normalized;
    //    V.x *= xSpeed < 0 ? -xSpeed : xSpeed;
    //    V.z *= zSpeed < 0 ? -zSpeed : zSpeed;



    //    V = transform.TransformDirection(V);

    //    V.y = rb.velocity.y;

    //    rb.velocity = V;
    //}

    [Range(1f, 100f)]
    public float runSpeed = 10;
    [Range(1f, 100f)]
    public float sideStepSpeed = 5;

    [Range(0.1f, 10f)]
    public float acceleration = 3f;
    [Range(0.1f, 10f)]
    public float deceleration = 5f;

    [Range(1f, 20f)]
    public float jumpForce = 5f; // Сила прыжка
    [Range(1f, 20f)]
    public float wallJumpForce = 7f; // Сила прыжка от стены

    private float maxXSpeed;
    private float xSpeed = 0;
    private float maxZSpeed;
    private float zSpeed = 0;

    private Rigidbody rb;
    private Vector3 V;

    private bool isGrounded; // Проверка на земле

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        maxZSpeed = runSpeed;
        maxXSpeed = sideStepSpeed;
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        //ApplyMovement();
    }

    void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        bool sprint = (Input.GetKey(KeyCode.LeftShift));

        if (sprint)
            maxZSpeed = runSpeed * 1.5f;
        else
            maxZSpeed = runSpeed;

        if (x != 0)
            xSpeed = Mathf.Lerp(xSpeed, x * maxXSpeed, acceleration * Time.deltaTime);
        else
            if (xSpeed != 0)
            xSpeed = Mathf.Lerp(xSpeed, x * maxXSpeed, deceleration * Time.deltaTime);

        if (z != 0)
            zSpeed = Mathf.Lerp(zSpeed, z * maxZSpeed, acceleration * Time.deltaTime);
        else
            if (zSpeed != 0)
            zSpeed = Mathf.Lerp(zSpeed, z * maxZSpeed, deceleration * Time.deltaTime);

        V = new Vector3(x, 0, z).normalized;
        V.x *= xSpeed < 0 ? -xSpeed : xSpeed;
        V.z *= zSpeed < 0 ? -zSpeed : zSpeed;

        V = transform.TransformDirection(V);

        // Устанавливаем вертикальную скорость
        V.y = rb.velocity.y;

        rb.velocity = V;
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded) // Обычный прыжок
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false; // Игрок больше не на земле
            }
            else if (IsTouchingWall()) // Прыжок от стены
            {
                Vector3 wallJumpDirection = new Vector3(-transform.forward.x, 1, -transform.forward.z).normalized;
                rb.AddForce(wallJumpDirection * wallJumpForce, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Проверяем столкновение с землей
        {
            isGrounded = true; // Игрок снова на земле
        }
    }

    private bool IsTouchingWall()
    {
        RaycastHit hit;

        // Проверяем наличие стены слева и справа
        return Physics.Raycast(transform.position, transform.right, out hit, 1f) ||
               Physics.Raycast(transform.position, -transform.right, out hit, 1f) ||
               Physics.Raycast(transform.position, transform.forward, out hit, 1f) ||
               Physics.Raycast(transform.position, -transform.forward, out hit, 1f);
    }
}
