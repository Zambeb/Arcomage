using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerHeight : MonoBehaviour
{
    public TextMeshProUGUI towerH;
    public RectTransform imageRectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Проверяем, что текстовое поле towerH и RectTransform изображения не равны null
        if (towerH != null && imageRectTransform != null)
        {
            // Парсим текстовое поле в число
            if (int.TryParse(towerH.text, out int height))
            {
                // Устанавливаем высоту изображения
                imageRectTransform.sizeDelta = new Vector2(imageRectTransform.sizeDelta.x, height * 5f);
            }
        }
    }
}
