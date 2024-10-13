using UnityEngine;
using System.Collections;

public class GPSLocation : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // Check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Location services are not enabled by the user.");
            yield break;
        }

        // Start location service before querying GPS data
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait <= 0)
        {
            Debug.Log("Timed out waiting for location services.");
            yield break;
        }

        // Check if service is not available
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location.");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude);
        }

        // Stop the location service if there's no need to query location updates continuously
        Input.location.Stop();
    }
}
