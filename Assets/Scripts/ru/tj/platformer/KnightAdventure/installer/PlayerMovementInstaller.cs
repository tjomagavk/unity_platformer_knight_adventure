using ru.tj.platformer.KnightAdventure.player;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.installer {
    public class PlayerMovementInstaller : MonoInstaller {
        [SerializeField, Range(0, 100)] private float speed = 50f;
        [SerializeField, Range(0, 100)] private float jumpForce = 50f;
        [SerializeField] private Transform groundChecker;
        [SerializeField, Range(0, 10)] private float groundCheckRadius = 0.1f;
        [SerializeField] private LayerMask groundLayerMask;
        [SerializeField] private SpriteRenderer playerSprite;

        public override void InstallBindings() {
            Container.Bind<IPlayerMovement>()
                     .To<KeyboardPlayerMovement>()
                     .FromNew()
                     .AsSingle()
                     .WithArguments(
                                    speed,
                                    jumpForce,
                                    groundChecker,
                                    groundCheckRadius,
                                    groundLayerMask,
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