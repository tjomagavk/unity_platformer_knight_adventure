using ru.tj.platformer.KnightAdventure.ui;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.installer {
    public class IntarfaceInstaller : MonoInstaller {
        [SerializeField] private Canvas canvas;
        [SerializeField] private GameObject deathWindow;

        public override void InstallBindings() {
            Canvas initCanvas = Instantiate(canvas);

            Container.Bind<WindowManager>()
                     .To<WindowManager>()
                     .FromNew()
                     .AsSingle()
                     .WithArguments(initCanvas, deathWindow)
                     .NonLazy();
        }
    }
}