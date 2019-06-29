using Bomberman;
using UnityEngine;


/// <summary>
/// Override game logic to default game
/// </summary>
public class DefaultGameRules : GameRulesController
{
    public Spawner prefabArmyOfPunishment;
    public GameObject prefabOutLevel;
    public LevelGrid levelGrid;
    public override void OnGameTimeOver()
    {
        var instance = Instantiate(prefabArmyOfPunishment);
        instance.levelGrid = levelGrid;
        instance.StartSpawning();
    }
    public override void OnPlayerDeath()
    {
        Debug.Log("Player was killed");
        LevelLoader.ReloadCurrentLevel();
    }
    public override void OnMonstersDead()
    {
        Debug.Log("All enemies was killed. You are the champion!");
        CreatePortalIntoNextLevel();
    }
    private void CreatePortalIntoNextLevel()
    {
        levelGrid.CalculateFreePositions();
        Instantiate(prefabOutLevel, levelGrid.GetRandomPos(), Quaternion.identity);
    }
}
