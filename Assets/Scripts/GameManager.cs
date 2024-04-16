using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using Random = UnityEngine.Random;


public class Game
{
    public List<Card> Deck;

    public Game()
    {
        Deck = GiveDeckCard();
        ShuffleDeck();
    }

    List<Card> GiveDeckCard()
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < CardManager.AllCards.Count; i++)
        {
            //list.Add(CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)]);
            list.Add(CardManager.AllCards[i]);
        }
        return list;
    }
    
    void ShuffleDeck()
    {
        List<Card> shuffledDeck = new List<Card>();
        
        List<Card> tempDeck = new List<Card>(Deck);
        
        while (tempDeck.Count > 0)
        {
            int randomIndex = Random.Range(0, tempDeck.Count);
            shuffledDeck.Add(tempDeck[randomIndex]);
            tempDeck.RemoveAt(randomIndex);
        }
        
        Deck = shuffledDeck;
    }
}

public class GameManager : MonoBehaviour
{
    public Game CurrentGame;
    public Transform EnemyHand, PlayerHand,
        Field, Fold;

    public GameObject EnemyHandObj, PlayerHandObj;
    public GameObject CardPref;
    private int Turn, TurnTime = 30;
    public TextMeshProUGUI TurnTimeTxt;

    public List<CardInfo> PlayerHandCards = new List<CardInfo>();
    public List<CardInfo> EnemyHandCards = new List<CardInfo>();
    public List<CardInfo> FieldCards = new List<CardInfo>();
    public List<CardInfo> FoldCards = new List<CardInfo>();
    
    public List<CardInfo> PreviousTurnCards = new List<CardInfo>(); 

    public TextMeshProUGUI PlayerQuarryTxt;
    public TextMeshProUGUI EnemyQuarryTxt;
    public TextMeshProUGUI PlayerMagicTxt;
    public TextMeshProUGUI EnemyMagicTxt;
    public TextMeshProUGUI PlayerDungeonTxt;
    public TextMeshProUGUI EnemyDungeonTxt;
    public TextMeshProUGUI PlayerBricksTxt;
    public TextMeshProUGUI EnemyBricksTxt;
    public TextMeshProUGUI PlayerGemsTxt;
    public TextMeshProUGUI EnemyGemsTxt;
    public TextMeshProUGUI PlayerRecruitsTxt;
    public TextMeshProUGUI EnemyRecruitsTxt;
    
    //RESOURCES
    //Sources
    public int PlayerQuarry;
    public int PlayerMagic;
    public int PlayerDungeon;
    public int EnemyQuarry;
    public int EnemyMagic;
    public int EnemyDungeon;
    //Resources
    public int PlayerBricks;
    public int PlayerGems;
    public int PlayerRecruits;
    public int EnemyBricks;
    public int EnemyGems;
    public int EnemyRecruits;
    
    // TOWERS AND WALLS
    public int playerTower;
    public int playerWall;
    public int enemyTower;
    public int enemyWall;
    public TextMeshProUGUI playerTowerTxt;
    public TextMeshProUGUI playerWallTxt;
    public TextMeshProUGUI enemyTowerTxt;
    public TextMeshProUGUI enemyWallTxt;

    public bool waitToDiscard;
    public bool playedAgain;
    public bool gameOver;

    public int towerVictory;
    public int resourceVictory;

    public bool isFirstPlayerTurn;
    public bool isFirstEnemyTurn;

    public bool IsPlayerTurn
    {
        get
        {
            return Turn % 2 == 0;
        }
    }

    private void Start()
    {
        Turn = 0;
        CurrentGame = new Game();

        PlayerQuarry = 2;
        EnemyQuarry = 2;
        PlayerMagic = 2;
        EnemyMagic = 2;
        PlayerDungeon = 2;
        EnemyDungeon = 2;

        PlayerBricks = 5;
        EnemyBricks = 5;
        PlayerGems = 5;
        EnemyGems = 5;
        PlayerRecruits = 5;
        EnemyRecruits = 5;

        playerTower = 15;
        playerWall = 5;
        enemyTower = playerTower;
        enemyWall = playerWall;

        GiveHandCards(CurrentGame.Deck, EnemyHand);
        GiveHandCards(CurrentGame.Deck, PlayerHand);
        
        waitToDiscard = false; 
        playedAgain = true;
        gameOver = false;

        towerVictory = 100;
        resourceVictory = 500;

        isFirstEnemyTurn = true;
        isFirstEnemyTurn = true;
    
        StartCoroutine(TurnFunc());
    }

