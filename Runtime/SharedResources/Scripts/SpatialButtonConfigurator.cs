namespace Tilia.Interactions.SpatialButtons
{
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using System;
    using System.Collections.Generic;
    using Tilia.Indicators.SpatialTargets;
    using TMPro;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Type;

    /// <summary>
    /// Sets up the SpatialButton Prefab based on the provided user settings.
    /// </summary>
    public class SpatialButtonConfigurator : MonoBehaviour
    {
        /// <summary>
        /// A container for the elements used in a button state.
        /// </summary>
        [Serializable]
        public class ButtonElement
        {
            /// <summary>
            /// The <see cref="MeshFilter"/> for the state of the button.
            /// </summary>
            [Serialized]
            [field: DocumentedByXml, Restricted]
            public MeshFilter ButtonMeshFilter { get; protected set; }
            /// <summary>
            /// The <see cref="MeshRenderer"/> for the state of the button.
            /// </summary>
            [Serialized]
            [field: DocumentedByXml, Restricted]
            public MeshRenderer ButtonMeshRenderer { get; protected set; }
            /// <summary>
            /// The <see cref="RectTransform"/> for the state of the button.
            /// </summary>
            [Serialized]
            [field: DocumentedByXml, Restricted]
            public RectTransform TextRect { get; protected set; }
            /// <summary>
            /// The <see cref="TextMeshPro"/> for the state of the button.
            /// </summary>
            [Serialized]
            [field: DocumentedByXml, Restricted]
            public TextMeshPro Text { get; protected set; }
        }

        #region Facade Settings
        /// <summary>
        /// The public facade.
        /// </summary>
        [Serialized]
        [field: Header("Facade Settings"), DocumentedByXml, Restricted]
        public SpatialButtonFacade Facade { get; protected set; }
        /// <summary>
        /// The facade for the internal Spatial Target.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public SpatialTargetFacade SpatialTargetFacade { get; protected set; }
        /// <summary>
        /// The dispatcher for the internal Spatial Target.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml]
        public SpatialTargetDispatcher SpatialTargetDispatcher { get; set; }
        #endregion

        #region State Settings
        /// <summary>
        /// The <see cref="ButtonElement"/> for the enabled normal state of the button.
        /// </summary>
        [Serialized]
        [field: Header("State Settings"), DocumentedByXml, Restricted]
        public ButtonElement EnabledNormalState { get; protected set; }
        /// <summary>
        /// The <see cref="ButtonElement"/> for the enabled hover state of the button.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ButtonElement EnabledHoverState { get; protected set; }
        /// <summary>
        /// The <see cref="ButtonElement"/> for the enabled active state of the button.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ButtonElement EnabledActiveState { get; protected set; }
        /// <summary>
        /// The <see cref="ButtonElement"/> for the disabled normal state of the button.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ButtonElement DisabledNormalState { get; protected set; }
        /// <summary>
        /// The <see cref="ButtonElement"/> for the disabled hover state of the button.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ButtonElement DisabledHoverState { get; protected set; }
        #endregion

        /// <summary>
        /// The default scale of the text <see cref="RectTransform"/>
        /// </summary>
        private const float defaultRectTransformScale = 0.1f;

        /// <summary>
        /// Selects the containing button.
        /// </summary>
        /// <param name="data">The data to select with.</param>
        public virtual void Select(SurfaceData data)
        {
            if (SpatialTargetDispatcher == null)
            {
                SpatialTargetFacade.Configuration.TargetController.DoSelect(data);
                return;
            }

            SpatialTargetDispatcher.DoDispatchEnter(data);
            SpatialTargetDispatcher.DoDispatchSelect(data);
            SpatialTargetDispatcher.DoDispatchExit(data);
        }

        /// <summary>
        /// Selects the containing button.
        /// </summary>
        /// <param name="selectingObject">An optional <see cref="GameObject"/> that is selecting the button.</param>
        public virtual void Select(GameObject selectingObject = null)
        {
            SurfaceData data = new SurfaceData(selectingObject != null ? selectingObject.transform : Facade.transform);
            Vector3 rayOrigin = new Vector3(Facade.transform.position.x, Facade.transform.position.y, Facade.transform.position.z - (Facade.transform.localScale.z * 0.501f));
            Physics.Raycast(rayOrigin, Facade.transform.forward, out RaycastHit hit);
            data.CollisionData = hit;
            Select(data);
        }

        /// <summary>
        /// Notifies the <see cref="Facade.Activated"/> event to raise.
        /// </summary>
        /// <param name="data">The data to raise with.</param>
        public virtual void NotifyActivated(SurfaceData data)
        {
            Facade.Activated?.Invoke(data);
        }

        /// <summary>
        /// Notifies the <see cref="Facade.Deactivated"/> event to raise.
        /// </summary>
        public virtual void NotifyDeactivated()
        {
            Facade.Deactivated?.Invoke();
        }

        /// <summary>
        /// Configures the enabled state of the button.
        /// </summary>
        public virtual void ConfigureEnabledState()
        {
            SpatialTargetFacade.IsEnabled = Facade.IsEnabled;
        }

        /// <summary>
        /// Configures the enabled inactive style of the button.
        /// </summary>
        public virtual void ConfigureEnabledInactive()
        {
            ApplyButtonStyle(EnabledNormalState, Facade.EnabledInactive);
        }

        /// <summary>
        /// Configures the enabled hover style of the button.
        /// </summary>
        public virtual void ConfigureEnabledHover()
        {
            ApplyButtonStyle(EnabledHoverState, Facade.EnabledHover);
        }

        /// <summary>
        /// Configures the enabled active style of the button.
        /// </summary>
        public virtual void ConfigureEnabledActive()
        {
            ApplyButtonStyle(EnabledActiveState, Facade.EnabledActive);
        }

        /// <summary>
        /// Configures the disabled inactive style of the button.
        /// </summary>
        public virtual void ConfigureDisabledInactive()
        {
            ApplyButtonStyle(DisabledNormalState, Facade.DisabledInactive);
        }

        /// <summary>
        /// Configures the disabled hover style of the button.
        /// </summary>
        public virtual void ConfigureDisabledHover()
        {
            ApplyButtonStyle(DisabledHoverState, Facade.DisabledHover);
        }

        /// <summary>
        /// Configures the button based on the settings in the <see cref="Facade"/>.
        /// </summary>
        public virtual void ConfigureButton()
        {
            ConfigureEnabledState();
            ConfigureEnabledInactive();
            ConfigureEnabledHover();
            ConfigureEnabledActive();
            ConfigureDisabledInactive();
            ConfigureDisabledHover();
        }

        protected virtual void OnEnable()
        {
            ConfigureButton();
        }

        /// <summary>
        /// Configures the appearance of a <see cref="ButtonElement"/> button.
        /// </summary>
        /// <param name="button">The button to style.</param>
        /// <param name="style">The styles to apply.</param>
        protected virtual void ApplyButtonStyle(ButtonElement button, SpatialButtonFacade.ButtonStyle style)
        {
            if (!style.IsApplied)
            {
                return;
            }

            ApplyMeshStyle(button.ButtonMeshFilter, style);
            ApplyTextStyle(button.Text, style);
            RescaleButton(button.TextRect);
        }

        /// <summary>
        /// Styles the mesh with the given style.
        /// </summary>
        /// <param name="meshFilter">The mesh to style.</param>
        /// <param name="style">The styles to apply.</param>
        protected virtual void ApplyMeshStyle(MeshFilter meshFilter, SpatialButtonFacade.ButtonStyle style)
        {
            if (meshFilter == null)
            {
                return;
            }

            List<Color> colors = new List<Color>();
            for (int colorIndex = 0; colorIndex < meshFilter.mesh.vertices.Length; colorIndex++)
            {
                colors.Add(style.MeshColor);
            }

            meshFilter.mesh.SetColors(colors);
        }

        /// <summary>
        /// Styles the text with the given style.
        /// </summary>
        /// <param name="textMesh">The text to style.</param>
        /// <param name="style">The styles to apply.</param>
        protected virtual void ApplyTextStyle(TextMeshPro textMesh, SpatialButtonFacade.ButtonStyle style)
        {
            if (textMesh == null)
            {
                return;
            }

            textMesh.text = style.ButtonText;
            textMesh.color = style.FontColor;
            textMesh.fontSize = style.FontSize;
        }

        /// <summary>
        /// Rescales the button based on the <see cref="Facade.transform"/> scale.
        /// </summary>
        /// <param name="buttonRect">The button to resize.</param>
        protected virtual void RescaleButton(RectTransform buttonRect)
        {
            if (buttonRect == null)
            {
                return;
            }

            buttonRect.localScale = new Vector3(CalculateRectDimension(buttonRect.localScale, 0), CalculateRectDimension(buttonRect.localScale, 1), buttonRect.localScale.z);
        }

        /// <summary>
        /// Calculates the new rectangle dimension scale for the given dimensions at the given <see cref="Vector3"/> coordinate based on the <see cref="Facade.transform"/> scale.
        /// </summary>
        /// <param name="rectScale">The dimensions of the rectangle to recalculate.</param>
        /// <param name="coordinateIndex">The coordinate index of the given <see cref="Vector3"/> to apply the scale calculate to.</param>
        /// <returns>The newly calculated scaled coordinate.</returns>
        protected virtual float CalculateRectDimension(Vector3 rectScale, int coordinateIndex)
        {
            return defaultRectTransformScale / Facade.transform.localScale[coordinateIndex];
        }
    }
}