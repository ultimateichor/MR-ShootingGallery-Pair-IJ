using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // A. References
    public Transform playerHead;
    public float moveSpeed = 0.5f;
    public float stopDistance = 1f;

    // B. Update
    public void Update()
    {
        if (playerHead == null) return;

        float distance = Vector3.Distance(
            transform.position, playerHead.position);

        if (distance > stopDistance)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                playerHead.position,
                moveSpeed * Time.deltaTime);
        }
    }
}
