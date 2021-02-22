using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject lbl;

    public void Run()
    {
        StaticFlagz.run = !StaticFlagz.run;
    }

    public void ObjectRecognised()
    {
        lbl.SetActive(true);
    }
}