    private void Update()
    {
        PlayerQuarryTxt.text = PlayerQuarry.ToString();
        EnemyQuarryTxt.text = EnemyQuarry.ToString();
        PlayerMagicTxt.text = PlayerMagic.ToString();
        EnemyMagicTxt.text = EnemyMagic.ToString();
        PlayerDungeonTxt.text = PlayerDungeon.ToString();
        EnemyDungeonTxt.text = EnemyDungeon.ToString();

        PlayerBricksTxt.text = PlayerBricks.ToString();
        EnemyBricksTxt.text = EnemyBricks.ToString();
        PlayerGemsTxt.text = PlayerGems.ToString();
        EnemyGemsTxt.text = EnemyGems.ToString();
        PlayerRecruitsTxt.text = PlayerRecruits.ToString();
        EnemyRecruitsTxt.text = EnemyRecruits.ToString();
        
        playerTowerTxt.text = playerTower.ToString();
        playerWallTxt.text = playerWall.ToString();
        enemyTowerTxt.text = enemyTower.ToString();
        enemyWallTxt.text = enemyWall.ToString();
    }

    void GiveHandCards(List<Card> deck, Transform hand)
    {
        int i = 0;
        while (i++ < 6 && deck.Count > 0)
        {
            GiveCardToHand(deck, hand);
        }
    }

    public void GiveCardToHand(List<Card> deck, Transform hand)
    {
        if (deck.Count == 0)
        {
            return;
        }

        Card card = deck[0];
        
        GameObject cardGO = Instantiate(CardPref, hand, false);

        if (hand == EnemyHand)
        {
            cardGO.GetComponent<CardInfo>().HideCardInfo(card);
            EnemyHandCards.Add(cardGO.GetComponent<CardInfo>());
        }
        else
        {
            cardGO.GetComponent<CardInfo>().ShowCardInfo(card);
            PlayerHandCards.Add(cardGO.GetComponent<CardInfo>());
        }
        
        deck.RemoveAt(0);
    }

    IEnumerator TurnFunc()
    {
        foreach (var cardInfo  in PlayerHandCards)
        {
            cardInfo.CheckIfPlayable(cardInfo.SelfCard);
        }
        foreach (var cardInfo  in EnemyHandCards)
        {
            cardInfo.CheckIfPlayable(cardInfo.SelfCard);
        }
        
        TurnTime = 30;
        TurnTimeTxt.text = TurnTime.ToString();

        if (IsPlayerTurn)
        {
            while (TurnTime-- > 0)
            {
                TurnTimeTxt.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
            }
        }
        else
        {
            while (TurnTime-->27)
            {
                TurnTimeTxt.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
            }

            if (EnemyHandCards.Count > 0)
            {
                EnemyTurn(EnemyHandCards);
            }
        }

        if (!gameOver)
        {
            ChangeTurn();
        }
    }

    void EnemyTurn(List<CardInfo> cards)
    {
        /*
         bool hasPlayedCard = false;

    foreach (var cardInfo in cards)
    {
        Card card = cardInfo.SelfCard;

        // Проверка ресурсов противника для разыгрывания карты
        if (card.Resource == 1)
        {
            if (card.Cost <= EnemyBricks)
            {
                hasPlayedCard = true; // Противник сыграл карту
                cardInfo.ShowCardInfo(cardInfo.SelfCard);
                cardInfo.transform.SetParent(Field);
                PlayCard playCard = cardInfo.GetComponent<PlayCard>();
                if (playCard != null)
                {
                    playCard.Play(cardInfo.SelfCard);
                }
            }
        }
        else if (card.Resource == 2)
        {
            if (card.Cost <= EnemyGems)
            {
                hasPlayedCard = true; // Противник сыграл карту
                cardInfo.ShowCardInfo(cardInfo.SelfCard);
                cardInfo.transform.SetParent(Field);
                PlayCard playCard = cardInfo.GetComponent<PlayCard>();
                if (playCard != null)
                {
                    playCard.Play(cardInfo.SelfCard);
                }
            }
        }
        else if (card.Resource == 3)
        {
            if (card.Cost <= EnemyRecruits)
            {
                hasPlayedCard = true; // Противник сыграл карту
                cardInfo.ShowCardInfo(cardInfo.SelfCard);
                cardInfo.transform.SetParent(Field);
                PlayCard playCard = cardInfo.GetComponent<PlayCard>();
                if (playCard != null)
                {
                    playCard.Play(cardInfo.SelfCard);
                }
            }
        }

        // Если была разыграна карта с PlayAgain == true, противник разыгрывает или сбрасывает ещё одну карту
        if (card.PlayAgain && hasPlayedCard)
        {
            hasPlayedCard = false; // Сброс флага после разыгрывания одной карты с PlayAgain == true
            
            // Ваш код для разыгрывания или сброса ещё одной карты
            EnemyTurn(EnemyHandCards);
        }
    }

    // Если противник не сыграл ни одной карты (не хватает ресурсов), то сбрасывается первая или вторая карта в руке
    if (!hasPlayedCard)
    {
        foreach (var cardInfo in cards)
        {
            if (cardInfo.SelfCard.Name != "Lodestone")
            {
                // Сброс первой карты
                cardInfo.gameObject.SetActive(false); // Скрываем карту
                CurrentGame.Deck.Add(cardInfo.SelfCard); // Помещаем карту в колоду
                EnemyHandCards.Remove(cardInfo); // Удаляем карту из руки противника
                Destroy(cardInfo.gameObject); // Уничтожаем игровой объект карты
                break; // Выходим из цикла после сброса карты
            }
        }
    }
    */

        int count = 1;

        for (int i = 0; i < count; i++)
        {
            cards[0].ShowCardInfo(cards[0].SelfCard);
            cards[0].transform.SetParent(Field);
            
            PlayCard playCard = cards[0].GetComponent<PlayCard>();
            if (playCard != null)
            {
                playCard.Play(cards[0].GetComponent<CardInfo>().SelfCard);
            }
            
            FieldCards.Add(cards[0]);
            EnemyHandCards.Remove(cards[0]);
        }

    }

