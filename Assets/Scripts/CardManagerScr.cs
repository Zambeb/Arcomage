using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public struct Card
{
    public string Name;
    public Sprite Logo;
    public string Description;
    public int Resource;
    // 1 = bricks, 2 = gems, 3 = recruits;
    public int Cost;
    public int AttackEnemy;
    public int AttackEnemyWall;
    public int AttackEnemyTower;
    public int AttackPlayer;
    public int AttackPlayerWall;
    public int AttackPlayerTower;
    public int PlayerQuarry;
    public int EnemyQuarry;
    public int PlayerMagic;
    public int EnemyMagic;
    public int PlayerDungeon;
    public int EnemyDungeon;
    public int PlayerBricks;
    public int EnemyBricks;
    public int PlayerGems;
    public int EnemyGems;
    public int PlayerRecruits;
    public int EnemyRecruits;
    public bool PlayAgain;

    public Card(string name, string logoPath, string description, int resource, int cost, int attackEnemy,
        int attackEnemyWall, int attackEnemyTower,
        int attackPlayer, int attackPlayerWall, int attackPlayerTower, int playerQuarry, int enemyQuarry,
        int playerMagic, int enemyMagic, int playerDungeon, int enemyDungeon, int playerBricks, int enemyBricks,
        int playerGems, int enemyGems, int playerRecruits, int enemyRecruits, bool playAgain)
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
        Description = description;
        Resource = resource;
        Cost = cost;
        AttackEnemy = attackEnemy;
        AttackEnemyWall = attackEnemyWall;
        AttackEnemyTower = attackEnemyTower;
        AttackPlayer = attackPlayer;
        AttackPlayerWall = attackPlayerWall;
        AttackPlayerTower = attackPlayerTower;
        PlayerQuarry = playerQuarry;
        EnemyQuarry = enemyQuarry;
        PlayerMagic = playerMagic;
        EnemyMagic = enemyMagic;
        PlayerDungeon = playerDungeon;
        EnemyDungeon = enemyDungeon;
        PlayerBricks = playerBricks;
        EnemyBricks = enemyBricks;
        PlayerGems = playerGems;
        EnemyGems = enemyGems;
        PlayerRecruits = playerRecruits;
        EnemyRecruits = enemyRecruits;
        PlayAgain = playAgain;
    }
}

