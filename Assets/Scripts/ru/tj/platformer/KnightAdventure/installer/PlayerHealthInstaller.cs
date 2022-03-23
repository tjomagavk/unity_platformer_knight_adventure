using ru.tj.platformer.KnightAdventure.player;
using ru.tj.platformer.KnightAdventure.unit;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.installer {
    public class PlayerHealthInstaller : MonoInstaller {
        [SerializeField, Range(1, 6)] private int maxHealth;
        [SerializeField, Range(1, 6)] private int currentHealth;

        public override void InstallBindings() {
            Container.Bind<IHealth>()
                     .To<PlayerHealth>()
                     .FromNew()
                     .AsSingle()
                     .WithArguments(maxHealth, currentHealth)
                     .NonLazy();
        }

#if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues() {
            maxHealth = 3;
            currentHealth = 3;
        }
#endif
    }
}