using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    CharacterController character;
    public float caminar = 6.0f;
    public float saltar = 10f;
    public float gravedad = 15f;
    public float correr = 25f;

    public Camera camera;
    public float horizontal = 2.0f;
    public float vertical = 2.0f;
    public float rotacionMax = 40.0f;
    public float rotacionMin = 50.0f;
    float h_mou, y_mou;

    private Vector3 movimiento = Vector3.zero;

    void Start()
    {
        character = GetComponent<CharacterController>();

    }


    void Update()
    {
        y_mou = vertical * Input.GetAxis("Raton y");
        h_mou = horizontal * Input.GetAxis("Raton x");

        y_mou = Mathf.Clamp(y_mou, rotacionMin, rotacionMax);
        camera.transform.localEulerAngles = new Vector3(-y_mou, 0, 0);

        if (character.isGrounded)
        {
            movimiento = new Vector3(Input.GetAxis("horizontal"), 0.0f, Input.GetAxis("vertical"));
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movimiento = transform.TransformDirection(movimiento) * correr;
            }
            else
            {
                movimiento = transform.TransformDirection(movimiento) * caminar;
			}

            if(Input.GetKey(KeyCode.Space))
            {
                movimiento.y = saltar;
            }
        }

        movimiento.y -= gravedad * Time.deltaTime;
        character.Move(movimiento * Time.deltaTime);

    }

}
