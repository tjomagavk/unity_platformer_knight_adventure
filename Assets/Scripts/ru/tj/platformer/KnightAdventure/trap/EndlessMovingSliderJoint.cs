using ru.tj.platformer.KnightAdventure.constant;
using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.trap {
    [RequireComponent(typeof(SliderJoint2D))]
    public class EndlessMovingSliderJoint : MonoBehaviour {
        private SliderJoint2D sliderJoint;

        private void Awake() {
            sliderJoint = GetComponent<SliderJoint2D>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag(TagVars.PlatformWall)) {
                JointMotor2D motor = sliderJoint.motor;
                motor.motorSpeed = -motor.motorSpeed;
                sliderJoint.motor = motor;
            }
        }
    }
}