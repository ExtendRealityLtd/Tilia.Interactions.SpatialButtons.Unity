# Class SpatialButtonGroupManager

Manages the Spatial Button group.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [cachedIndex]
  * [ignoreActiveButtonIndexChanges]
* [Properties]
  * [ActiveButtonIndex]
  * [ButtonList]
  * [Dispatcher]
* [Methods]
  * [ActivateButtonAtIndex(Int32)]
  * [GetSpatialButtonAtIndex(Int32)]
  * [OnAfterActiveButtonIndexChange()]
  * [OnBeforeActiveButtonIndexChange()]
  * [OnEnable()]
  * [PopulateValidButtonList()]
  * [SetActiveButtonIndexWhenButtonActivated(SurfaceData)]
  * [SubscribeButtonActivated(Object)]
  * [UnsubscribeButtonActivated(Object)]

## Details

##### Inheritance

* System.Object
* SpatialButtonGroupManager

##### Namespace

* [Tilia.Interactions.SpatialButtons]

##### Syntax

```
public class SpatialButtonGroupManager : MonoBehaviour
```

### Fields

#### cachedIndex

The cached value of the [ActiveButtonIndex] before it is changed.

##### Declaration

```
protected int cachedIndex
```

#### ignoreActiveButtonIndexChanges

Whether to ignore processing changes when the [ActiveButtonIndex] value changes.

##### Declaration

```
protected bool ignoreActiveButtonIndexChanges
```

### Properties

#### ActiveButtonIndex

The index for the active button.

##### Declaration

```
public int ActiveButtonIndex { get; set; }
```

#### ButtonList

The linked button list.

##### Declaration

```
public UnityObjectObservableList ButtonList { get; protected set; }
```

#### Dispatcher

The linked dispatcher.

##### Declaration

```
public SpatialTargetDispatcher Dispatcher { get; protected set; }
```

### Methods

#### ActivateButtonAtIndex(Int32)

Activates the initial button in the group.

##### Declaration

```
public virtual void ActivateButtonAtIndex(int index)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | index | The index of the button to activate. |

#### GetSpatialButtonAtIndex(Int32)

Retrieves a [SpatialButtonFacade] at the given index.

##### Declaration

```
protected virtual SpatialButtonFacade GetSpatialButtonAtIndex(int buttonIndex)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | buttonIndex | The index to retrieve. |

##### Returns

| Type | Description |
| --- | --- |
| [SpatialButtonFacade] | The Spatial Button at the given index. |

#### OnAfterActiveButtonIndexChange()

Called after [ActiveButtonIndex] has been changed.

##### Declaration

```
protected virtual void OnAfterActiveButtonIndexChange()
```

#### OnBeforeActiveButtonIndexChange()

Called before [ActiveButtonIndex] has been changed.

##### Declaration

```
protected virtual void OnBeforeActiveButtonIndexChange()
```

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
```

#### PopulateValidButtonList()

Populates the list of valid group buttons.

##### Declaration

```
public virtual void PopulateValidButtonList()
```

#### SetActiveButtonIndexWhenButtonActivated(SurfaceData)

Sets the [ActiveButtonIndex] when a button is activate.

##### Declaration

```
protected virtual void SetActiveButtonIndexWhenButtonActivated(SurfaceData data)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| SurfaceData | data | The data to retrieve the button being activated. |

#### SubscribeButtonActivated(Object)

Subscribes to the SpatialTargetFacade.Activated event.

##### Declaration

```
public virtual void SubscribeButtonActivated(Object obj)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| Object | obj | The object containing the SpatialTargetFacade. |

#### UnsubscribeButtonActivated(Object)

Unsubscribes to the SpatialTargetFacade.Activated event.

##### Declaration

```
public virtual void UnsubscribeButtonActivated(Object obj)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| Object | obj | The object containing the SpatialTargetFacade. |

[Tilia.Interactions.SpatialButtons]: README.md
[ActiveButtonIndex]: SpatialButtonGroupManager.md#ActiveButtonIndex
[ActiveButtonIndex]: SpatialButtonGroupManager.md#ActiveButtonIndex
[SpatialButtonFacade]: SpatialButtonFacade.md
[ActiveButtonIndex]: SpatialButtonGroupManager.md#ActiveButtonIndex
[ActiveButtonIndex]: SpatialButtonGroupManager.md#ActiveButtonIndex
[ActiveButtonIndex]: SpatialButtonGroupManager.md#ActiveButtonIndex
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[cachedIndex]: #cachedIndex
[ignoreActiveButtonIndexChanges]: #ignoreActiveButtonIndexChanges
[Properties]: #Properties
[ActiveButtonIndex]: #ActiveButtonIndex
[ButtonList]: #ButtonList
[Dispatcher]: #Dispatcher
[Methods]: #Methods
[ActivateButtonAtIndex(Int32)]: #ActivateButtonAtIndexInt32
[GetSpatialButtonAtIndex(Int32)]: #GetSpatialButtonAtIndexInt32
[OnAfterActiveButtonIndexChange()]: #OnAfterActiveButtonIndexChange
[OnBeforeActiveButtonIndexChange()]: #OnBeforeActiveButtonIndexChange
[OnEnable()]: #OnEnable
[PopulateValidButtonList()]: #PopulateValidButtonList
[SetActiveButtonIndexWhenButtonActivated(SurfaceData)]: #SetActiveButtonIndexWhenButtonActivatedSurfaceData
[SubscribeButtonActivated(Object)]: #SubscribeButtonActivatedObject
[UnsubscribeButtonActivated(Object)]: #UnsubscribeButtonActivatedObject
