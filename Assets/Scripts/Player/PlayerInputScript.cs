using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    private Rigidbody2D body;
    private Player player;
    private bool shooting;

    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.player = GetComponent<Player>();
        shooting = false;
    }

    void Update()
    {
        Rotate();
        if (shooting) player.Weapon.Shoot();
    }

    public void InitPlayer(Player player)
    {
        //this.player = player;
    }

        public void Movement(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        float h = player.CurSpeed * movement.x;
        float v = player.CurSpeed * movement.y;
        body.velocity = new Vector2(h * player.CurSpeed, v * player.CurSpeed);
    }

    public void Rotate()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            shooting = true;
        if (context.phase == InputActionPhase.Canceled)
            shooting = false;
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            FindObjectOfType<GameController>().PauseGame();
    }
}
