using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    float NoteSpeed = 8;
    bool start;

    void Start()
    {
        NoteSpeed = Gmanager.instance.noteSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }

        if (start)
        {
            transform.position -= transform.forward * Time.deltaTime * NoteSpeed;
        }
    }
}
