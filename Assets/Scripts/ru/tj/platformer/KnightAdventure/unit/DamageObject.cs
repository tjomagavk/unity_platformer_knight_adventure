using System;
using System.Collections.Generic;
using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.unit {
    [RequireComponent(typeof(Collider2D))]
    public class DamageObject : MonoBehaviour {
        [SerializeField, Range(1, 10)] private int powerAttack;
        [SerializeField] private bool isBullet;
        [SerializeField, Range(0.1f, 5f)] private float bulletSpeed;
        [SerializeField, Range(0f, 5f)] private float lifeTime;
        [SerializeField] private LayerMask damagedLayerMask;
        [SerializeField] private LayerMask groundLayerMask;
        private int damagedLayer;
        private int groundLayer;
        private bool currentFlipX;
        [SerializeField] private String tagSafe;
        private Collider2D area;

        private void Awake() {
            area = GetComponent<Collider2D>();
            damagedLayer = LayerMaskHelper.ToLayer(damagedLayerMask);
            groundLayer = LayerMaskHelper.ToLayer(groundLayerMask);
        }

        public void Run(bool flipX) {
            if (flipX) {
                currentFlipX = flipX;
                FlipX();
            }

            area.enabled = true;
            if (lifeTime > 0f) {
                Destroy(gameObject, lifeTime);
            }
        }

        public void FlipX(bool flipX) {
            if (!isBullet && currentFlipX != flipX) {
                currentFlipX = flipX;
                FlipX();
            }
        }

        public bool IsRangeAttack() {
            return isBullet;
        }

        private void FlipX() {
            if (area is PolygonCollider2D col) {
                Vector2[] points = col.points;
                List<Vector2> newPoints = new List<Vector2>(points.Length);
                foreach (Vector2 point in points) {
                    var newPoint = point;
                    newPoint.x = -point.x;
                    newPoints.Add(newPoint);
                }

                col.points = newPoints.ToArray();
            } else {
                Vector2 offset = area.offset;
                offset.x = -offset.x;
                area.offset = offset;
            }
        }


        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.layer == damagedLayer) {
                if (col.gameObject.transform != gameObject.transform.parent) {
                    if (col.gameObject.TryGetComponent<UnitData>(out var unitData)) {
                        unitData.TakeDamage(powerAttack);
                    }
                }
            }

            if (col.gameObject.layer == groundLayer) {
                Destroy(gameObject);
            }
        }


#if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues() {
            powerAttack = 1;
            isBullet = false;
            bulletSpeed = 1f;
        }
#endif
    }
}