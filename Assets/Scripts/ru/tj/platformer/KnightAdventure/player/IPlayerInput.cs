namespace ru.tj.platformer.KnightAdventure.player {
    public interface IPlayerInput {
        float Horizontal();

        bool Jump();

        bool SimpleAttack();
    }
}