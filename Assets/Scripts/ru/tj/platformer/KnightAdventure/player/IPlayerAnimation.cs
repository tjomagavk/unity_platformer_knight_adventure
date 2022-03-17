using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.player {
    public interface IPlayerAnimation {
        void MoveParamsUpdate(bool grounded, float velocityX, float velocityY);

        void ChangeDirection();
    }
}