using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagers : MonoBehaviour
{
    [SerializeField] private SongDataBase dataBase;
    AudioSource audio;
    AudioClip Music;
    string songName;
    bool played;
    void Start()
    {
        Gmanager.instance.Start = false;
        songName = dataBase.songData[Gmanager.instance.songID].songName;
        audio = GetComponent<AudioSource>();
        Music = (AudioClip)Resources.Load("Musics/" + songName);
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !played)
        {
            Gmanager.instance.Start = true;
            Gmanager.instance.StartTime = Time.time;
            played = true;
            audio.PlayOneShot(Music);
        }
    }
}
