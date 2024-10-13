public class EnemyTracker : MonoBehaviour
{
    public GameObject trackingDevicePrefab;
    public float trackingRadius = 15f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                PlaceTracker();
            }
        }
    }

    void PlaceTracker()
    {
        Vector3 trackerPosition = Camera.main.transform.position + Camera.main.transform.forward * 2f; // Place it 2 units in front of the player
        GameObject tracker = Instantiate(trackingDevicePrefab, trackerPosition, Quaternion.identity);

        Collider[] enemiesInRange = Physics.OverlapSphere(trackerPosition, trackingRadius, LayerMask.GetMask("Enemy"));

        foreach (Collider enemy in enemiesInRange)
        {
            // Add tracking functionality (e.g., mark enemies, give visual indication)
            Debug.Log("Enemy tracked: " + enemy.gameObject.name);
        }
    }
}