public static class CardManager
{
    public static List<Card> AllCards = new List<Card>();
}
public class CardManagerScr : MonoBehaviour
{
    public void Awake()
    {
        CardManager.AllCards.Add(new Card("Brick Shortage","Sprite/Cards/1.1",  "All players lose 8 bricks", 1, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, -8, -8, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Lucky Cache","Sprite/Cards/1.2", "+2 Bricks, +2 Gems, Play again", 1, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 2, 2, 2, 2, 
            0, 0, true));
        CardManager.AllCards.Add(new Card("Friendly Terrain","Sprite/Cards/1.3", "+1 Wall, Play again", 1, 1, 0, 
            0, 0, 0, 1, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, true));
        CardManager.AllCards.Add(new Card("Miners","Sprite/Cards/1.4","+1 Quarry", 1, 3, 0, 
            0, 0, 0, 0, 0, 1, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Mother Lode","Sprite/Cards/1.5", "If quarry < enemy quarry, +2 quarry. Else +1 quarry", 1, 4, 0, 
            0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Dwarven Miners","Sprite/Cards/1.6", "+4 Wall +1 Quarry", 1, 7, 0, 
            0, 0, 0, 0, 0, 1, 0, 
            0, 0, 0, 0, 4, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Work Overtime","Sprite/Cards/1.7", "+5 Wall, You lose 6 gems", 1, 2, 0, 
            0, 0, 0, 5, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, -6, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Copping the Tech","Sprite/Cards/1.8", "If quarry < enemy quarry, quarry = enemy quarry", 1, 5, 0, 
            0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Basic Wall","Sprite/Cards/1.9", "+3 Wall", 1, 2, 0, 
            0, 0, 0, 3, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Sturdy Wall","Sprite/Cards/1.10", "+4 Wall", 1, 3, 0, 
            0, 0, 0, 4, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Innovations","Sprite/Cards/1.11", "+1 To all player's quarries, you gain 4 gems", 1, 2, 0, 
            0, 0, 0, 0, 0, 1, 1, 
            0, 0, 0, 0, 0, 0, 4, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Foundations","Sprite/Cards/1.12", "If wall = 0, +6 wall, else +3 wall", 1, 3, 0, 
            0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Tremors","Sprite/Cards/1.13", "All walls take 5 damage. Play again", 1, 7, 0, 
            -5, 0, 0, -5, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, true));
        CardManager.AllCards.Add(new Card("Secret Room","Sprite/Cards/1.14", "+1 Magic. Play again", 1, 8, 0, 
            0, 0, 0, 0, 0, 0, 0, 
            1, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, true));
        CardManager.AllCards.Add(new Card("Earthquake","Sprite/Cards/1.15", "-1 to all players' quarries", 1, 0, 0, 
            0, 0, 0, 0, 0, -1, -1, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Big Wall","Sprite/Cards/1.16", "+6 Wall", 1, 5, 0, 
            0, 0, 0, 6, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Collapse!","Sprite/Cards/1.17", "-1 Enemy quarry", 1, 4, 0, 
            0, 0, 0, 0, 0, 0, -1, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("New Equipment","Sprite/Cards/1.18", "+2 Quarry", 1, 6, 0, 
            0, 0, 0, 0, 0, 2, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Strip Mine","Sprite/Cards/1.19", "-1 Quarry, +10 wall. You gain 5 gems", 1, 0, 0, 
            0, 0, 0, 10, 0, -1, 0, 
            0, 0, 0, 0, 0, 0, 5, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Reinforced Wall","Sprite/Cards/1.20", "+8 Wall", 1, 8, 0, 
            0, 0, 0, 8, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Portcullis","Sprite/Cards/1.21", "+5 Wall, +1 Dungeon", 1, 9, 0, 
            0, 0, 0, 5, 0, 0, 0, 
            0, 0, 1, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Crystal Rocks","Sprite/Cards/1.22", "+7 Wall, gain 7 gems", 1, 9, 0, 
            0, 0, 0, 7, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 7, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Harmonic Ore","Sprite/Cards/1.23", "+6 Wall, +3 Tower", 1, 9, 0, 
            0, 0, 0, 6, 3, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Mondo Wall","Sprite/Cards/1.24", "+12 Wall", 1, 13, 0, 
            0, 0, 0, 12, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Focused Designs","Sprite/Cards/1.25", "+8 Wall, +5 Tower", 1, 15, 0, 
            0, 0, 0, 8, 5, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Great Wall","Sprite/Cards/1.26", "+15 Wall", 1, 16, 0, 
            0, 0, 0, 15, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Rock Launcher","Sprite/Cards/1.27", "+6 Wall, 10 Damage to enemy", 1, 18, -10, 
            0, 0, 0, 6, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Dragon's Heart","Sprite/Cards/1.28", "+20 Wall, +8 Tower", 1, 24, 0, 
            0, 0, 0, 20, 8, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Forced Labor","Sprite/Cards/1.29", "+9 Wall, Lose 5 recruits", 1, 7, 0, 
            0, 0, 0, 9, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            -5, 0, false));
        CardManager.AllCards.Add(new Card("Rock Garden","Sprite/Cards/1.30", "+1 Wall, +1 Tower, +2 recruits", 1, 1, 0, 
            0, 0, 0, 1, 1, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            2, 0, false));
        CardManager.AllCards.Add(new Card("Flood Water","Sprite/Cards/1.31", "Player(s) with lowest Wall are -1 Dungeon and 2 damage to Tower", 1, 6, 0, 
            0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Barracks","Sprite/Cards/1.32", "+6 recruits, +6 Wall if dungeon < enemy dungeon, +1 dungeon", 1, 10, 0, 
            0, 0, 0, 0, 0, 0, 0, 
            0, 0, 1, 0, 0, 0, 0, 0, 
            6, 0, false));
        CardManager.AllCards.Add(new Card("Battlements","Sprite/Cards/1.33", "+7 Wall, 6 damage to enemy", 1, 14, -6, 
            0, 0, 0, 7, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Shift","Sprite/Cards/1.34", "Switch your Wall with enemy Wall", 1, 17, 0, 
            0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        
        //========================================================================================================================================
        
        CardManager.AllCards.Add(new Card("Quartz","Sprite/Cards/2.1", "+1 Tower, play again", 2, 1, 0, 
            0, 0, 0, 0, 1, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, true));
        CardManager.AllCards.Add(new Card("Smoky Quartz","Sprite/Cards/2.2", "1 Damage to enemy tower, Play again", 2, 2, 0, 
            0, -1, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, true));
        CardManager.AllCards.Add(new Card("Amethyst","Sprite/Cards/2.3", "+3 Tower", 2, 2, 0, 
            0, 0, 0, 0, 3, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Spell Weavers","Sprite/Cards/2.4", "+1 Magic", 2, 3, 0, 
            0, 0, 0, 0, 0, 0, 0, 
            1, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Prism","Sprite/Cards/2.5", "Draw 1 card. Discard 1 card. Play again", 2, 2, 0, 
            0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, true));
        CardManager.AllCards.Add(new Card("Lodestone","Sprite/Cards/2.6", "+3 Tower. This card can't be discarded without playing it", 2, 5, 0, 
            0, 0, 0, 0, 3, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Solar Flare","Sprite/Cards/2.7", "+2 Tower, 2 Damage to Enemy Tower", 2, 4, 0, 
            0, -2, 0, 0, 2, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Crystal Matrix","Sprite/Cards/2.8", "+1 Magic, +3 Tower, +1 Enemy Tower", 2, 6, 0, 
            0, 1, 0, 0, 3, 0, 0, 
            1, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Gemstone Flaw","Sprite/Cards/2.9", "3 Damage to Enemy Tower", 2, 2, 0, 
            0, -3, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Ruby","Sprite/Cards/2.10", "+5 Tower", 2, 3, 
            0, 0, 0, 0, 0, 5, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Gem Spear","Sprite/Cards/2.11", "5 Damage to Enemy Tower", 2, 4, 
            0, 0, -5, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Power Burn","Sprite/Cards/2.12", "5 Damage to your Tower, +2 Magic", 2, 3, 
            0, 0, 0, 0, 0, -5, 0, 0, 
            2, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Harmonic Vibe","Sprite/Cards/2.13", "+1 Magic, +3 Tower, +3 Wall", 2, 7, 
            0, 0, 0, 0, 3, 3, 0, 0, 
            1, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Parity","Sprite/Cards/2.14", "All player's magic equals the highest player's magic", 2, 7, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Emerald","Sprite/Cards/2.15", "+8 Tower", 2, 6, 
            0, 0, 0, 0, 0, 8, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Pearl of Wisdom","Sprite/Cards/2.16", "+5 Tower, +1 Magic", 2, 9, 
            0, 0, 0, 0, 0, 5, 0, 0, 
            1, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Shatterer","Sprite/Cards/2.17", "-1 Magic, 9 Damage to Enemy Tower", 2, 8, 
            0, 0, -9, 0, 0, 0, 0, 0, 
            -1, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Crumblestone","Sprite/Cards/2.18", "+5 Tower, Enemy loses 6 Bricks", 2, 7, 
            0, 0, 0, 0, 0, 5, 0, 0, 
            0, 0, 0, 0, 0, -6, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Sapphire","Sprite/Cards/2.19", "+11 Tower", 2, 10, 
            0, 0, 0, 0, 0, 11, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Discord","Sprite/Cards/2.20", "7 Damage to all towers, all player's Magic -1", 2, 5, 
            0, 0, -7, 0, 0, -7, 0, 0, 
            -1, -1, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Fire Ruby","Sprite/Cards/2.21", "+6 Tower, 4 Damage to all enemy tower", 2, 13, 
            0, 0, -4, 0, 0, 6, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Quarry's Help","Sprite/Cards/2.22", "+7 Tower, Lose 10 Bricks", 2, 4, 
            0, 0, 0, 0, 0, 7, 0, 0, 
            0, 0, 0, 0, -10, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Crystal Shield","Sprite/Cards/2.23", "+8 Tower, +3 Wall", 2, 12, 
            0, 0, 0, 0, 3, 8, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Empathy Gem","Sprite/Cards/2.24", "+8 Tower, +1 Dungeon", 2, 14, 
            0, 0, 0, 0, 0, 8, 0, 0, 
            0, 0, 1, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Diamond","Sprite/Cards/2.25", "+15 Tower", 2, 16, 
            0, 0, 0, 0, 0, 15, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Sanctuary","Sprite/Cards/2.26", "+10 Tower, +5 Wall, Gain 5 Recruits", 2, 15, 
            0, 0, 0, 0, 5, 10, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            5, 0, false));
        CardManager.AllCards.Add(new Card("Lava Jewel","Sprite/Cards/2.27", "+12 Tower, 6 Damage to all enemies", 2, 17, 
            0, 0, -6, 0, 0, 12, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Dragon's Eye","Sprite/Cards/2.28", "+20 Tower", 2, 21, 
            0, 0, 0, 0, 0, 20, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Crystallize","Sprite/Cards/2.29", "+11 Tower, -6 Wall", 2, 8, 
            0, 0, 0, 0, -6, 11, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Bag of Baubles","Sprite/Cards/2.30", "If Tower < Enemy Tower +2 Tower, else +1 Tower", 2, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Rainbow","Sprite/Cards/2.31", "+1 Tower to all players. You gain 3 Gems.", 2, 0, 
            0, 0, 1, 0, 0, 1, 0, 0, 
            0, 0, 0, 0, 0, 0, 3, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Apprentice","Sprite/Cards/2.32", "+4 Tower, you lose 3 Recruits, 2 Damage to enemy Tower", 2, 5, 
            0, 0, -2, 0, 0, 4, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            -3, 0, false));
        CardManager.AllCards.Add(new Card("Lightning Shard","Sprite/Cards/2.33", "If Tower > Enemy Wall, 8 damage to Enemy Tower, else 8 Damage", 2, 11, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Phase Jewel","Sprite/Cards/2.34", "+13 Tower, +6 Recruits, +6 Bricks", 2, 18, 
            0, 0, 0, 0, 0, 13, 0, 0, 
            0, 0, 0, 0, 6, 0, 0, 0, 
            6, 0, false));
        
        //====================================================================================================================
        
        CardManager.AllCards.Add(new Card("Mad Cow Disease","Sprite/Cards/3.1", "All players lose 6 Recruits", 3, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            -6, -6, false));
        CardManager.AllCards.Add(new Card("Faerie","Sprite/Cards/3.2", "2 Damage. Play again", 3, 1, 
            -2, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, true));
        CardManager.AllCards.Add(new Card("Moody Goblins","Sprite/Cards/3.3", "4 Damage. You lose 3 Gems", 3, 1, 
            -4, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, -3, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Minotaur","Sprite/Cards/3.4", "+1 Dungeon", 3, 3, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 1, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Elven Scout","Sprite/Cards/3.5", "Draw 1 card, Discard 1 card, Play again", 3, 2, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, true));
        CardManager.AllCards.Add(new Card("Goblin Mob","Sprite/Cards/3.6", "6 Damage. You take 3 Damage", 3, 3, 
            -6, 0, 0, -3, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Goblin Archers","Sprite/Cards/3.7", "3 Damage to Enemy Tower. You take 1 damage", 3, 4, 
            0, 0, -3, -1, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Shadow Faerie","Sprite/Cards/3.8", "2 Damage to Enemy Tower. Play again", 3, 6, 
            0, 0, -2, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, true));
        CardManager.AllCards.Add(new Card("Orc","Sprite/Cards/3.9", "5 Damage", 3, 3, 
            -5, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Dwarves","Sprite/Cards/3.10", "4 Damage, +3 Wall", 3, 5, 
            -4, 0, 0, 0, 3, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Little Snakes","Sprite/Cards/3.11", "4 Damage to Enemy Tower", 3, 6, 
            0, 0, -4, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Troll Trainer","Sprite/Cards/3.12", "+2 Dungeon", 3, 7, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 2, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Tower Gremlin","Sprite/Cards/3.13", "2 Damage, +4 Wall, +2 Tower", 3, 8, 
            -2, 0, 0, 0, 4, 2, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Full Moon","Sprite/Cards/3.14", "+1 to all player's Dungeon. You gain 3 Recruits", 3, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 1, 1, 0, 0, 0, 0, 
            3, 0, false));
        CardManager.AllCards.Add(new Card("Slasher","Sprite/Cards/3.15", "6 Damage", 3, 5, 
            -6, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Ogre","Sprite/Cards/3.16", "7 Damage", 3, 6, 
            -7, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Rabid Sheep","Sprite/Cards/3.17", "6 Damage. Enemy loses 3 Recruits", 3, 6, 
            -6, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, -3, false));
        CardManager.AllCards.Add(new Card("Imp","Sprite/Cards/3.18", "6 Damage. All players lose 5 Bricks, Gems and Recruits", 3, 5, 
            -6, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, -5, -5, -5, -5, 
            -5, -5, false));
        CardManager.AllCards.Add(new Card("Spizzer","Sprite/Cards/3.19", "If Enemy Wall = 0, 10 Damage, else 6 Damage", 3, 8, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Werewolf","Sprite/Cards/3.20", "9 Damage", 3, 9, 
            -9, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Corrosion Cloud","Sprite/Cards/3.21", "If enemy wall > 0, 10 Damage, else 7 Damage", 3, 11, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Unicorn","Sprite/Cards/3.22", "If Magic < Enemy Magic, 12 Damage, else 8 Damage", 3, 9, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Elven Archers","Sprite/Cards/3.23", "If Wall > Enemy Wall, 6 Damage to Enemy Tower, else 6 Damage", 3, 10, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Succubus","Sprite/Cards/3.24", "5 Damage to Enemy Tower, Enemy loses 8 Recruits", 3, 14, 
            0, 0, -5, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, -8, false));
        CardManager.AllCards.Add(new Card("Rock Stompers","Sprite/Cards/3.25", "8 Damage. -1 Enemy Quarry", 3, 11, 
            -8, 0, 0, 0, 0, 0, 0, -1, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Thief","Sprite/Cards/3.26", "Enemy loses 10 Gems, 5 bricks, you gain 1/2 amt. round up", 3, 12, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 3, -5, 5, -10, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Stone Giant","Sprite/Cards/3.27", "10 Damage, +4 Wall", 3, 15, 
            -10, 0, 0, 0, 4, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Vampire","Sprite/Cards/3.28", "10 Damage, Enemy loses 5 Recruits, -1 Enemy Dungeon", 3, 17, 
            -10, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, -1, 0, 0, 0, 0, 
            0, -5, false));
        CardManager.AllCards.Add(new Card("Dragon","Sprite/Cards/3.29", "20 Damage, Enemy loses 10 Gems, -1 Enemy Dungeon", 3, 25, 
            -20, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, -1, 0, 0, 0, -10, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Spearman","Sprite/Cards/3.30", "If Wall < Enemy Wall do 3 Damage, else do 2 Damage", 3, 2, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Gnome","Sprite/Cards/3.31", "3 Damage, +1 Gem", 3, 2, 
            -3, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 1, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Berserker","Sprite/Cards/3.32", "8 Damage, 3 Damage to your Tower", 3, 4, 
            -8, 0, 0, 0, 0, -3, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Warlord","Sprite/Cards/3.33", "13 Damage. You lose 3 Gems", 3, 13, 
            -13, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, -3, 0, 
            0, 0, false));
        CardManager.AllCards.Add(new Card("Pegasus Lancer","Sprite/Cards/3.34", "12 Damage to Enemy Tower", 3, 18, 
            0, 0, -12, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, false));
    }
}
