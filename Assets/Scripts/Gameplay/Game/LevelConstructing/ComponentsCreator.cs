using Bomberman.Configs;
using Bomberman.LevelGeneration;
using Bomberman.Monster;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Bomberman.LevelConstructing
{
    [Serializable]
    public class ComponentsCreator
    {
        public LoadingScreen loadingScreen;
        public LevelConfig gameConfig;
        public GameUI gameUI;
        public LevelGrid levelGrid;
        public NavMeshSurface navmeshSurface;
        public FollowerGO cameraRoot;
        public GameRulesController rulesController;
        public Player player;
        public GamePrefabs prefabs;

        public IEnumerator ProgrammCreateComponents(Action<GameComponents> callBack, Transform root)
        {
            Time.timeScale = 0;

            //show loading screen
            loadingScreen.gameObject.SetActive(true);

            yield return new WaitForSecondsRealtime(0.1f);

            //Generate game level
            Level level = gameConfig.generator.Generate();
            yield return new WaitForSecondsRealtime(0.1f);

            //Create game level
            Builder builder = new Builder(prefabs, level, root);
            Block[] blocks = builder.CreateBlocks();
            yield return new WaitForSecondsRealtime(0.1f);

            navmeshSurface.BuildNavMesh();
            //spawn monsters 

            MonsterAI[] monsters = builder.CreateCreatures();

            //Create timer
            GameObject goTimer = new GameObject("Game Timer");
            GameTimer timer = goTimer.AddComponent<GameTimer>();

            //Create Tag
            TagsObserver tagsObserver = new TagsObserver("Monster");

            //hide loading screen
            loadingScreen.gameObject.SetActive(false);


            GameComponents components = new GameComponents(blocks, timer, gameUI, levelGrid, rulesController, player, cameraRoot, gameConfig, tagsObserver);
            callBack(components);

            Time.timeScale = 1;

        }
    }
}


