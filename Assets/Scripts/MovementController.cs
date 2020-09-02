using System.Collections;
using System.Collections.Generic;

using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{

    [SerializeField] [Range(1, 30)] float speed = 1.5f;

    [SerializeField] Transform head;

    [SerializeField] float sensitivity = 5f; // чувствительность мыши
    [SerializeField] float headMinY = -40f; // ограничение угла для головы
    [SerializeField] float headMaxY = 40f;

    [SerializeField] float jumpForce = 10; // сила прыжка
    [SerializeField] float jumpDistance = 1.2f; // расстояние от центра объекта, до поверхности

    private Vector3 direction;
    public LayerMask layerMask;
    private Rigidbody body;
    private float rotationY;
    public static bool active;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
        StartActive();
    }

    void FixedUpdate()
    {
        body.AddForce(direction * speed, ForceMode.VelocityChange);

        if (Mathf.Abs(body.velocity.x) > speed)
        {
            body.velocity = new Vector3(Mathf.Sign(body.velocity.x) * speed, body.velocity.y, body.velocity.z);
        }
        if (Mathf.Abs(body.velocity.z) > speed)
        {
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, Mathf.Sign(body.velocity.z) * speed);
        }
    }

    bool GroundCheck()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit, jumpDistance, layerMask))
        {
            return true;
        }

        return false;
    }

    public static void StopActive()
    {
        active = false;
        Cursor.visible = true;
    }
    public static void StartActive()
    {
        active = true;
        Cursor.visible = false;
    }

    void Update()
    {
        if (active)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            float j = Input.GetAxis("Jump");

            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
            rotationY += Input.GetAxis("Mouse Y") * sensitivity;
            rotationY = Mathf.Clamp(rotationY, headMinY, headMaxY);
            head.localEulerAngles = new Vector3(-rotationY, 0, 0);
            transform.localEulerAngles = new Vector3(0, rotationX, 0);
            direction = new Vector3(h, 0, v);
            direction = transform.TransformDirection(direction);
            direction = new Vector3(direction.x, 0, direction.z);

            if (j > 0 && GroundCheck())
            {
                body.velocity = new Vector2(0, jumpForce);
            }
        }
        else
        {
            direction = new Vector3(0, 0, 0);

        }
    }
}
