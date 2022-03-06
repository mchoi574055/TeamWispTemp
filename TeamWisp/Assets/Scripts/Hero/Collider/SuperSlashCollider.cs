using System;
using UnityEngine;

namespace Hero.Collider
{
    public class SuperSlashCollider : HeroAttackCollider
    {
        private void Awake()
        {
            damage = 5;
        }

        [SerializeField] private Collider2D soleCollider;
        
        override public void ToggleCollider(bool state, Vector3 direction)
        {
            active = state;
            soleCollider.enabled = state;
        }
    }
}