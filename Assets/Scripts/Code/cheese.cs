using System;
using System.IO;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

System.Timers.Timer t = new System.Timers.Timer()
{
    Interval = 1000,
    AutoReset = false
};

t.Elapsed += delegate (System.Object o, System.Timers.ElapsedEventArgs e)
{ Debug.Log(.transform.position); };

public class cheese : MonoBehaviour
{
    public bool playing = false;
    public float _dspSongTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playing)
        {
            if (Input.anyKeyDown)
            {
                playing = true;
                //Record the time when the music starts
                _dspSongTime = (float)AudioSettings.dspTime;

            }
        }
    }
}
