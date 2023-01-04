#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace AI.BTree.UnityEditor
{
    [CustomEditor(typeof(MonoBTNode), editorForChildClasses: true)]
    public class BTNodeEditor : OdinEditor
    {
        protected MonoBTNode node;

        protected virtual void Awake()
        {
            this.node = (MonoBTNode) this.target;
        }

        public override void OnInspectorGUI()
        {
            InspectorHelper.DrawRunningParameter(this.node.IsRunning);
            EditorGUILayout.Space(4.0f);
            base.OnInspectorGUI();
        }
    }
}
#endif