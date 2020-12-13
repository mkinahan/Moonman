﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace MalbersAnimations
{
    /// <summary>Tags for Malbers</summary>
    [CreateAssetMenu(menuName = "Malbers Animations/Scriptables/Tag")]
    public class Tag : IDs
    {
        /// <summary> Re Calculate the ID on enable</summary>
        private void OnEnable()
        {
            ID = name.GetHashCode();
        }
    }
#if UNITY_EDITOR

    [CustomEditor(typeof(Tag))]
    public class TagEd : Editor
    {
        private void OnEnable()
        {
            SerializedProperty ID = serializedObject.FindProperty("ID");
            ID.intValue = target.name.GetHashCode();
            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("Tags ID are calculated using GetHashCode()", MessageType.None);
            EditorGUI.BeginDisabledGroup(true);
            base.OnInspectorGUI();
            EditorGUI.EndDisabledGroup();
        }
    }
#endif
}