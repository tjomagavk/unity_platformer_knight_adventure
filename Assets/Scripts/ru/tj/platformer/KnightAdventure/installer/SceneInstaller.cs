using Zenject;

namespace ru.tj.platformer.KnightAdventure.installer {
    public class SceneInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<SceneController>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();
        }
    }
}