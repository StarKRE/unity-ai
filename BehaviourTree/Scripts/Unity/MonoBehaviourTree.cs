using System;
using UnityEngine;

namespace AI.BTree
{
    [AddComponentMenu("AI/BTree/Behaviour Tree")]
    public sealed class MonoBehaviourTree : MonoBehaviour, 
        IBehaviourTree,
        IBTNodeCallback
    {
        public event Action OnComplete;

        public event Action OnFailed;

        public event Action OnAbort;

        public bool IsEnable
        {
            get { return this.enabled; }
            set { this.enabled = value; }
        }

        public bool IsRunning
        {
            get { return this.root.IsRunning; }
        }

        [SerializeField]
        private bool autoRun = true;

        [SerializeField]
        private bool loop = true;

        [SerializeField]
        private UpdateMode updateMode;

        [SerializeField]
        private MonoBTNode root;

        private void Start()
        {
            if (this.autoRun)
            {
                this.Run();
            }
        }

        private void Update()
        {
            if (this.loop && this.updateMode == UpdateMode.UPDATE)
            {
                this.Run();
            }
        }

        private void FixedUpdate()
        {
            if (this.loop && this.updateMode == UpdateMode.FIXED_UPDATE)
            {
                this.Run();
            }
        }

        private void LateUpdate()
        {
            if (this.loop && this.updateMode == UpdateMode.LATE_UPDATE)
            {
                this.Run();
            }
        }

        [ContextMenu("Run")]
        public void Run()
        {
            if (!this.root.IsRunning)
            {
                this.root.Run(callback: this);
            }
        }

        [ContextMenu("Abort")]
        public void Abort()
        {
            if (this.IsRunning)
            {
                this.root.Abort();
                this.OnAbort?.Invoke();
            }
        }

        void IBTNodeCallback.Invoke(IBTNode node, bool success)
        {
            if (success)
            {
                this.OnComplete?.Invoke();
            }
            else
            {
                this.OnFailed?.Invoke();
            }
        }

        private enum UpdateMode
        {
            UPDATE = 0,
            FIXED_UPDATE = 1,
            LATE_UPDATE = 2
        }

#if UNITY_EDITOR
        public MonoBTNode Editor_GetRoot()
        {
            return this.root;
        }
#endif
    }
}