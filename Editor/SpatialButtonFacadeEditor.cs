namespace Tilia.Interactions.SpatialButtons
{
    using System;
    using UnityEditor;
    using UnityEngine;
    using Zinnia.Utility;

    [CustomEditor(typeof(SpatialButtonFacade), true)]
    public class SpatialButtonFacadeEditor : ZinniaInspector
    {
        private const string copyDataButtonText = "Copy Text and Size";
        private const string copyDataButtonTooltip = "Copies the text and font size from the Enabled Inactive state to all other states.";
        private const string previewButtonText = "Preview Style";
        private SpatialButtonFacade facade;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            try
            {
                GUILayout.BeginHorizontal("GroupBox");
                GUILayout.FlexibleSpace();
                if (GUILayout.Button(new GUIContent(copyDataButtonText, copyDataButtonTooltip)))
                {
                    CopyTextAndSize();
                }
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("GroupBox");
                GUILayout.FlexibleSpace();
                if (GUILayout.Button(previewButtonText))
                {
                    PreviewStyle();
                }
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
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

        protected virtual void CopyTextAndSize()
        {
            serializedObject.Update();
            string textToCopy = facade.EnabledInactive.ButtonText;
            float fontSizeToCopy = facade.EnabledInactive.FontSize;

            CopyTextAndSize("enabledActive", textToCopy, fontSizeToCopy);
            CopyTextAndSize("enabledHover", textToCopy, fontSizeToCopy);
            CopyTextAndSize("disabledInactive", textToCopy, fontSizeToCopy);
            CopyTextAndSize("disabledHover", textToCopy, fontSizeToCopy);

            serializedObject.ApplyModifiedProperties();
        }

        protected virtual void CopyTextAndSize(string type, string textToCopy, float fontSizeToCopy)
        {
            SerializedProperty text = serializedObject.FindProperty(type + ".buttonText");
            text.stringValue = textToCopy;

            SerializedProperty fontSize = serializedObject.FindProperty(type + ".fontSize");
            fontSize.floatValue = fontSizeToCopy;
        }

        protected virtual void PreviewStyle()
        {
            facade.Configuration.ConfigureButton();
        }
    }
}