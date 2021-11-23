using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Rigidbody2D body;
    Player player;
    float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();
        Shoot();
    }

    private void LateUpdate()
    {
        
    }

    private void Movement()
    {
        float h = speed * Input.GetAxis("Horizontal");
        float v = speed * Input.GetAxis("Vertical");

        body.velocity = new Vector2(h * speed, v * speed);
    }

    private void Rotate()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            player.Weapon.Shoot();
        }
    }
}
