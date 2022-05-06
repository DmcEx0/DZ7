using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
            Destroy(gameObject);
    }
}
