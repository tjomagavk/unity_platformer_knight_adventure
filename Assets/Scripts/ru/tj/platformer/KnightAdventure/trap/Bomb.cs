using System.Collections;
using ru.tj.platformer.KnightAdventure.constant;
using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.trap {
    [RequireComponent(typeof(Animator))]
    public class Bomb : MonoBehaviour {
        public const string Boom = "BoomTrigger";

        private Animator animator;
        [SerializeField] private PointEffector2D boomPointEffector;

        private void Awake() {
            animator = GetComponent<Animator>();
            boomPointEffector.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            boomPointEffector.enabled = true;
            Activate();
        }

        private void Activate() {
            animator.SetTrigger(Boom);
            boomPointEffector.enabled = true;
            Destroy(gameObject, 0.5f);
        }
    }
}