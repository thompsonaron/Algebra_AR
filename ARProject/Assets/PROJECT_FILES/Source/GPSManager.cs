using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSManager : MonoBehaviour
{
    public GameObject bus;

    float startLatitude = -1;
    float startLongitude = -1;
    float currentLatitude = -1;
    float currentLongitude = -1;
    string msg = "Instantiating GPS";

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(StartGPS());
    }

    // Update is called once per frame
    void Update()
    {


        currentLatitude = Input.location.lastData.latitude;
        currentLongitude = Input.location.lastData. longitude;


        msg = "Lat: " + currentLatitude +
                "\nLong: " + currentLongitude;


        var distance = DistanceFunction(startLatitude, startLongitude, currentLatitude, currentLongitude);

        if (distance >= 3)
        {
            Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);

            bus.GetComponent<MeshRenderer>().material.color = randomColor;

            startLatitude = currentLatitude;
            startLongitude = currentLongitude;
        }
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 50;
        GUI.Label(new Rect(30, 30, 1000, 10000), msg);
        
    }

    private IEnumerator StartGPS()
    {
        msg = "Start gps method!";
        if (!Input.location.isEnabledByUser)
        {
            msg = "Location share is off!";
            yield break;
        }

        Input.location.Start(5, 0);
        int maxWait = 5;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            msg = "Timed out!";
            yield break;
        }


        if (Input.location.status == LocationServiceStatus.Failed)
        {
            msg = "No device location found!";
            yield break;
        }
        else
        {
            Input.compass.enabled = true;
            msg = "Lat: " + Input.location.lastData.latitude +
                "\nLong: " + Input.location.lastData.longitude;

            // init
            if (startLatitude == -1f)
            {
                startLatitude = Input.location.lastData.latitude;
                startLongitude= Input.location.lastData.longitude;
                currentLatitude = startLatitude;
                currentLongitude = startLongitude;
            }
        }

        yield return null;
    }

    public double DistanceFunction(float start_lat1, float start_lon1, float lat2, float lon2)
    {
        var R = 6378.137;
        var dLat = lat2 * Mathf.PI / 180 - start_lat1 * Mathf.PI / 180;
        var dLon = lon2 * Mathf.PI / 180 - start_lon1 * Mathf.PI / 180;
        var a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
        Mathf.Cos(start_lat1 * Mathf.PI / 180) * Mathf.Sin(lat2 * Mathf.PI / 180) *
        Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        var d = R * c;
        return d * 1000;
    }
}
