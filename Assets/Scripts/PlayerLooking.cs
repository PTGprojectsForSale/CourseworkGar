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
        // Получаем движение мыши
        float mouseX = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;

        // Обновляем вертикальное вращение, ограничивая его
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalClampAngle, verticalClampAngle);

        // Поворачиваем камеру вверх/вниз (локальное вращение)
        cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Поворачиваем объект игрока в горизонтальной плоскости
        transform.Rotate(Vector3.up * mouseX);
    }
}
