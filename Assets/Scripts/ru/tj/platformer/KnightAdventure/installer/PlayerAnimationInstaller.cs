using ru.tj.platformer.KnightAdventure.player;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.installer {
    public class PlayerAnimationInstaller : MonoInstaller {
        [SerializeField] private Animator playerAnimator;

        public override void InstallBindings() {
            Container.Bind<IPlayerAnimation>()
                     .To<PlayerAnimation>()
                     .FromNew()
                     .AsSingle()
                     .WithArguments(playerAnimator)
                     .NonLazy();
        }
    }
}