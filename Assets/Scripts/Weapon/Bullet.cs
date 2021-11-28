using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public CombatUnit Shooter { get; set; }
    private Rigidbody2D rb;
    private float speed = 20;
    private float lifeTime = 5;

    void Start()
    {
        StartCoroutine(SelfDestruct());
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * speed;
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            Destroy(gameObject);
    }
}
