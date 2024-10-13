public class PowerUpTag : MonoBehaviour
{
    public float powerUpDuration = 5f;
    public float increasedTagRadius = 10f;
    private float defaultTagRadius = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            StartCoroutine(ApplyPowerUp());
        }
    }

    IEnumerator ApplyPowerUp()
    {
        // Increase tag radius
        float originalRadius = defaultTagRadius;
        defaultTagRadius = increasedTagRadius;
        
        yield return new WaitForSeconds(powerUpDuration);
        
        // Revert tag radius
        defaultTagRadius = originalRadius;
    }
}
