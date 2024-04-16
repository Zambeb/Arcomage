using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerHeight : MonoBehaviour
{
    public TextMeshProUGUI towerH;
    public RectTransform imageRectTransform;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (towerH != null && imageRectTransform != null)
        {
            if (int.TryParse(towerH.text, out int height))
            {
                imageRectTransform.sizeDelta = new Vector2(imageRectTransform.sizeDelta.x, height * 5f);
            }
        }
    }
}
