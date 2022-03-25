using ru.tj.platformer.KnightAdventure.player;
using ru.tj.platformer.KnightAdventure.ui;
using ru.tj.platformer.KnightAdventure.unit;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.installer {
    public class PlayerHealthInstaller : MonoInstaller {
        [SerializeField, Range(1, 6)] private int maxHealth;
        [SerializeField, Range(1, 6)] private int currentHealth;
        [SerializeField] private HealthPanel healthPanel;

        public override void InstallBindings() {
            Container.Bind<IHealth>()
                     .To<PlayerHealth>()
                     .FromNew()
                     .AsSingle()
                     .WithArguments(maxHealth, currentHealth, healthPanel)
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