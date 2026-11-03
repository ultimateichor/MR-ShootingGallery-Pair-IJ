using UnityEngine;
// Finds the headset position and spawns three enemies.
public class EnemySpawner : MonoBehaviour
{
    // A. REFERENCES
    public Transform playerHead;
    public GameObject redEnemy;
    public GameObject greenEnemy;
    public GameObject blueEnemy;
    // Runs once when this enabled script starts.
    void Start()
    {
        // B. STARTING POSITION
        Vector3 startPosition = playerHead.position;
        Debug.Log("Headset position: " + startPosition);
        // C. FORWARD & RIGHT
        Vector3 forward = playerHead.forward;
        forward.y = 0;
        forward.Normalize();
        Vector3 right = Vector3.Cross(Vector3.up, forward);
        // D1. LEFT ENEMY
        Vector3 leftPosition = startPosition
        + forward * 2.5f
        - right * 1f
        + Vector3.down * 0.3f;
        // D2. CENTER ENEMY
        Vector3 centerPosition = startPosition
        + forward * 3f
        + Vector3.down * 0.3f;
        // D3. RIGHT ENEMY
        Vector3 rightPosition = startPosition
        + forward * 2.5f
        + right * 1f
        + Vector3.down * 0.3f;
        // E. CREATE THE ENEMIES
        Instantiate(redEnemy, leftPosition, Quaternion.identity);
        Instantiate(greenEnemy, centerPosition, Quaternion.identity);
        Instantiate(blueEnemy, rightPosition, Quaternion.identity);
    }
}