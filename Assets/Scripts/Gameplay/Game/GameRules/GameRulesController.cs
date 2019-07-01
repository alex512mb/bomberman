using UnityEngine;

/// <summary>
/// Determine game logic
/// </summary>
public abstract class GameRulesController : MonoBehaviour
{
    /// <summary>
    /// Invoke when game timer ended
    /// </summary>
    public abstract void OnGameTimeOver();
    /// <summary>
    /// Invoke when player was killed
    /// </summary>
    public abstract void OnPlayerDeath();
    /// <summary>
    /// Invoke when all enemies in game dead
    /// </summary>
    public abstract void OnMonstersDead();
}
