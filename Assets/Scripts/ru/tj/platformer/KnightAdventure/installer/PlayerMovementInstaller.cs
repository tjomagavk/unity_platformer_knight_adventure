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

        [Header("Grounded checker settings")]
        [SerializeField]
        private Transform groundChecker;

        [SerializeField, Range(0, 10)] private float groundCheckRadius = 0.1f;
        [SerializeField] private LayerMask groundLayerMask;

        [Header("Other settings")]
        [SerializeField]
        private SpriteRenderer playerSprite;

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
                     .WithArguments(speed,
                                    speedCurve,
                                    jumpForce,
                                    new GroundChecker(groundChecker, groundCheckRadius, groundLayerMask),
                                    playerSprite)
                     .NonLazy();
        }

#if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues() {
            speed = 5f;
            jumpForce = 15f;
            groundCheckRadius = 0.1f;
        }
#endif
    }
}