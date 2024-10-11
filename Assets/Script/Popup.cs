using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Popup : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] Text closeText;
    [SerializeField] Text popupText;
    
    public void Init(Transform canvas, string popupMess, string clsbtn)
    {
        popupText.text = popupMess;
        closeText.text = clsbtn;
        
        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        
        closeButton.onClick.AddListener(() =>
        {
            GameObject.Destroy(this.gameObject);
        });
    }
}
