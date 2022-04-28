# Class SpatialButtonFacade

The public interface into the SpatialButton Prefab.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [Activated]
  * [Deactivated]
* [Properties]
  * [CollidableObjects]
  * [Configuration]
  * [DisabledHover]
  * [DisabledInactive]
  * [EnabledActive]
  * [EnabledHover]
  * [EnabledInactive]
  * [IsEnabled]
* [Methods]
  * [ClearDisabledHover()]
  * [ClearDisabledInactive()]
  * [ClearEnabledActive()]
  * [ClearEnabledHover()]
  * [ClearEnabledInactive()]
  * [Deselect()]
  * [OnAfterDisabledHoverChange()]
  * [OnAfterDisabledInactiveChange()]
  * [OnAfterEnabledActiveChange()]
  * [OnAfterEnabledHoverChange()]
  * [OnAfterEnabledInactiveChange()]
  * [OnAfterIsEnabledChange()]

## Details

##### Inheritance

* System.Object
* SpatialButtonFacade

##### Namespace

* [Tilia.Interactions.SpatialButtons]

##### Syntax

```
public class SpatialButtonFacade : MonoBehaviour
```

### Fields

#### Activated

Emitted when the button is activated.

##### Declaration

```
public SpatialTarget.SurfaceDataUnityEvent Activated
```

#### Deactivated

Emitted when the button is deactivated.

##### Declaration

```
public UnityEvent Deactivated
```

### Properties

#### CollidableObjects

A UnityEngine.Object collection of objects that can collide with the spatial button.

##### Declaration

```
public UnityObjectObservableList CollidableObjects { get; set; }
```

#### Configuration

The linked Internal Setup.

##### Declaration

```
public SpatialButtonConfigurator Configuration { get; protected set; }
```

#### DisabledHover

The style for the button when it is disabled and being hovered over.

##### Declaration

```
public SpatialButtonFacade.ButtonStyle DisabledHover { get; set; }
```

#### DisabledInactive

The style for the button when it is disabled but not hovered over.

##### Declaration

```
public SpatialButtonFacade.ButtonStyle DisabledInactive { get; set; }
```

#### EnabledActive

The style for the button when it is enabled and active.

##### Declaration

```
public SpatialButtonFacade.ButtonStyle EnabledActive { get; set; }
```

#### EnabledHover

The style for the button when it is enabled and being hovered over but not active.

##### Declaration

```
public SpatialButtonFacade.ButtonStyle EnabledHover { get; set; }
```

#### EnabledInactive

The style for the button when it is enabled but not active or being hovered over.

##### Declaration

```
public SpatialButtonFacade.ButtonStyle EnabledInactive { get; set; }
```

#### IsEnabled

Whether the Spatial Button is enabled.

##### Declaration

```
public bool IsEnabled { get; set; }
```

### Methods

#### ClearDisabledHover()

Clears [DisabledHover].

##### Declaration

```
public virtual void ClearDisabledHover()
```

#### ClearDisabledInactive()

Clears [DisabledInactive].

##### Declaration

```
public virtual void ClearDisabledInactive()
```

#### ClearEnabledActive()

Clears [EnabledActive].

##### Declaration

```
public virtual void ClearEnabledActive()
```

#### ClearEnabledHover()

Clears [EnabledHover].

##### Declaration

```
public virtual void ClearEnabledHover()
```

#### ClearEnabledInactive()

Clears [EnabledInactive].

##### Declaration

```
public virtual void ClearEnabledInactive()
```

#### Deselect()

De-selects the containing button if it is in a selected state.

##### Declaration

```
public virtual void Deselect()
```

#### OnAfterDisabledHoverChange()

Called after [DisabledHover] has been changed.

##### Declaration

```
protected virtual void OnAfterDisabledHoverChange()
```

#### OnAfterDisabledInactiveChange()

Called after [DisabledInactive] has been changed.

##### Declaration

```
protected virtual void OnAfterDisabledInactiveChange()
```

#### OnAfterEnabledActiveChange()

Called after [EnabledActive] has been changed.

##### Declaration

```
protected virtual void OnAfterEnabledActiveChange()
```

#### OnAfterEnabledHoverChange()

Called after [EnabledHover] has been changed.

##### Declaration

```
protected virtual void OnAfterEnabledHoverChange()
```

#### OnAfterEnabledInactiveChange()

Called after [EnabledInactive] has been changed.

##### Declaration

```
protected virtual void OnAfterEnabledInactiveChange()
```

#### OnAfterIsEnabledChange()

Called after [IsEnabled] has been changed.

##### Declaration

```
protected virtual void OnAfterIsEnabledChange()
```

[Tilia.Interactions.SpatialButtons]: README.md
[SpatialButtonConfigurator]: SpatialButtonConfigurator.md
[SpatialButtonFacade.ButtonStyle]: SpatialButtonFacade.ButtonStyle.md
[DisabledHover]: SpatialButtonFacade.md#DisabledHover
[DisabledInactive]: SpatialButtonFacade.md#DisabledInactive
[EnabledActive]: SpatialButtonFacade.md#EnabledActive
[EnabledHover]: SpatialButtonFacade.md#EnabledHover
[EnabledInactive]: SpatialButtonFacade.md#EnabledInactive
[DisabledHover]: SpatialButtonFacade.md#DisabledHover
[DisabledInactive]: SpatialButtonFacade.md#DisabledInactive
[EnabledActive]: SpatialButtonFacade.md#EnabledActive
[EnabledHover]: SpatialButtonFacade.md#EnabledHover
[EnabledInactive]: SpatialButtonFacade.md#EnabledInactive
[IsEnabled]: SpatialButtonFacade.md#IsEnabled
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[Activated]: #Activated
[Deactivated]: #Deactivated
[Properties]: #Properties
[CollidableObjects]: #CollidableObjects
[Configuration]: #Configuration
[DisabledHover]: #DisabledHover
[DisabledInactive]: #DisabledInactive
[EnabledActive]: #EnabledActive
[EnabledHover]: #EnabledHover
[EnabledInactive]: #EnabledInactive
[IsEnabled]: #IsEnabled
[Methods]: #Methods
[ClearDisabledHover()]: #ClearDisabledHover
[ClearDisabledInactive()]: #ClearDisabledInactive
[ClearEnabledActive()]: #ClearEnabledActive
[ClearEnabledHover()]: #ClearEnabledHover
[ClearEnabledInactive()]: #ClearEnabledInactive
[Deselect()]: #Deselect
[OnAfterDisabledHoverChange()]: #OnAfterDisabledHoverChange
[OnAfterDisabledInactiveChange()]: #OnAfterDisabledInactiveChange
[OnAfterEnabledActiveChange()]: #OnAfterEnabledActiveChange
[OnAfterEnabledHoverChange()]: #OnAfterEnabledHoverChange
[OnAfterEnabledInactiveChange()]: #OnAfterEnabledInactiveChange
[OnAfterIsEnabledChange()]: #OnAfterIsEnabledChange
