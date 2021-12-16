using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public CombatUnit Shooter { get; set; }
    private Rigidbody2D rb;
    private float speed = 5;
    private float lifeTime = 10;

    void Start()
    {
        StartCoroutine(SelfDestruct());
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * speed;
        Shooter = transform.GetComponentInParent<CombatUnit>();
        transform.SetParent(null);
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
