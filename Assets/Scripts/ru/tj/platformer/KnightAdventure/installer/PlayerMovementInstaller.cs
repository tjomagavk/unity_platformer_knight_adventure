using ru.tj.platformer.KnightAdventure.player;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.installer {
    public class PlayerMovementInstaller : MonoInstaller {
        [Header("Movement speed")]
        [SerializeField, Range(0, 100)]
        private float speed = 5f;

        [SerializeField] private AnimationCurve speedCurve;
        [SerializeField, Range(0, 100)] private float jumpForce = 15f;

        public override void InstallBindings() {
            Container.Bind<IPlayerInput>()
                     .To<KeyboardPlayerInput>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();

            Container.Bind<IPlayerMovement>()
                     .To<PlayerMovement>()
                     .FromNew()
                     .AsSingle()
                     .WithArguments(speed, speedCurve, jumpForce)
                     .NonLazy();
        }

#if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues() {
            speed = 5f;
            jumpForce = 15f;
        }
#endif
    }
}