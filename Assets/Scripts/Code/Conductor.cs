using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float _songBpm;

    //The number of seconds for each song beat
    public float _secPerBeat;

    //Current song position, in seconds
    public float _songPosition;

    //Current song position, in beats
    public float _songPositionInBeats;

    //How many seconds have passed since the song started
    public float _dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource _musicSource;

    //The offset to the first beat of the song in seconds
    public float _firstBeatOffset;

    //keep all the position-in-beats of notes in the song
    float[] notes;

    //the index of the next note to be spawned
    int nextIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        _musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        _secPerBeat = 60f / _songBpm;

        //Record the time when the music starts
        _dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        _musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //determine how many seconds since the song started
        _songPosition = (float)(AudioSettings.dspTime - _dspSongTime - _firstBeatOffset);

        //determine how many beats since the song started
        _songPositionInBeats = _songPosition / _secPerBeat;
    }
}
