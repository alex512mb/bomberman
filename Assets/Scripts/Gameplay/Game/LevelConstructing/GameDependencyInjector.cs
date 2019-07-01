using UnityEngine;

namespace Bomberman.LevelConstructing
{
    public class GameDependencyInjector
    {
        private GameComponents components;
        public GameDependencyInjector(GameComponents components)
        {
            this.components = components;
        }
        public void Inject()
        {
            //Setup level grid
            components.levelGrid.size = new Vector3(components.gameConfig.generator.width, 0, components.gameConfig.generator.height);

            //Place player to free random position
            components.levelGrid.CalculateFreePositions();
            components.player.transform.position = components.levelGrid.GetRandomPos();

            //Setup camera to follow the player
            components.camera.transform.position = components.player.transform.position;
            components.camera.SetTargetFollow(components.player.transform);

            //Setup timer duration
            components.timer.SetDuration(components.gameConfig.timeLimit);//todo time limit must being in some other place

            //Auto update ui of timer when it needed
            components.timer.OnChangeTimeRemain += components.gameUI.UpdateTime;

            //Apply game rule after game is over
            components.timer.OnTimeOver += components.rulesController.OnGameTimeOver;

            //Apply game rule after player death
            components.player.GetComponent<DamageReceiver>().OnDeath += components.rulesController.OnPlayerDeath;

            //Apply game rule after all monsters dead
            components.tagsObserver.onCountChanged += components.rulesController.OnMonstersDead;
        }

        public void Uninject()
        {
            components.tagsObserver.onCountChanged -= components.rulesController.OnMonstersDead;
        }
    }
}
