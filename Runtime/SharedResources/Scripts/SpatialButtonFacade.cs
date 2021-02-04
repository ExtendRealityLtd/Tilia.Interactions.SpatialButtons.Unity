namespace Tilia.Interactions.SpatialButtons
{
    using Malimbe.MemberChangeMethod;
    using Malimbe.MemberClearanceMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using System;
    using Tilia.Indicators.SpatialTargets;
    using UnityEngine;
    using UnityEngine.Events;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Data.Type;

    /// <summary>
    /// The public interface into the SpatialButton Prefab.
    /// </summary>
    public class SpatialButtonFacade : MonoBehaviour
    {
        /// <summary>
        /// A container for the elements used in a button state.
        /// </summary>
        [Serializable]
        public class ButtonStyle
        {
            /// <summary>
            /// Whether this style is applied.
            /// </summary>
            [Serialized]
            [field: DocumentedByXml]
            public bool IsApplied { get; set; }
            /// <summary>
            /// The text to display on the button.
            /// </summary>
            [Serialized]
            [field: DocumentedByXml, TextArea]
            public string ButtonText { get; set; }
            /// <summary>
            /// The size for the font on the button.
            /// </summary>
            [Serialized]
            [field: DocumentedByXml]
            public float FontSize { get; set; }
            /// <summary>
            /// The color for the font on the button.
            /// </summary>
            [Serialized]
            [field: DocumentedByXml]
            public Color FontColor { get; set; }
            /// <summary>
            /// The color for the button mesh.
            /// </summary>
            [Serialized]
            [field: DocumentedByXml]
            public Color MeshColor { get; set; }
            /// <summary>
            /// The container references for the button appearance objects.
            /// </summary>
            [Serialized]
            [field: DocumentedByXml]
            public ObjectReference Container { get; set; }
        }

        #region Button Settings
        /// <summary>
        /// Whether the Spatial Button is enabled.
        /// </summary>
        [Serialized]
        [field: Header("Button Settings"), DocumentedByXml]
        public bool IsEnabled { get; set; } = true;
        #endregion

        #region Enabled Style Settings
        /// <summary>
        /// The style for the button when it is enabled but not active or being hovered over.
        /// </summary>
        [Serialized, Cleared]
        [field: Header("Enabled Style Settings"), DocumentedByXml]
        public ButtonStyle EnabledInactive { get; set; }
        /// <summary>
        /// The style for the button when it is enabled and being hovered over but not active.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public ButtonStyle EnabledHover { get; set; }
        /// <summary>
        /// The style for the button when it is enabled and active.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public ButtonStyle EnabledActive { get; set; }
        #endregion

        #region Disabled Style Settings
        /// <summary>
        /// The style for the button when it is disabled but not hovered over.
        /// </summary>
        [Serialized, Cleared]
        [field: Header("Disabled Style Settings"), DocumentedByXml]
        public ButtonStyle DisabledInactive { get; set; }
        /// <summary>
        /// The style for the button when it is disabled and being hovered over.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public ButtonStyle DisabledHover { get; set; }
        #endregion

        #region Collision Settings
        /// <summary>
        /// A <see cref="UnityEngine.Object"/> collection of objects that can collide with the spatial button.
        /// </summary>
        [Serialized]
        [field: Header("Collision Settings"), DocumentedByXml]
        public UnityObjectObservableList CollidableObjects { get; set; }
        #endregion

        #region Button Events
        /// <summary>
        /// Emitted when the button is activated.
        /// </summary>
        [Header("Button Events"), DocumentedByXml]
        public SpatialTarget.SurfaceDataUnityEvent Activated = new SpatialTarget.SurfaceDataUnityEvent();
        /// <summary>
        /// Emitted when the button is deactivated.
        /// </summary>
        [DocumentedByXml]
        public UnityEvent Deactivated = new UnityEvent();
        #endregion

        #region Reference Settings
        /// <summary>
        /// The linked Internal Setup.
        /// </summary>
        [Serialized]
        [field: Header("Reference Settings"), DocumentedByXml, Restricted]
        public SpatialButtonConfigurator Configuration { get; protected set; }
        #endregion

        /// <summary>
        /// De-selects the containing button if it is in a selected state.
        /// </summary>
        public virtual void Deselect()
        {
            Configuration.SpatialTargetFacade.Deselect();
        }

        /// <summary>
        /// Called after <see cref="IsEnabled"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(IsEnabled))]
        protected virtual void OnAfterIsEnabledChange()
        {
            Configuration.ConfigureEnabledState();
        }

        /// <summary>
        /// Called after <see cref="EnabledInactive"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(EnabledInactive))]
        protected virtual void OnAfterEnabledInactiveChange()
        {
            Configuration.ConfigureEnabledInactive();
        }

        /// <summary>
        /// Called after <see cref="EnabledHover"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(EnabledHover))]
        protected virtual void OnAfterEnabledHoverChange()
        {
            Configuration.ConfigureEnabledHover();
        }

        /// <summary>
        /// Called after <see cref="EnabledActive"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(EnabledActive))]
        protected virtual void OnAfterEnabledActiveChange()
        {
            Configuration.ConfigureEnabledActive();
        }

        /// <summary>
        /// Called after <see cref="DisabledInactive"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(DisabledInactive))]
        protected virtual void OnAfterDisabledInactiveChange()
        {
            Configuration.ConfigureDisabledInactive();
        }

        /// <summary>
        /// Called after <see cref="DisabledHover"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(DisabledHover))]
        protected virtual void OnAfterDisabledHoverChange()
        {
            Configuration.ConfigureDisabledHover();
        }
    }
}