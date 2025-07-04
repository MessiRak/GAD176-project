using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private float detectionRange = 10f;

    private Transform player;
    private Rigidbody rb;

    void Start()
    {
        // Find player
        GameObject playerObj = GameObject.FindWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Player not found. Make sure they’re tagged as 'Player'.");
        }

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody missing on enemy!");
        }
    }

    // Check if the player is close
    public bool IsPlayerInRange()
    {
        if (player == null) return false;

        float distance = Vector3.Distance(transform.position, player.position);
        return distance <= detectionRange;
    }

    // Move toward player using Rigidbody
    public void MoveTowardsPlayer()
    {
        if (player == null || rb == null) return;

        Vector3 direction = player.position - transform.position;
        Vector3 move = direction.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + move);
    }
}
