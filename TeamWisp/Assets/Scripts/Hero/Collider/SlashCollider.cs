using System;
using UnityEditor;
using UnityEngine;

namespace Hero.Collider
{
    public class SlashCollider : MonoBehaviour
    {
        [SerializeField] private GameObject upCollider;
        [SerializeField] private GameObject leftCollider;
        [SerializeField] private GameObject rightCollider;
        [SerializeField] private GameObject downCollider;
        
        private bool active = false;

        public void ToggleCollider(bool state, Vector3 direction)
        {
            direction = direction.normalized;
            active = state;
            
            if (!state)
            {
                upCollider.SetActive(false);
                leftCollider.SetActive(false);
                rightCollider.SetActive(false);
                downCollider.SetActive(false);
            }
            else
            {
                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    if (Mathf.Abs(direction.x) >= 0)
                    {
                        rightCollider.SetActive(true);
                    }
                    else
                    {
                        leftCollider.SetActive(true);
                    }
                }
                else
                {
                    if (Mathf.Abs(direction.y) >= 0)
                    {
                        upCollider.SetActive(true);
                    }
                    else
                    {
                        downCollider.SetActive(true);
                    }
                }
            }
        }

        public bool IsSlashActive()
        {
            return active;
        }
    }
}
