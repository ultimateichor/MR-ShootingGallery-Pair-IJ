using UnityEngine;
using UnityEngine.InputSystem;
public class EnemyShooting : MonoBehaviour
{
    // A. References
    public Transform shootingOrigin;
    public InputActionProperty shootAction;
    public float shootingDistance = 10f;
    // B. Check the Enemy tag
    void Start()
    {
        try
        {
            GameObject.FindGameObjectsWithTag("Enemy");

            Debug.Log("ENEMY TAG EXISTS!");
        }
        catch (UnityException error)
        {
            Debug.LogError("ENEMY TAG ERROR: " + error.Message);
        }
    }
    // C. Detect the right trigger
    void Update()
    {
        if (shootAction.action != null &&
        shootAction.action.WasPressedThisFrame())
        {
            Shoot();
        }
    }
    // D. Shoot, detect, and destroy
    void Shoot()
    {
        Debug.Log("TRIGGER PRESSED - SHOOTING!");

        Ray ray = new Ray(shootingOrigin.position,
        shootingOrigin.forward);
        Debug.DrawRay(ray.origin,
        ray.direction * shootingDistance,
        Color.red, 2f);
        if (Physics.Raycast(ray, out RaycastHit hit,
        shootingDistance))
        {
            Debug.Log("RAY HIT: " + hit.collider.gameObject.name);

            Debug.Log("HIT TAG: " + hit.collider.tag);

            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("ENEMY DESTROYED!");

                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            Debug.Log("RAY MISSED EVERYTHING");
        }
    }


}

// Source: Lesson 3 - Destroy Enemies!