using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Judge : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] MessageObj;
    [SerializeField] private NotesManager notesManager;

    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] private GameObject finish;

    AudioSource audio;
    [SerializeField] AudioClip hitSound;

    private float endTime = 0;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        endTime = notesManager.NotesTime[notesManager.NotesTime.Count - 1];
    }

    // Update is called once per frame
    void Update()
    {
        if (Gmanager.instance.Start)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (notesManager.LaneNum[0] == 0)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + Gmanager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 0)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + Gmanager.instance.StartTime)), 1);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (notesManager.LaneNum[0] == 1)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + Gmanager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 1)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + Gmanager.instance.StartTime)), 1);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                if (notesManager.LaneNum[0] == 2)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + Gmanager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 2)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + Gmanager.instance.StartTime)), 1);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                if (notesManager.LaneNum[0] == 3)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + Gmanager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 3)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] +Gmanager.instance.StartTime)), 1);
                    }
                }
            }

            if (Time.time > endTime + Gmanager.instance.StartTime)
            {
                finish.SetActive(true);
                Invoke("ResultScene", 3f);
                return;
            }
            
            if (Time.time > notesManager.NotesTime[0] + 0.2f + Gmanager.instance.StartTime)
            {
                message(3);
                deleteData(0);
                Debug.Log("Miss");
                Gmanager.instance.miss++;
                Gmanager.instance.combo = 0;
            }
        }
    }

    void Judgement(float timeLag, int numOffset)
    {
        audio.PlayOneShot(hitSound);
        if (timeLag <= 0.15)
        {
            Debug.Log("Perfect");
            message(0);
            Gmanager.instance.ratioScore += 5;
            Gmanager.instance.perfect++;
            Gmanager.instance.combo++;
            deleteData(numOffset);
        }
        else
        {
            if (timeLag <= 0.20)
            {
                Debug.Log("Great");
                message(1);
                Gmanager.instance.ratioScore += 3;
                Gmanager.instance.great++;
                Gmanager.instance.combo++;
                deleteData(numOffset);
            }
            else
            {
                if (timeLag <= 0.25)
                {
                    Debug.Log("Bad");
                    message(2);
                    Gmanager.instance.ratioScore += 1;
                    Gmanager.instance.bad++;
                    Gmanager.instance.combo++;
                    deleteData(numOffset);
                }
            }
        }
    }

    float GetABS(float num)
    {
        if (num >= 0)
        {
            return num;
        }
        else
        {
            return -num;
        }
    }

    void deleteData(int numOffset)
    {
        notesManager.NotesTime.RemoveAt(numOffset);
        notesManager.LaneNum.RemoveAt(numOffset);
        notesManager.NoteType.RemoveAt(numOffset);
        Gmanager.instance.score = (int)Math.Round(1000000 * Math.Floor(Gmanager.instance.ratioScore / Gmanager.instance.maxScore * 1000000) / 1000000);
        comboText.text = Gmanager.instance.combo.ToString();
        scoreText.text = Gmanager.instance.score.ToString();
    }

    void message(int judge)
    {
        Instantiate(MessageObj[judge], new Vector3(notesManager.LaneNum[0] - 1.5f, 0.76f, 0.15f), Quaternion.Euler(45,0,0));
    }

    void ResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
