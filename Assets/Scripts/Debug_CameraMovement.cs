using UnityEngine;

public class Debug_CameraMovement : MonoBehaviour
{
     public float Speed = 50;

    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * Speed;
        float zAxisValue = Input.GetAxis("Vertical") * Speed;
        float yValue = 0.0f;
        float ForwardValue = 0.0f;

        if (Input.GetKey(KeyCode.A))
        {
            yValue = -Speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            yValue = Speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            ForwardValue = Speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ForwardValue = -Speed;
        }

        //transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y + yValue, transform.position.z + zAxisValue);
        transform.position = transform.position + transform.forward * ForwardValue + transform.right * yValue;

    }
}