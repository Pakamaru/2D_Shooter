using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D body;
    private Player player;
    private float speed;

    private float rotateX;
    private float rotateY;

    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.player = GetComponent<Player>();
    }

    void Update()
    {
        //Rotate();
    }

    public void Movement(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        float h = player.CurSpeed * movement.x;
        float v = player.CurSpeed * movement.y;
        print("speed: " + player.CurSpeed + ", x axis: " + h + ", y axis: " + v);
        body.velocity = new Vector2(h * player.CurSpeed, v * player.CurSpeed);
    }

    public void OnRotationX(InputAction.CallbackContext Context)
    {
        rotateX = Context.ReadValue<float>();
    }

    public void OnRotationY(InputAction.CallbackContext Context)
    {
        rotateY = Context.ReadValue<float>();
    }

    public void Rotate(InputAction.CallbackContext context)
    {
        float HorizontalSensitivity = 30.0f;
        float VerticalSensitivity = 30.0f;

        float RotationX = HorizontalSensitivity * rotateX * Time.deltaTime;
        float RotationY = VerticalSensitivity * rotateY * Time.deltaTime;

        Vector3 CameraRotation = Camera.main.transform.rotation.eulerAngles;

        CameraRotation.x -= RotationY;
        CameraRotation.y += RotationX;

        Camera.main.transform.rotation = Quaternion.Euler(CameraRotation);


        /*

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);*/
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        player.Weapon.Shoot();
    }
}
