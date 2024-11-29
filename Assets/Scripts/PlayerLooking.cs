using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooking : MonoBehaviour
{
    [Range(0.1f, 200f)]
    public float sensetivity = 100f;
    [Range(0.1f, 100f)]
    public float verticalClampAngle = 80f;

    private float verticalRotation = 0f;

    public Camera cam;

    void Update() => RotateCam();

    void RotateCam()
    {
        // �������� �������� ����
        float mouseX = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;

        // ��������� ������������ ��������, ����������� ���
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalClampAngle, verticalClampAngle);

        // ������������ ������ �����/���� (��������� ��������)
        cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // ������������ ������ ������ � �������������� ���������
        transform.Rotate(Vector3.up * mouseX);
    }
}
