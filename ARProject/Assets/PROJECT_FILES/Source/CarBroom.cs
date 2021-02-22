using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wikitude;

public class CarBroom : MonoBehaviour
{
    //public GameObject car;
    //public GameObject marker;
    public ImageTrackable firstImage;
    public static bool rotateCar1 = false;
    // Start is called before the first frame update
    void Start()
    {
        //car = firstImage.Drawable.;
    }

    // Update is called once per frame
    void Update()
    {
        //if (rotateCar1 == true)
        {
            firstImage.Drawable.transform.Rotate(Vector3.up, 10f * Time.deltaTime);
            
        }
    }

    public void RotateCar1()
    {
        rotateCar1 = true;
    }

    public void StopRotateCar1()
    {
        rotateCar1 = false;
    }
}
