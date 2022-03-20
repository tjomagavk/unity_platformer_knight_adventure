using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.player {
    public interface IPlayerInput {
        float horizontal();

        bool jump();
    }
}