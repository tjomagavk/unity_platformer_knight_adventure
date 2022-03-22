using ru.tj.platformer.KnightAdventure.unit;

namespace ru.tj.platformer.KnightAdventure.player {
    public interface IPlayerMovement {
        void Move(UnitData unitData);

        void EnableMovement(bool enable);
    }
}