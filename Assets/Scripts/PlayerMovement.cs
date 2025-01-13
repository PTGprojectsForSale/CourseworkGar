using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(1f, 100f)]
    public float speed = 10;

    [Range(0.1f, 10f)]
    public float acceleration = 3f;
    [Range(0.1f, 10f)]
    public float deceleration = 5f;

    [Range(0.1f, 10f)]
    public float jumpForce = 5f; // ���� ������
    public int maxJumps = 2; // ���������� ������� (��� ����-������)

    public float dashDistance = 5f; // ��������� �����
    public float dashDuration = 0.2f; // ������������ �����
    public float dashCooldown = 1f; // ����������� �����

    private float maxXSpeed;
    private float xSpeed = 0;
    private float maxZSpeed;
    private float zSpeed = 0;

    private Rigidbody rb;
    private Vector3 V;

    private bool isGrounded; // �������� �� �����
    private int jumpCount; // ������� �������
    private bool canDash = true; // ����������� �����
    private bool isDashing = false; // ���� ���������� �����

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        maxZSpeed = speed;
        maxXSpeed = speed;
    }

    void Update()
    {
        if (!isDashing)
        {
            HandleMovement();
            HandleJump();
        }
        HandleDash();
    }

    void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (x != 0)
            xSpeed = Mathf.Lerp(xSpeed, x * maxXSpeed, acceleration * Time.deltaTime);
        else if (xSpeed != 0)
            xSpeed = Mathf.Lerp(xSpeed, 0, deceleration * Time.deltaTime);

        if (z != 0)
            zSpeed = Mathf.Lerp(zSpeed, z * maxZSpeed, acceleration * Time.deltaTime);
        else if (zSpeed != 0)
            zSpeed = Mathf.Lerp(zSpeed, 0, deceleration * Time.deltaTime);

        V = new Vector3(x, 0, z).normalized;
        V.x *= Mathf.Abs(xSpeed);
        V.z *= Mathf.Abs(zSpeed);

        V = transform.TransformDirection(V);

        // ������������� ������������ ��������
        V.y = rb.linearVelocity.y;

        rb.linearVelocity = V;
    }

    void HandleJump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.5f); // ���������, �� ����� �� �����

        if (isGrounded)
        {
            jumpCount = 0; // ���������� ������� �������
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded || jumpCount < maxJumps)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
                jumpCount++;
            }
        }
    }

    void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        Vector3 dashDirection;

        // ���� ����� `Ctrl`, ������ ��� ����, ����� � � ����������� ��������
        if (Input.GetKey(KeyCode.LeftControl))
        {
            dashDirection = Vector3.down;
        }
        else
        {
            dashDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            if (dashDirection == Vector3.zero)
            {
                dashDirection = transform.forward;
            }
            else
            {
                dashDirection = transform.TransformDirection(dashDirection);
            }
        }

        Vector3 start = transform.position;
        Vector3 dashTarget = transform.position + dashDirection * dashDistance;

        // �������� ������������ �� ���� �����
        if (Physics.Raycast(transform.position, dashDirection, out RaycastHit hit, dashDistance))
        {
            dashTarget = hit.point;
        }

        float dashStartTime = Time.time;

        while (Time.time < dashStartTime + dashDuration)
        {
            rb.MovePosition(Vector3.Lerp(start, dashTarget, (Time.time - dashStartTime) / dashDuration));
            yield return null;
        }

        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
