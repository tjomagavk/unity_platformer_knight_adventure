using ru.tj.platformer.KnightAdventure.constant;
using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.player {
    public class KeyboardPlayerInput : IPlayerInput {
        public float Horizontal() {
            return Input.GetAxis(AxisVars.Horizontal);
        }

        public bool Jump() {
            return Input.GetButtonDown(AxisVars.Jump);
        }

        public bool SimpleAttack() {
            return Input.GetButtonDown(AxisVars.Fire1);
        }
    }
}