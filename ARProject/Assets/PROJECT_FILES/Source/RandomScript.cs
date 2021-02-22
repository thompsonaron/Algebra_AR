using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (StaticFlagz.run)
        {
            transform.Rotate(Vector3.up, 50f * Time.deltaTime);
        }
    }
}
