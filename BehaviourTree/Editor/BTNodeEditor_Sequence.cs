#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace AI.BTree.UnityEditor
{
    [CustomEditor(typeof(MonoBTNode_Sequence))]
    public sealed class BTNodeEditor_Sequence : Editor
    {
        private MonoBTNode node;

        private void Awake()
        {
            this.node = (MonoBTNode) this.target;
        }

        public override void OnInspectorGUI()
        {
            InspectorHelper.DrawRunningParameter(this.node.IsRunning);
            EditorGUILayout.Space(4.0f);

            GUI.enabled = false;
            GUILayout.Label("Children");

            var transform = this.node.transform;
            foreach (Transform child in transform)
            {
                if (child.gameObject.activeSelf && child.TryGetComponent(out MonoBTNode node))
                {
                    EditorGUILayout.ObjectField(obj: node, objType: typeof(MonoBTNode), allowSceneObjects: true);
                }
            }

            GUI.enabled = true;
        }
    }
}
#endif