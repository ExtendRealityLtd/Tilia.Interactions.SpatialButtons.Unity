namespace Tilia.Interactions.SpatialButtons
{
    using Malimbe.MemberChangeMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using Tilia.Indicators.SpatialTargets;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Data.Type;
    using Zinnia.Extension;

    /// <summary>
    /// Manages the Spatial Button group.
    /// </summary>
    public class SpatialButtonGroupManager : MonoBehaviour
    {
        #region Group Settings
        /// <summary>
        /// The index for the active button.
        /// </summary>
        [Serialized]
        [field: Header("Group Settings"), DocumentedByXml]
        public int ActiveButtonIndex { get; set; } = -1;
        #endregion

        #region Reference Settings
        /// <summary>
        /// The linked button list.
        /// </summary>
        [Serialized]
        [field: Header("Reference Settings"), DocumentedByXml, Restricted]
        public UnityObjectObservableList ButtonList { get; protected set; }
        /// <summary>
        /// The linked dispatcher.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public SpatialTargetDispatcher Dispatcher { get; protected set; }
        #endregion

        /// <summary>
        /// The cached value of the <see cref="ActiveButtonIndex"/> before it is changed.
        /// </summary>
        protected int cachedIndex;
        /// <summary>
        /// Whether to ignore processing changes when the <see cref="ActiveButtonIndex"/> value changes.
        /// </summary>
        protected bool ignoreActiveButtonIndexChanges;

        /// <summary>
        /// Populates the list of valid group buttons.
        /// </summary>
        public virtual void PopulateValidButtonList()
        {
            foreach (SpatialButtonFacade button in gameObject.GetComponentsInChildren<SpatialButtonFacade>())
            {
                ButtonList.RunWhenActiveAndEnabled(() => ButtonList.AddUnique(button.Configuration.SpatialTargetFacade.gameObject));
                button.Configuration.SpatialTargetDispatcher = Dispatcher;
            }
        }

        /// <summary>
        /// Activates the initial button in the group.
        /// </summary>
        /// <param name="index">The index of the button to activate.</param>
        public virtual void ActivateButtonAtIndex(int index)
        {
            for (int buttonIndex = 0; buttonIndex < ButtonList.NonSubscribableElements.Count; buttonIndex++)
            {
                if (buttonIndex == index)
                {
                    SpatialButtonFacade spatialButton = GetSpatialButtonAtIndex(buttonIndex);
                    if (spatialButton != null)
                    {
                        spatialButton.RunWhenActiveAndEnabled(() => spatialButton.Configuration.Select());
                    }
                }
            }
        }

        /// <summary>
        /// Subscribes to the <see cref="SpatialTargetFacade.Activated"/> event.
        /// </summary>
        /// <param name="obj">The object containing the <see cref="SpatialTargetFacade"/>.</param>
        public virtual void SubscribeButtonActivated(Object obj)
        {
            SpatialTargetFacade spatialTarget = (obj as GameObject).GetComponent<SpatialTargetFacade>();
            spatialTarget.Activated.AddListener(SetActiveButtonIndexWhenButtonActivated);
        }

        /// <summary>
        /// Unsubscribes to the <see cref="SpatialTargetFacade.Activated"/> event.
        /// </summary>
        /// <param name="obj">The object containing the <see cref="SpatialTargetFacade"/>.</param>
        public virtual void UnsubscribeButtonActivated(Object obj)
        {
            SpatialTargetFacade spatialTarget = (obj as GameObject).GetComponent<SpatialTargetFacade>();
            spatialTarget.Activated.RemoveListener(SetActiveButtonIndexWhenButtonActivated);
        }

        protected virtual void OnEnable()
        {
            PopulateValidButtonList();
            ActivateButtonAtIndex(ActiveButtonIndex);
        }

        /// <summary>
        /// Sets the <see cref="ActiveButtonIndex"/> when a button is activate.
        /// </summary>
        /// <param name="data">The data to retrieve the button being activated.</param>
        protected virtual void SetActiveButtonIndexWhenButtonActivated(SurfaceData data)
        {
            SpatialTargetFacade spatialTarget = data.Transform.gameObject.TryGetComponent<SpatialTargetFacade>(false, true);
            if (spatialTarget == null)
            {
                return;
            }

            ignoreActiveButtonIndexChanges = true;
            ActiveButtonIndex = ButtonList.IndexOf(spatialTarget.gameObject);
            ignoreActiveButtonIndexChanges = false;
        }

        /// <summary>
        /// Retrieves a <see cref="SpatialButtonFacade"/> at the given index.
        /// </summary>
        /// <param name="buttonIndex">The index to retrieve.</param>
        /// <returns>The Spatial Button at the given index.</returns>
        protected virtual SpatialButtonFacade GetSpatialButtonAtIndex(int buttonIndex)
        {
            if (buttonIndex < 0 || buttonIndex >= ButtonList.NonSubscribableElements.Count)
            {
                return null;
            }

            GameObject button = (GameObject)ButtonList.NonSubscribableElements[buttonIndex];
            return button.TryGetComponent<SpatialButtonFacade>(false, true);
        }

        /// <summary>
        /// Called before <see cref="ActiveButtonIndex"/> has been changed.
        /// </summary>
        [CalledBeforeChangeOf(nameof(ActiveButtonIndex))]
        protected virtual void OnBeforeActiveButtonIndexChange()
        {
            cachedIndex = ActiveButtonIndex;
        }

        /// <summary>
        /// Called after <see cref="ActiveButtonIndex"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(ActiveButtonIndex))]
        protected virtual void OnAfterActiveButtonIndexChange()
        {
            if (ignoreActiveButtonIndexChanges)
            {
                return;
            }

            if (ActiveButtonIndex == -1)
            {
                SpatialButtonFacade spatialButton = GetSpatialButtonAtIndex(cachedIndex);
                if (spatialButton != null)
                {
                    spatialButton.RunWhenActiveAndEnabled(() => spatialButton.Deselect());
                }
            }
            else
            {
                ActivateButtonAtIndex(ActiveButtonIndex);
            }
        }
    }
}