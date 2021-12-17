using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.TakeDamage(Mathf.RoundToInt(player.MaxHealth * 0.1f));
        }
    }
}
