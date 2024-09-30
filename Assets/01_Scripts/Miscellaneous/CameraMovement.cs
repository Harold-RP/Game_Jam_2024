using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 300f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        // Bloquea el cursor al centro de la pantalla y lo oculta
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Obtener los movimientos del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotaci�n vertical de la c�mara (para evitar que gire completamente alrededor)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita el �ngulo de rotaci�n vertical

        // Aplica la rotaci�n a la c�mara y al jugador
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // C�mara solo rota en el eje X (arriba/abajo)
        playerBody.Rotate(Vector3.up * mouseX); // Jugador rota en el eje Y (izquierda/derecha)
    }
}
