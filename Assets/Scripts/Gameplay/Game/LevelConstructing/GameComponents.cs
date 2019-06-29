using Bomberman;
using Bomberman.Configs;
using Bomberman.LevelGeneration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman.LevelConstructing
{
    public class GameComponents
    {
        public Block[] blocks;
        public GameTimer timer;
        public GameUI gameUI;
        public LevelGrid levelGrid;
        public GameRulesController rulesController;
        public Player player;
        public FollowerGO camera;
        public LevelConfig gameConfig;
        public TagsObserver tagsObserver;

        public GameComponents(Block[] blocks, GameTimer timer, GameUI gameUI, LevelGrid levelGrid,
            GameRulesController rulesController, Player player, FollowerGO camera, LevelConfig gameConfig, TagsObserver tagsObserver)
        {
            this.blocks = blocks;
            this.timer = timer;
            this.gameUI = gameUI;
            this.levelGrid = levelGrid;
            this.rulesController = rulesController;
            this.player = player;
            this.camera = camera;
            this.gameConfig = gameConfig;
            this.tagsObserver = tagsObserver;
        }
    }
}

