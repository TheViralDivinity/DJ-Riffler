using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Toggle variable for level running (Y/NA)
    public bool _hasStarted;

    //an AudioSource attached to this GameObject that will play the music
    public AudioSource _musicSource;

    public BeatScroller _beatScroller;

    public GameObject _chart;

    //?
    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        //?
        instance = this;

        //Load the AudioSource attached to the Conductor GameObject
        _musicSource = GetComponent<AudioSource>();

        //Load BeatScroller as an object of GameManager
        this._beatScroller = new BeatScroller(_chart);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasStarted)
        {
            if(Input.anyKeyDown)
            {
                //Song start
                _hasStarted = true;
                _beatScroller._isPlaying = true;

                //Record the time when the music starts
                _beatScroller._dspSongTime = (float)AudioSettings.dspTime;

                Debug.Log(_beatScroller._dspSongTime);
                //Start the music
                _musicSource.Play();

                return;
            }
        }
        else
        {
            _beatScroller.Update();
        }
        
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }
}
