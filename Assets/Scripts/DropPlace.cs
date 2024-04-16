using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum FieldType
{
    SELF_HAND,
    ENEMY_HAND,
    SELF_FIELD,
    FOLD
}

public class DropPlace : MonoBehaviour, IDropHandler 
{
    public FieldType Type;
    private GameManager GManager;
    private Game game;

    private bool playAgainAfterDiscard = false;

    private void Awake()
    {
        GManager = FindObjectOfType<GameManager>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        if (Type == FieldType.ENEMY_HAND) 
            return;
        if (Type == FieldType.SELF_HAND)
            return;

        CardMovementScript card = eventData.pointerDrag.GetComponent<CardMovementScript>();

        if (card)
        {
            card.GManager.PlayerHandCards.Remove(card.GetComponent<CardInfo>());
            if (Type == FieldType.FOLD)
            {
                if (card.GetComponent<CardInfo>().SelfCard.Name == "Lodestone")
                {
                    return;
                }
                card.GManager.FoldCards.Add(card.GetComponent<CardInfo>());
                if (GManager.FoldCards.Count > 0)
                {
                    card.GManager.FoldCards.Remove(card.GetComponent<CardInfo>()); 
                    card.GManager.CurrentGame.Deck.Add(card.GetComponent<CardInfo>().SelfCard); 
                    Destroy(card.gameObject); 

                    if (GManager.waitToDiscard == true)
                    {
                        playAgainAfterDiscard = true;
                    }
                    GManager.waitToDiscard = false;
                }
            }
            else
            {
                if (card.GetComponent<CardInfo>().isPlayable && !GManager.waitToDiscard)
                {
                    PlayCard playCard = card.GetComponent<PlayCard>();
                    if (playCard != null)
                    {
                        playCard.Play(card.GetComponent<CardInfo>().SelfCard);
                    }
                    else
                    {
                        Debug.Log("PLAY CARD = NULL");
                    }
                    card.GManager.FieldCards.Add(card.GetComponent<CardInfo>());
                }
                else
                {
                    return;
                }

            }

            card.DefaultParent = transform;

            foreach (var handCard in GManager.PlayerHandCards)
            {
                handCard.GetComponent<CardInfo>().CheckIfPlayable(handCard.GetComponent<CardInfo>().SelfCard);
            }



            if (GManager.playedAgain)
            {
                if (!GManager.waitToDiscard)
                {
                    if (!playAgainAfterDiscard)
                    {
                        GManager.ChangeTurn();
                    }
                }
                else GManager.waitToDiscard = false;
            }
            else
            {
                if (GManager.IsPlayerTurn)
                {
                    GManager.GiveCardToHand(GManager.CurrentGame.Deck, GManager.PlayerHand);
                }
                else
                {
                    GManager.GiveCardToHand(GManager.CurrentGame.Deck, GManager.EnemyHand);
                }

                GManager.playedAgain = true;
                if (playAgainAfterDiscard)
                {
                    playAgainAfterDiscard = false;
                }
            }
        }
        GManager.CheckIfVictory();
    }
}
