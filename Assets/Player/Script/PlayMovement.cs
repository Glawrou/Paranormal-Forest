using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovement : MonoBehaviour
{
    public CharacterController controler;

    [Range(4, 16)]
    public float SpeedControl = 6f;

    private float speed;

    private void Start()
    {
        speed = SpeedControl;
    }

    void Update()
    {
        MoveXY();

        Squats();

        if(transform.position.y < 5.8f)
        {
            transform.position = new Vector3(transform.position.x, 0.8f, transform.position.z);
        }

    }

    /// <summary>
    /// Движения по двум осям
    /// </summary>
    private void MoveXY()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;

        controler.Move(move * speed * Time.deltaTime);
    }

    /// <summary>
    /// Приседания
    /// </summary>
    private void Squats()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            controler.height = controler.height / 2f;
            controler.Move(transform.up * -1f);
            speed = SpeedControl / 2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            controler.height = 1.5f;
            controler.Move(transform.up * 0.2f);
            speed = SpeedControl;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "GasCanistra")
        {
            if(Input.GetKey(KeyCode.E))
            {
                Destroy(other.gameObject);
            }
        }
    }

}
