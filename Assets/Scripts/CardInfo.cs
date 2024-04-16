using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfo : MonoBehaviour
{
    public Card SelfCard;
    public Image Logo;
    public Image CardPref;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public Color cardColor;
    public TextMeshProUGUI Cost;
    public Image NotPlayable;

    public bool isPlayable;

    public GameObject HideObj;
    
    private GameManager GManager;
    
    private void Awake()
    {
        GManager = FindObjectOfType<GameManager>();
    }

    public void HideCardInfo(Card card)
    {
        SelfCard = card;
        HideObj.SetActive(true);
    }
    public void ShowCardInfo(Card card)
    {
        HideObj.SetActive(false);
        SelfCard = card;

        if (card.Resource == 1)
        {
            cardColor = new Color(0.3f, 0.1f, 0.1f, 1);
        }
        else if (card.Resource == 2)
        {
            cardColor = new Color(0.1f, 0.1f, 0.3f, 1);
        }
        else if (card.Resource == 3)
        {
            cardColor = new Color(0.2f, 0.3f, 0f, 1);
        }
        
        CardPref.GetComponent<Image>().color = cardColor;
        Logo.sprite = card.Logo;
        Logo.preserveAspect = true;
        Name.text = card.Name;
        Description.text = card.Description;
        Cost.text = card.Cost.ToString();
    }

    public void CheckIfPlayable(Card card)
    {
        SelfCard = card;

        
        if (card.Resource == 1)
        { 
            if (card.Cost > GManager.PlayerBricks) 
            { 
                isPlayable = false; 
                NotPlayable.enabled = true;
            }
            else 
            { 
                isPlayable = true; 
                NotPlayable.enabled = false;
            }
        }
        else if (card.Resource == 2) 
        { 
            if (card.Cost > GManager.PlayerGems) 
            { 
                isPlayable = false; 
                NotPlayable.enabled = true;
            }
            else 
            { 
                isPlayable = true; 
                NotPlayable.enabled = false;
            }
        }
        else if (card.Resource == 3) 
        { 
            if (card.Cost > GManager.PlayerRecruits) 
            { 
                isPlayable = false; 
                NotPlayable.enabled = true;
            }
            else 
            { 
                isPlayable = true; 
                NotPlayable.enabled = false;
            }
        }

    }

    private void Start()
    {

    }
}
