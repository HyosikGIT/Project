using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontroller : MonoBehaviour
{
    public static UIcontroller Instance;

    public Transform MainCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    public Popup CreatePopup()
    {
        GameObject popUpGo = Instantiate(Resources.Load("Assets/prefabs/Popup.prefab") as GameObject);
        return popUpGo.GetComponent<Popup>();
    }
}
