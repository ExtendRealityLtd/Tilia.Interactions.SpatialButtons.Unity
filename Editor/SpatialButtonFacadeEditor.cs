namespace Tilia.Interactions.SpatialButtons
{
    using System;
    using UnityEditor;
    using UnityEngine;
    using Zinnia.Utility;

    [CustomEditor(typeof(SpatialButtonFacade), true)]
    public class SpatialButtonFacadeEditor : ZinniaInspector
    {
        private const string buttonText = "Render Button In Editor";
        private SpatialButtonFacade facade;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            try
            {
                EditorGUILayout.BeginHorizontal("GroupBox");
                GUILayout.FlexibleSpace();
                if (GUILayout.Button(buttonText))
                {
                    facade.Configuration.ConfigureButton();
                }
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
            }
            catch (Exception exception)
            {
                if (exception.GetType() != typeof(ExitGUIException) && exception.GetType() != typeof(ArgumentException))
                {
                    Debug.LogError(exception);
                }
            }
        }

        protected virtual void OnEnable()
        {
            facade = (SpatialButtonFacade)serializedObject.targetObject;
        }
    }
}