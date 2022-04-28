namespace Tilia.Interactions.SpatialButtons
{
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
        [Header("Group Settings")]
        [Tooltip("The index for the active button.")]
        [SerializeField]
        private int activeButtonIndex = -1;
        /// <summary>
        /// The index for the active button.
        /// </summary>
        public int ActiveButtonIndex
        {
            get
            {
                return activeButtonIndex;
            }
            set
            {
                if (this.IsMemberChangeAllowed())
                {
                    OnBeforeActiveButtonIndexChange();
                }
                activeButtonIndex = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterActiveButtonIndexChange();
                }
            }
        }
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The linked button list.")]
        [SerializeField]
        [Restricted]
        private UnityObjectObservableList buttonList;
        /// <summary>
        /// The linked button list.
        /// </summary>
        public UnityObjectObservableList ButtonList
        {
            get
            {
                return buttonList;
            }
            protected set
            {
                buttonList = value;
            }
        }
        [Tooltip("The linked dispatcher.")]
        [SerializeField]
        [Restricted]
        private SpatialTargetDispatcher dispatcher;
        /// <summary>
        /// The linked dispatcher.
        /// </summary>
        public SpatialTargetDispatcher Dispatcher
        {
            get
            {
                return dispatcher;
            }
            protected set
            {
                dispatcher = value;
            }
        }
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
        protected virtual void OnBeforeActiveButtonIndexChange()
        {
            cachedIndex = ActiveButtonIndex;
        }

        /// <summary>
        /// Called after <see cref="ActiveButtonIndex"/> has been changed.
        /// </summary>
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