using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.player {
    public interface IPlayerMovement {
        void Move(Rigidbody2D rigidbody);

        void Jump(Rigidbody2D rigidbody);

        void HorizontalMovement(Rigidbody2D rigidbody);

        void EnableMovement(bool enable);
    }
}