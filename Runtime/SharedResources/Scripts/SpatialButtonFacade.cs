namespace Tilia.Interactions.SpatialButtons
{
    using System;
    using Tilia.Indicators.SpatialTargets;
    using UnityEngine;
    using UnityEngine.Events;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Data.Type;
    using Zinnia.Extension;

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
            [Tooltip("Whether this style is applied.")]
            [SerializeField]
            private bool isApplied;
            /// <summary>
            /// Whether this style is applied.
            /// </summary>
            public bool IsApplied
            {
                get
                {
                    return isApplied;
                }
                set
                {
                    isApplied = value;
                }
            }
            [Tooltip("The text to display on the button.")]
            [SerializeField]
            [TextArea]
            private string buttonText;
            /// <summary>
            /// The text to display on the button.
            /// </summary>
            public string ButtonText
            {
                get
                {
                    return buttonText;
                }
                set
                {
                    buttonText = value;
                }
            }
            [Tooltip("The size for the font on the button.")]
            [SerializeField]
            private float fontSize;
            /// <summary>
            /// The size for the font on the button.
            /// </summary>
            public float FontSize
            {
                get
                {
                    return fontSize;
                }
                set
                {
                    fontSize = value;
                }
            }
            [Tooltip("The color for the font on the button.")]
            [SerializeField]
            private Color fontColor;
            /// <summary>
            /// The color for the font on the button.
            /// </summary>
            public Color FontColor
            {
                get
                {
                    return fontColor;
                }
                set
                {
                    fontColor = value;
                }
            }
            [Tooltip("The color for the button mesh.")]
            [SerializeField]
            private Color meshColor;
            /// <summary>
            /// The color for the button mesh.
            /// </summary>
            public Color MeshColor
            {
                get
                {
                    return meshColor;
                }
                set
                {
                    meshColor = value;
                }
            }
            [Tooltip("The container references for the button appearance objects.")]
            [SerializeField]
            private ObjectReference container;
            /// <summary>
            /// The container references for the button appearance objects.
            /// </summary>
            public ObjectReference Container
            {
                get
                {
                    return container;
                }
                protected set
                {
                    container = value;
                }
            }
        }

        #region Button Settings
        [Header("Button Settings")]
        [Tooltip("The container references for the button appearance objects.")]
        [SerializeField]
        private bool isEnabled = true;
        /// <summary>
        /// Whether the Spatial Button is enabled.
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterIsEnabledChange();
                }
            }
        }
        #endregion

        #region Enabled Style Settings
        [Header("Enabled Style Settings")]
        [Tooltip("The style for the button when it is enabled but not active or being hovered over.")]
        [SerializeField]
        private ButtonStyle enabledInactive;
        /// <summary>
        /// The style for the button when it is enabled but not active or being hovered over.
        /// </summary>
        public ButtonStyle EnabledInactive
        {
            get
            {
                return enabledInactive;
            }
            set
            {
                enabledInactive = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterEnabledInactiveChange();
                }
            }
        }
        [Tooltip("The style for the button when it is enabled and being hovered over but not active.")]
        [SerializeField]
        private ButtonStyle enabledHover;
        /// <summary>
        /// The style for the button when it is enabled and being hovered over but not active.
        /// </summary>
        public ButtonStyle EnabledHover
        {
            get
            {
                return enabledHover;
            }
            set
            {
                enabledHover = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterEnabledHoverChange();
                }
            }
        }
        [Tooltip("The style for the button when it is enabled and active.")]
        [SerializeField]
        private ButtonStyle enabledActive;
        /// <summary>
        /// The style for the button when it is enabled and active.
        /// </summary>
        public ButtonStyle EnabledActive
        {
            get
            {
                return enabledActive;
            }
            set
            {
                enabledActive = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterEnabledActiveChange();
                }
            }
        }
        #endregion

        #region Disabled Style Settings
        [Header("Disabled Style Settings")]
        [Tooltip("The style for the button when it is disabled but not hovered over.")]
        [SerializeField]
        private ButtonStyle disabledInactive;
        /// <summary>
        /// The style for the button when it is disabled but not hovered over.
        /// </summary>
        public ButtonStyle DisabledInactive
        {
            get
            {
                return disabledInactive;
            }
            set
            {
                disabledInactive = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterDisabledInactiveChange();
                }
            }
        }
        [Tooltip("The style for the button when it is disabled and being hovered over.")]
        [SerializeField]
        private ButtonStyle disabledHover;
        /// <summary>
        /// The style for the button when it is disabled and being hovered over.
        /// </summary>
        public ButtonStyle DisabledHover
        {
            get
            {
                return disabledHover;
            }
            set
            {
                disabledHover = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterDisabledHoverChange();
                }
            }
        }
        #endregion

        #region Collision Settings
        [Header("Collision Settings")]
        [Tooltip("A UnityEngine.Object collection of objects that can collide with the spatial button.")]
        [SerializeField]
        private UnityObjectObservableList collidableObjects;
        /// <summary>
        /// A <see cref="UnityEngine.Object"/> collection of objects that can collide with the spatial button.
        /// </summary>
        public UnityObjectObservableList CollidableObjects
        {
            get
            {
                return collidableObjects;
            }
            set
            {
                collidableObjects = value;
            }
        }
        #endregion

        #region Button Events
        /// <summary>
        /// Emitted when the button is activated.
        /// </summary>
        [Header("Button Events")]
        public SpatialTarget.SurfaceDataUnityEvent Activated = new SpatialTarget.SurfaceDataUnityEvent();
        /// <summary>
        /// Emitted when the button is deactivated.
        /// </summary>
        public UnityEvent Deactivated = new UnityEvent();
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The linked Internal Setup.")]
        [SerializeField]
        [Restricted]
        private SpatialButtonConfigurator configuration;
        /// <summary>
        /// The linked Internal Setup.
        /// </summary>
        public SpatialButtonConfigurator Configuration
        {
            get
            {
                return configuration;
            }
            protected set
            {
                configuration = value;
            }
        }
        #endregion

        /// <summary>
        /// Clears <see cref="EnabledInactive"/>.
        /// </summary>
        public virtual void ClearEnabledInactive()
        {
            if (!this.IsValidState())
            {
                return;
            }

            EnabledInactive = default;
        }

        /// <summary>
        /// Clears <see cref="EnabledHover"/>.
        /// </summary>
        public virtual void ClearEnabledHover()
        {
            if (!this.IsValidState())
            {
                return;
            }

            EnabledHover = default;
        }

        /// <summary>
        /// Clears <see cref="EnabledActive"/>.
        /// </summary>
        public virtual void ClearEnabledActive()
        {
            if (!this.IsValidState())
            {
                return;
            }

            EnabledActive = default;
        }

        /// <summary>
        /// Clears <see cref="DisabledInactive"/>.
        /// </summary>
        public virtual void ClearDisabledInactive()
        {
            if (!this.IsValidState())
            {
                return;
            }

            DisabledInactive = default;
        }

        /// <summary>
        /// Clears <see cref="DisabledHover"/>.
        /// </summary>
        public virtual void ClearDisabledHover()
        {
            if (!this.IsValidState())
            {
                return;
            }

            DisabledHover = default;
        }

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
        protected virtual void OnAfterIsEnabledChange()
        {
            Configuration.ConfigureEnabledState();
        }

        /// <summary>
        /// Called after <see cref="EnabledInactive"/> has been changed.
        /// </summary>
        protected virtual void OnAfterEnabledInactiveChange()
        {
            Configuration.ConfigureEnabledInactive();
        }

        /// <summary>
        /// Called after <see cref="EnabledHover"/> has been changed.
        /// </summary>
        protected virtual void OnAfterEnabledHoverChange()
        {
            Configuration.ConfigureEnabledHover();
        }

        /// <summary>
        /// Called after <see cref="EnabledActive"/> has been changed.
        /// </summary>
        protected virtual void OnAfterEnabledActiveChange()
        {
            Configuration.ConfigureEnabledActive();
        }

        /// <summary>
        /// Called after <see cref="DisabledInactive"/> has been changed.
        /// </summary>
        protected virtual void OnAfterDisabledInactiveChange()
        {
            Configuration.ConfigureDisabledInactive();
        }

        /// <summary>
        /// Called after <see cref="DisabledHover"/> has been changed.
        /// </summary>
        protected virtual void OnAfterDisabledHoverChange()
        {
            Configuration.ConfigureDisabledHover();
        }
    }
}