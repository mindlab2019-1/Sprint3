using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Annotation : MonoBehaviour 
{
    public Text text;

    public void Initialise(Vector3 vect, String _s)
    {
        transform.position = vect;
        text.text = _s;
        transform.LookAt(Vector3.zero);
    }
}