    public void ChangeTurn()
    {
        StopAllCoroutines();
        List<CardInfo> tempPreviousTurnCards = new List<CardInfo>(PreviousTurnCards);
    
        // Очищаем FieldCards от карт предыдущего хода
        foreach (var card in tempPreviousTurnCards)
        {
            if (FieldCards.Contains(card))
            {
                FieldCards.Remove(card);
                CurrentGame.Deck.Add(card.SelfCard); // Добавляем карту в Deck
                Destroy(card.gameObject); // Уничтожаем игровой объект карты
            }
        }

        // Очищаем список PreviousTurnCards
        PreviousTurnCards.Clear(); 
    
        // Заполняем список PreviousTurnCards текущими картами на поле
        PreviousTurnCards.AddRange(FieldCards);
        foreach (var card in FieldCards)
        {
            card.NotPlayable.enabled = true;
        }
        
        Turn++;
        if (IsPlayerTurn)
        {
            PlayerHandObj.SetActive(true);

            if (isFirstPlayerTurn)
            {
                isFirstEnemyTurn = false;
            }
            else
            {
                PlayerBricks += PlayerQuarry;
                PlayerGems += PlayerMagic;
                PlayerRecruits += PlayerDungeon;
            }


            if (PlayerHandCards.Count < 6)
            {
                int t = 6 - PlayerHandCards.Count;
                for (int i = 0; i < t; i++)
                {
                    GiveCardToHand(CurrentGame.Deck, PlayerHand);
                }
            }


            /*
            foreach (var card in FoldCards)
            {
                CurrentGame.Deck.Add(card.SelfCard);
                Destroy(card.gameObject); // Уничтожаем игровой объект карты
            }
            FoldCards.Clear(); 
            */
            
            EnemyHandObj.SetActive(false);
        }
        else
        {
            if (isFirstEnemyTurn)
            {
                isFirstEnemyTurn = false;
            }
            else
            {
                EnemyBricks += EnemyQuarry;
                EnemyGems += EnemyMagic;
                EnemyRecruits += EnemyDungeon;
            }

            EnemyHandObj.SetActive(true);
            PlayerHandObj.SetActive(false);
            
            if (EnemyHandCards.Count < 6)
            {
                int t = 6 - EnemyHandCards.Count;
                for (int i = 0; i < t; i++)
                {
                    GiveCardToHand(CurrentGame.Deck, EnemyHand);
                }
            }
        }

        StartCoroutine(TurnFunc());
    }

    void GiveNewCards()
    {
        GiveCardToHand(CurrentGame.Deck, EnemyHand);
        GiveCardToHand(CurrentGame.Deck, PlayerHand);
    }
    
    public void CheckIfVictory()
    {
        if (playerTower >= towerVictory)
        {
            if (enemyTower >= towerVictory)
            {
                Debug.Log("DRAW!!!");
                StopGame();
            }
            else
            {
                Debug.Log("PLAYER WON!!!");
                StopGame();
            }
        }
        else if (enemyTower >= towerVictory)
        {
            Debug.Log("ENEMY WON!!!");
            StopGame();
        }
        else if (enemyTower == 0)
        {
            if (playerTower == 0)
            {
                Debug.Log("DRAW!!!");
                StopGame();
            }
            else
            {
                Debug.Log("PLAYER WON!!!");
                StopGame();
            }
        }
        else if (playerTower == 0)
        { 
            Debug.Log("ENEMY WON!!!");
            StopGame();
        }
        else if (PlayerBricks >= resourceVictory || PlayerGems >= resourceVictory || PlayerRecruits >= resourceVictory)
        {
            if (EnemyBricks >= resourceVictory || EnemyGems >= resourceVictory || EnemyRecruits >= resourceVictory)
            {
                Debug.Log("DRAW!!!");
                StopGame();
            }
            else
            {
                Debug.Log("PLAYER WON!!!");
                StopGame();
            }
        }
        else if (EnemyBricks >= resourceVictory || EnemyGems >= resourceVictory || EnemyRecruits >= resourceVictory)
        {
            Debug.Log("ENEMY WON!!!");
            StopGame();
        }
    }
    
    void StopGame()
    {
        gameOver = true;
        foreach (var card in PlayerHandCards)
        {
            card.isPlayable = false;
        }
    }

}
