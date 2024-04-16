using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCard : MonoBehaviour
{
    public Card SelfCard;

    private GameManager GManager;
    private CardManagerScr CManager;
    private DropPlace DPlace;

    private int attackerTower;
    private int attackerWall;
    private int defTower;
    private int defWall;
    
    private int attackerQuarry;
    private int attackerMagic;
    private int attackerDungeon;
    private int defQuarry;
    private int defMagic;
    private int defDungeon;

    private int attackerBricks;
    private int attackerGems;
    private int attackerRecruits;
    private int defBricks;
    private int defGems;
    private int defRecruits;

    void Awake()
    {
        GManager = FindObjectOfType<GameManager>();
        CManager = FindObjectOfType<CardManagerScr>();
        DPlace = FindObjectOfType<DropPlace>();
    }

    public void Play(Card card)
    {
        
        Debug.Log("Played " + card.Name + ". Player bricks " + card.PlayerBricks + ", enemy bricks " + card.EnemyBricks);

        SelfCard = card;
        if (card.PlayAgain)
        {
            GManager.playedAgain = false;
        }
        else
        {
            GManager.playedAgain = true;
        }

        if (GManager.IsPlayerTurn)
        {
            attackerTower = GManager.playerTower;
            attackerWall = GManager.playerWall;
            defTower = GManager.enemyTower;
            defWall = GManager.enemyWall;

            attackerQuarry = GManager.PlayerQuarry;
            attackerMagic = GManager.PlayerMagic;
            attackerDungeon = GManager.PlayerDungeon;
            defQuarry = GManager.EnemyQuarry;
            defMagic = GManager.EnemyMagic;
            defDungeon = GManager.EnemyDungeon;

            attackerBricks = GManager.PlayerBricks;
            attackerGems = GManager.PlayerGems;
            attackerRecruits = GManager.PlayerRecruits;
            defBricks = GManager.EnemyBricks;
            defGems = GManager.EnemyGems;
            defRecruits = GManager.EnemyRecruits;
        }
        else
        {
            attackerTower = GManager.enemyTower;
            attackerWall = GManager.enemyWall;
            defTower = GManager.playerTower;
            defWall = GManager.playerWall;

            attackerQuarry = GManager.EnemyQuarry;
            attackerMagic = GManager.EnemyMagic;
            attackerDungeon = GManager.EnemyDungeon;
            defQuarry = GManager.PlayerQuarry;
            defMagic = GManager.PlayerMagic;
            defDungeon = GManager.PlayerDungeon;

            attackerBricks = GManager.EnemyBricks;
            attackerGems = GManager.EnemyGems;
            attackerRecruits = GManager.EnemyRecruits;
            defBricks = GManager.PlayerBricks;
            defGems = GManager.PlayerGems;
            defRecruits = GManager.PlayerRecruits;
        }
        
        // Action Action Action!!!
        
        // Cost
        if (card.Resource == 1)
        {
            attackerBricks -= card.Cost;
        }
        else if (card.Resource == 2)
        {
            attackerGems -= card.Cost;
        }
        else if (card.Resource == 3)
        {
            attackerRecruits -= card.Cost;
        }
        
        // Attacks
        
        // Attack Enemy
        
        if ((defWall + card.AttackEnemy) < 0)
        {
            int i = defWall + card.AttackEnemy;
            defWall = 0;
            if ((i + defTower) < 0)
            {
                defTower = 0;
            }
            else
            {
                defTower += i;
            }
        }
        else
        {
            defWall += card.AttackEnemy;
        }
        
        // Attack Enemy Wall

        if ((defWall + card.AttackEnemyWall) < 0)
        {
            defWall = 0;
        }
        else
        {
            defWall += card.AttackEnemyWall;
        }
        
        // Attack Enemy Tower

        if ((defTower + card.AttackEnemyTower) < 0)
        {
            defTower = 0;
        }
        else
        {
            defTower += card.AttackEnemyTower;
        }
        
        // Attack Player
        
        if ((attackerWall + card.AttackPlayer) < 0)
        {
            int i = attackerWall + card.AttackPlayer;
            attackerWall = 0;
            if ((i + attackerTower) < 0)
            {
                attackerTower = 0;
            }
            else
            {
                attackerTower += i;
            }
        }
        else
        {
            attackerWall += card.AttackPlayer;
        }
        
        // Attack Player Wall

        if ((attackerWall + card.AttackPlayerWall) < 0)
        {
            attackerWall = 0;
        }
        else
        {
            attackerWall += card.AttackPlayerWall;
        }
        
        // Attack Enemy Tower

        if ((attackerTower + card.AttackPlayerTower) < 0)
        {
            attackerTower = 0;
        }
        else
        {
            attackerTower += card.AttackPlayerTower;
        }
        
        // Player Quarry

        if ((attackerQuarry + card.PlayerQuarry) < 0)
        {
            attackerQuarry = 0;
        }
        else
        {
            attackerQuarry += card.PlayerQuarry;
        }
        
        // Enemy Quarry
        
        if ((defQuarry + card.EnemyQuarry) < 0)
        {
            defQuarry = 0;
        }
        else
        {
            defQuarry += card.EnemyQuarry;
        }
        
        // Player Magic
        
        if ((attackerMagic + card.PlayerMagic) < 0)
        {
            attackerMagic = 0;
        }
        else
        {
            attackerMagic += card.PlayerMagic;
        }
        
        // Enemy Magic
        
        if ((defMagic + card.EnemyMagic) < 0)
        {
            defMagic = 0;
        }
        else
        {
            defMagic += card.EnemyMagic;
        }
        
        // Player Dungeon
        
        if ((attackerDungeon + card.PlayerDungeon) < 0)
        {
            attackerDungeon = 0;
        }
        else
        {
            attackerDungeon += card.PlayerDungeon;
        }
        
        // Enemy Dungeon
        
        if ((defDungeon + card.EnemyDungeon) < 0)
        {
            defDungeon = 0;
        }
        else
        {
            defDungeon += card.EnemyDungeon;
        }
        
        // Player Bricks
        
        if ((attackerBricks + card.PlayerBricks) < 0)
        {
            attackerBricks = 0;
        }
        else
        {
            attackerBricks += card.PlayerBricks;
        }
        
        // Enemy Bricks
        
        if ((defBricks + card.EnemyBricks) < 0)
        {
            defBricks = 0;
        }
        else
        {
            defBricks += card.EnemyBricks;
        }
        
        // Player Gems
        
        if ((attackerGems + card.PlayerGems) < 0)
        {
            attackerGems = 0;
        }
        else
        {
            attackerGems += card.PlayerGems;
        }
        
        // Enemy Gems
        
        if ((defGems + card.EnemyGems) < 0)
        {
            defGems = 0;
        }
        else
        {
            defGems += card.EnemyGems;
        }
        
        // Player Recruits
        
        if ((attackerRecruits + card.PlayerRecruits) < 0)
        {
            attackerRecruits = 0;
        }
        else
        {
            attackerRecruits += card.PlayerRecruits;
        }
        
        // Enemy Recruits
        
        if ((defRecruits + card.EnemyRecruits) < 0)
        {
            defRecruits = 0;
        }
        else
        {
            defRecruits += card.EnemyRecruits;
        }
        
        // MORE ACTION!

        switch (card.Name)
        {
            case "Mother Lode":
                if (attackerQuarry < defQuarry)
                {
                    attackerQuarry += 2;
                }
                else
                {
                    attackerQuarry += 1;
                }
                break;
            case "Copping the Tech":
                if (attackerQuarry < defQuarry)
                {
                    attackerQuarry = defQuarry;
                }
                break;
            case "Foundations":
                if (attackerWall == 0)
                {
                    attackerWall += 6;
                }
                else
                {
                    attackerWall += 3;
                }
                break;
            case "Flood Water":
                if (attackerWall < defWall)
                {
                    attackerDungeon -= 1;
                    attackerTower -= 2;
                }
                else if (attackerWall > defWall)
                {
                    defDungeon -= 1;
                    defTower -= 2;
                }
                else
                {
                    attackerDungeon -= 1;
                    attackerTower -= 2;
                    defDungeon -= 1;
                    defTower -= 2;
                }
                break;
            case "Barracks":
                if (attackerDungeon < defDungeon)
                {
                    attackerWall += 6;
                }
                break;
            case "Shift":
                int aTemp = attackerWall;
                int dTemp = defWall;
                attackerWall = dTemp;
                defWall = aTemp;
                break;
            case "Prism":
                if (GManager.IsPlayerTurn)
                {
                    GManager.GiveCardToHand(GManager.CurrentGame.Deck, GManager.PlayerHand);
                }
                else
                {
                    GManager.GiveCardToHand(GManager.CurrentGame.Deck, GManager.EnemyHand);
                }

                GManager.waitToDiscard = true;
                break;
            case "Parity":
                if (attackerMagic < defMagic)
                {
                    attackerMagic = defMagic;
                }
                else
                {
                    defMagic = attackerMagic;
                }
                break;
            case "Bag of Baubles":
                if (attackerTower < defTower)
                {
                    attackerTower += 2;
                }
                else
                {
                    attackerTower += 1;
                }
                break;
            case "Lightning Shard":
                if (attackerTower > defWall)
                {
                    defTower -= 8;
                }
                else
                {
                    if (defWall < 8)
                    {
                        int i = (8 - defWall);
                        defWall = 0;
                        defTower -= i;
                    }
                }
                break;
            case "Elven Scout":
                if (GManager.IsPlayerTurn)
                {
                    GManager.GiveCardToHand(GManager.CurrentGame.Deck, GManager.PlayerHand);
                }
                else
                {
                    GManager.GiveCardToHand(GManager.CurrentGame.Deck, GManager.EnemyHand);
                }

                GManager.waitToDiscard = true;
                break;
            case "Spizzer":
                if (defWall == 0)
                {
                    defTower -= 10;
                }
                else
                {
                    if (defWall < 6)
                    {
                        int i = (6 - defWall);
                        defWall = 0;
                        defTower -= i;
                    }
                    else
                    {
                        defWall -= 6;
                    }
                }
                break;
            case "Corrosion Cloud" :
                if (defWall > 0)
                {
                    if (defWall < 10)
                    {
                        int i = (10 - defWall);
                        defWall = 0;
                        defTower -= i;
                    }
                    else
                    {
                        defWall -= 10;
                    }
                }
                else
                {
                    defTower -= 7;
                }
                break;
            case "Unicorn":
                if (attackerMagic > defMagic)
                {
                    if (defWall < 12)
                    {
                        int i = (12 - defWall);
                        defWall = 0;
                        defTower -= i;
                    }
                    else
                    {
                        defWall -= 12;
                    }
                }
                else
                {
                    if (defWall < 8)
                    {
                        int i = (8 - defWall);
                        defWall = 0;
                        defTower -= i;
                    }
                    else
                    {
                        defWall -= 8;
                    }
                }
                break;
            case "Elven Archers":
                if (attackerWall > defWall)
                {
                    defTower -= 6;
                }
                else
                {
                    if (defWall < 6)
                    {
                        int i = (6 - defWall);
                        defWall = 0;
                        defTower -= i;
                    }
                    else
                    {
                        defWall -= 6;
                    }
                }
                break;
            case "Spearman":
                if (attackerWall > defWall)
                {
                    if (defWall < 3)
                    {
                        int i = (3 - defWall);
                        defWall = 0;
                        defTower -= i;
                    }
                    else
                    {
                        defWall -= 3;
                    }
                }
                else
                {
                    if (defWall < 2)
                    {
                        int i = (2 - defWall);
                        defWall = 0;
                        defTower -= i;
                    }
                    else
                    {
                        defWall -= 2;
                    }
                }
                break;
        }
        
        
        // Return Values
        
        if (GManager.IsPlayerTurn)
        {
            GManager.playerTower = attackerTower;
            GManager.playerWall = attackerWall;
            GManager.enemyTower = defTower;
            GManager.enemyWall = defWall;

            GManager.PlayerQuarry = attackerQuarry;
            GManager.PlayerMagic = attackerMagic;
            GManager.PlayerDungeon = attackerDungeon;
            GManager.EnemyQuarry = defQuarry;
            GManager.EnemyMagic = defMagic;
            GManager.EnemyDungeon = defDungeon;

            GManager.PlayerBricks = attackerBricks;
            GManager.PlayerGems = attackerGems;
            GManager.PlayerRecruits = attackerRecruits;
            GManager.EnemyBricks = defBricks;
            GManager.EnemyGems = defGems;
            GManager.EnemyRecruits = defRecruits;
        }
        else
        {
            GManager.enemyTower = attackerTower;
            GManager.enemyWall = attackerWall;
            GManager.playerTower = defTower;
            GManager.playerWall = defWall;

            GManager.EnemyQuarry = attackerQuarry;
            GManager.EnemyMagic = attackerMagic;
            GManager.EnemyDungeon = attackerDungeon;
            GManager.PlayerQuarry = defQuarry;
            GManager.PlayerMagic = defMagic;
            GManager.PlayerDungeon = defDungeon;

            GManager.EnemyBricks = attackerBricks;
            GManager.EnemyGems = attackerGems;
            GManager.EnemyRecruits = attackerRecruits;
            GManager.PlayerBricks = defBricks;
            GManager.PlayerGems = defGems;
            GManager.PlayerRecruits = defRecruits;
        }
    }
    
}
