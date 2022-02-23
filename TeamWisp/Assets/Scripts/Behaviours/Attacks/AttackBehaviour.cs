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
        }

        // Lifecycle
        protected void Awake()
        {
            if (anticipationComplete == null) anticipationComplete = new UnityEvent();
            anticipationComplete.AddListener(OnAnticipationComplete);
            if (actionComplete == null) actionComplete = new UnityEvent();
            actionComplete.AddListener(OnActionComplete);
        }

        protected void Start()
        {
            
        }

        protected void OnEnable()
        {
            mState = State.Anticipation;
            mAnticipationTimer = mAnticipationDuration;
            mActionTimer = mActionDuration;
        }

        protected void Update()
        {
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
        
        // Events

        protected abstract void OnAnticipationComplete();
        
        protected abstract void OnActionComplete();
        
        // Methods
        protected abstract void Anticipation();
        
        protected abstract void Action();
        
        protected abstract void Recovery();
    }
}
