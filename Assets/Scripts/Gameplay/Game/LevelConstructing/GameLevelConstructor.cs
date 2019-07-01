using UnityEngine;

namespace Bomberman.LevelConstructing
{
    public class GameLevelConstructor : MonoBehaviour
    {
        public ComponentsCreator componentCreator;

        private GameDependencyInjector dependencyInjector;
        private void Start()
        {
            StartCoroutine(componentCreator.ProgrammCreateComponents(OnComponentsCreated, transform));
        }
        private void OnDestroy()
        {
            dependencyInjector.Uninject();
        }

        private void OnComponentsCreated(GameComponents components)
        {
            dependencyInjector = new GameDependencyInjector(components);
            dependencyInjector.Inject();
        }
    }
}
