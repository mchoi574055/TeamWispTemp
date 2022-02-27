using System;
using UnityEngine;
using UnityEngine.Events;

namespace Behaviours.Attacks
{
    public abstract class AttackBehavior : MonoBehaviour
    {
        protected enum State
        {
            Anticipation,
            Action,
            Recovery
        }
        
        private bool initialized = false;
        
        // Fields
        protected float mAnticipationDuration;
        protected float mActionDuration;

        // Member Variables
        public UnityEvent anticipationComplete;
        public UnityEvent actionComplete;
        protected State mState = State.Anticipation;
        protected float mAnticipationTimer;
        protected float mActionTimer;

        protected void Init(float anticipationDuration, float actionDuration)
        {
            mAnticipationDuration = anticipationDuration;
            mActionDuration = actionDuration;

            initialized = true;
        }

        // Lifecycle
        protected void Awake()
        {
            if (anticipationComplete == null) anticipationComplete = new UnityEvent();
            if (actionComplete == null) actionComplete = new UnityEvent();
        }

        protected void OnEnable()
        {
            if (!initialized) return;
            OnStart();
        }

        protected void OnDisable()
        {
            if (!initialized) return;
            OnComplete();
        }

        protected void Update()
        {
            if (!initialized) return;
            switch (mState)
            {
                case State.Anticipation:
                    mAnticipationTimer -= Time.deltaTime;
                    Anticipation();
                    if (mAnticipationTimer <= 0)
                    {
                        mState = State.Action;
                        anticipationComplete.Invoke();
                    }
                    break;
                case State.Action:
                    mActionTimer -= Time.deltaTime;
                    Action();
                    if (mActionTimer <= 0)
                    {
                        mState = State.Recovery;
                        actionComplete.Invoke();
                    }
                    break;
                case State.Recovery:
                    Recovery();
                    break;
            }
        }
        
        // Custom Lifecycle

        protected virtual void OnStart()
        {
            anticipationComplete.AddListener(OnAnticipationComplete);
            actionComplete.AddListener(OnActionComplete);
            
            mState = State.Anticipation;
            mAnticipationTimer = mAnticipationDuration;
            mActionTimer = mActionDuration;
        }

        protected virtual void Anticipation()
        {
            
        }

        protected virtual void OnAnticipationComplete()
        {
            
        }

        protected virtual void Action()
        {
            
        }

        protected virtual void OnActionComplete()
        {
            
        }
        
        protected virtual void Recovery()
        {
            
        }

        protected virtual void OnComplete()
        {
            anticipationComplete.RemoveAllListeners();
            actionComplete.RemoveAllListeners();
        }
    }
}
