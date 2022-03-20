using ru.tj.platformer.KnightAdventure.constant;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.player {
    public class KeyboardPlayerInput : IPlayerInput {
        public float horizontal() {
            return Input.GetAxis(AxisVars.Horizontal);
        }

        public bool jump() {
            return Input.GetButtonDown(AxisVars.Jump);
        }
    }
}