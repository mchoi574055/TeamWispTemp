using System;
using UnityEditor;
using UnityEngine;

namespace Hero.Collider
{
    public class SlashCollider : HeroAttackCollider
    {
        protected new int damage = 1;
        
        [SerializeField] private Collider2D upCollider;
        [SerializeField] private Collider2D leftCollider;
        [SerializeField] private Collider2D rightCollider;
        [SerializeField] private Collider2D downCollider;

        private void Awake()
        {
            damage = 1;
        }
        
        override public void ToggleCollider(bool state, Vector3 direction)
        {
            direction = direction.normalized;
            active = state;
            
            if (!state)
            {
                upCollider.enabled = false;
                leftCollider.enabled = false;
                rightCollider.enabled = false;
                downCollider.enabled = false;
            }
            else
            {
                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    if (direction.x >= 0)
                    {
                        rightCollider.enabled = true;
                    }
                    else
                    {
                        leftCollider.enabled = true;
                    }
                }
                else
                {
                    if (direction.y >= 0)
                    {
                        upCollider.enabled = true;
                    }
                    else
                    {
                        downCollider.enabled = true;
                    }
                }
            }
        }
    }
}
