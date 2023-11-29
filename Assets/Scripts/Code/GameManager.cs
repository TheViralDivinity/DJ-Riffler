using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource _theMusic;

    public bool _startPlaying;

    public BeatScroller _beatScroller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_startPlaying)
        {
            if(Input.anyKeyDown)
            {
                _startPlaying = true;
                _beatScroller._hasStarted = true;

                _theMusic.Play();
            }
        }
        
    }
}
