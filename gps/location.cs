using UnityEngine;
using TMPro;
using System.Collections;

public class TestLocationServices : MonoBehaviour
{
    public TMP_Text gpsText;
    private bool isLocationServiceRunning = false;
    private float lastLatitude = 0f;
    private float lastLongitude = 0f;

    void Start()
    {
        // Start the coroutine to get GPS data
        StartCoroutine(StartLocationService());
    }

    IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            gpsText.text = "Location services not enabled.";
            Debug.LogError("Location services not enabled.");
            yield break;
        }

        // Start location service with high accuracy (1 meter) and minimal movement to trigger an update (0.1 meters)
        Input.location.Start(1f, 0.1f); 

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            gpsText.text = "Initializing location services...";
            Debug.Log("Initializing location services...");
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            gpsText.text = "Location initialization timed out.";
            Debug.LogError("Location initialization timed out.");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            gpsText.text = "Failed to retrieve location.";
            Debug.LogError("Failed to retrieve location.");
            yield break;
        }
        else
        {
            gpsText.text = "Location service started.";
            isLocationServiceRunning = true;
            Debug.Log("Location service started successfully.");
        }
    }

    void Update()
    {
        if (isLocationServiceRunning && Input.location.status == LocationServiceStatus.Running)
        {
            // Retrieve the current latitude and longitude
            float currentLatitude = Input.location.lastData.latitude;
            float currentLongitude = Input.location.lastData.longitude;

            // Only update if the coordinates have changed
            if (currentLatitude != lastLatitude || currentLongitude != lastLongitude)
            {
                lastLatitude = currentLatitude;
                lastLongitude = currentLongitude;

                // Update the UI with the new coordinates
                gpsText.text = "Coordinates: Latitude: " + currentLatitude.ToString("F6") + 
                               ", Longitude: " + currentLongitude.ToString("F6");

                Debug.Log("Coordinates updated: Latitude: " + currentLatitude + ", Longitude: " + currentLongitude);
            }
        }
        else if (Input.location.status != LocationServiceStatus.Running)
        {
            gpsText.text = "Waiting for GPS signal...";
            Debug.Log("Waiting for GPS signal...");
        }
    }

    void OnDisable()
    {
        // Stop location service when the script is disabled or the object is destroyed
        if (isLocationServiceRunning)
        {
            Input.location.Stop();
            isLocationServiceRunning = false;
            Debug.Log("Location service stopped.");
        }
    }
}
