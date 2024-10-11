using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class Data
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public Note[] notes;
}

[Serializable] public class Note
{
    public int type;
    public int num;
    public int block;
    public int LPB;
}

public class NotesManager : MonoBehaviour
{
    public int noteNum;
    private string songName;

    public List<int> LaneNum = new List<int>();
    public List<int> NoteType = new List<int>();
    public List<float> NotesTime = new List<float>();
    public List<GameObject> NotesObj = new List<GameObject>();

     private float NotesSpeed;
    [SerializeField] GameObject noteObj;
    [SerializeField] SongDataBase dataBase;

    private void OnEnable()
    {
        NotesSpeed = Gmanager.instance.noteSpeed;
        noteNum = 0;
        songName = dataBase.songData[Gmanager.instance.songID].songName;
        Load(songName);
    }

    private void Load(string SongName)
    {
        string inputString = Resources.Load<TextAsset>(SongName).ToString();
        Data intputJson = JsonUtility.FromJson<Data>(inputString);

        noteNum = intputJson.notes.Length;
        Gmanager.instance.maxScore = noteNum * 5;
        for (int i = 0; i < intputJson.notes.Length; i++)
        {
            float sensor = 60 / (intputJson.BPM * (float)intputJson.notes[i].LPB);
            float beatSec = sensor * (float)intputJson.notes[i].LPB;
            float time = (beatSec * intputJson.notes[i].num / (float)intputJson.notes[i].LPB) + intputJson.offset * 0.01f;
            NotesTime.Add(time);
            LaneNum.Add(intputJson.notes[i].block);
            NoteType.Add(intputJson.notes[i].type);

            float z = NotesTime[i] * NotesSpeed;
            NotesObj.Add(Instantiate(noteObj, new Vector3(intputJson.notes[i].block - 1.5f, 0.55f, z), Quaternion.identity));
        }
    }
}
