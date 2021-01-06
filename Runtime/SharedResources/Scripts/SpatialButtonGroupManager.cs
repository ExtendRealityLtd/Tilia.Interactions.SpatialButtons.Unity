namespace Tilia.Interactions.SpatialButtons
{
    using Malimbe.MemberChangeMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using Tilia.Indicators.SpatialTargets;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
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
        /// Populates the list of valid group buttons.
        /// </summary>
        public virtual void PopulateValidButtonList()
        {
            ButtonList.Clear();
            foreach (SpatialButtonFacade button in gameObject.GetComponentsInChildren<SpatialButtonFacade>())
            {
                ButtonList.Add(button.Configuration.SpatialTargetFacade.gameObject);
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

        protected virtual void OnEnable()
        {
            PopulateValidButtonList();
            ActivateButtonAtIndex(ActiveButtonIndex);
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