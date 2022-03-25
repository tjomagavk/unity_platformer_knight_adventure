namespace ru.tj.platformer.KnightAdventure.unit {
    public interface IUnitAnimation {
        void MoveParamsUpdate(bool grounded, float velocityX, float velocityY);

        void ChangeDirection();

        void SimpleAttack(bool attackLeft);

        void TakeDamage();
    }
}