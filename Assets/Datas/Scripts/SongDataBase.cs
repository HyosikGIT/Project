using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SongDataBase", menuName = "CreateAMusicDataBase")]
public class SongDataBase : ScriptableObject
{
    [SerializeField] public SongData[] songData;
}
