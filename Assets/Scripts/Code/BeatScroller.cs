using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : object
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float _songBpm; 

    public float _scrollSpeed;

    //The number of seconds for each song beat
    public float _secPerBeat;

    //Current song position, in seconds
    public float _songPosition;

    //Current song position, in beats
    public float _songPositionInBeats;

    //How many seconds have passed since the song started
    public float _dspSongTime;

    //Detects if the song has started or not
    public bool _isPlaying;

    //The offset to the first beat of the song in seconds
    public float _firstBeatOffset;

    /*
    //keep all the position-in-beats of notes in the song
    float[] notes;

    //the index of the next note to be spawned
    int nextIndex = 0;
    */

    public GameObject _chart;

    // Start is called before the first frame update
    public BeatScroller(GameObject _chart, float _songBpm = 115)
    {
        this._songBpm = _songBpm;

        //Calculate the number of seconds in each beat
        _secPerBeat = 60f / _songBpm;

        //Get BPM In proper per minute format for scroll speed
        _scrollSpeed = _songBpm / 12000f;

        this._chart = _chart;

    }

    // Update is called once per frame
    public void Update()
    {
        //Determine how many seconds since the song started
        _songPosition = (float)(AudioSettings.dspTime - _dspSongTime - _firstBeatOffset);

        //Determine how many beats since the song started
        if (_songPositionInBeats < (_songPositionInBeats = _songPosition / _secPerBeat))
        {
            ChartMover();
        }

    }

    void ChartMover()
    {
        if (!_isPlaying)
        {
            /*if (Input.anyKeyDown)
            {
                //Start up sequence at pressing any key to continue
                _isPlaying = true;

                //Record the time when the music starts
                _dspSongTime = (float)AudioSettings.dspTime;

                //Start the music
                _musicSource.Play();
            }*/
        }
        else
        {
            //Moves the chart down at the scroll speed, constant to the song position
            _chart.transform.position -= new Vector3(0f, (_scrollSpeed * _songPosition), 0f);

        }
    }
}