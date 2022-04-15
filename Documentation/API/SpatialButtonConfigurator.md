# Class SpatialButtonConfigurator

Sets up the SpatialButton Prefab based on the provided user settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [DisabledHoverState]
  * [DisabledNormalState]
  * [EnabledActiveState]
  * [EnabledHoverState]
  * [EnabledNormalState]
  * [Facade]
  * [SpatialTargetDispatcher]
  * [SpatialTargetFacade]
* [Methods]
  * [ApplyButtonStyle(SpatialButtonConfigurator.ButtonElement, SpatialButtonFacade.ButtonStyle)]
  * [ApplyMeshStyle(MeshFilter, SpatialButtonFacade.ButtonStyle)]
  * [ApplyTextStyle(TextMeshPro, SpatialButtonFacade.ButtonStyle)]
  * [CalculateRectDimension(Vector3, Int32)]
  * [ConfigureButton()]
  * [ConfigureDisabledHover()]
  * [ConfigureDisabledInactive()]
  * [ConfigureEnabledActive()]
  * [ConfigureEnabledHover()]
  * [ConfigureEnabledInactive()]
  * [ConfigureEnabledState()]
  * [NotifyActivated(SurfaceData)]
  * [NotifyDeactivated()]
  * [OnEnable()]
  * [RescaleButton(RectTransform)]
  * [Select(GameObject)]
  * [Select(SurfaceData)]

## Details

##### Inheritance

* System.Object
* SpatialButtonConfigurator

##### Namespace

* [Tilia.Interactions.SpatialButtons]

##### Syntax

```
public class SpatialButtonConfigurator : MonoBehaviour
```

### Properties

#### DisabledHoverState

The [SpatialButtonConfigurator.ButtonElement] for the disabled hover state of the button.

##### Declaration

```
public SpatialButtonConfigurator.ButtonElement DisabledHoverState { get; protected set; }
```

#### DisabledNormalState

The [SpatialButtonConfigurator.ButtonElement] for the disabled normal state of the button.

##### Declaration

```
public SpatialButtonConfigurator.ButtonElement DisabledNormalState { get; protected set; }
```

#### EnabledActiveState

The [SpatialButtonConfigurator.ButtonElement] for the enabled active state of the button.

##### Declaration

```
public SpatialButtonConfigurator.ButtonElement EnabledActiveState { get; protected set; }
```

#### EnabledHoverState

The [SpatialButtonConfigurator.ButtonElement] for the enabled hover state of the button.

##### Declaration

```
public SpatialButtonConfigurator.ButtonElement EnabledHoverState { get; protected set; }
```

#### EnabledNormalState

The [SpatialButtonConfigurator.ButtonElement] for the enabled normal state of the button.

##### Declaration

```
public SpatialButtonConfigurator.ButtonElement EnabledNormalState { get; protected set; }
```

#### Facade

The public facade.

##### Declaration

```
public SpatialButtonFacade Facade { get; protected set; }
```

#### SpatialTargetDispatcher

The dispatcher for the internal Spatial Target.

##### Declaration

```
public SpatialTargetDispatcher SpatialTargetDispatcher { get; set; }
```

#### SpatialTargetFacade

The facade for the internal Spatial Target.

##### Declaration

```
public SpatialTargetFacade SpatialTargetFacade { get; protected set; }
```

### Methods

#### ApplyButtonStyle(SpatialButtonConfigurator.ButtonElement, SpatialButtonFacade.ButtonStyle)

Configures the appearance of a [SpatialButtonConfigurator.ButtonElement] button.

##### Declaration

```
protected virtual void ApplyButtonStyle(SpatialButtonConfigurator.ButtonElement button, SpatialButtonFacade.ButtonStyle style)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| [SpatialButtonConfigurator.ButtonElement] | button | The button to style. |
| [SpatialButtonFacade.ButtonStyle] | style | The styles to apply. |

#### ApplyMeshStyle(MeshFilter, SpatialButtonFacade.ButtonStyle)

Styles the mesh with the given style.

##### Declaration

```
protected virtual void ApplyMeshStyle(MeshFilter meshFilter, SpatialButtonFacade.ButtonStyle style)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| MeshFilter | meshFilter | The mesh to style. |
| [SpatialButtonFacade.ButtonStyle] | style | The styles to apply. |

#### ApplyTextStyle(TextMeshPro, SpatialButtonFacade.ButtonStyle)

Styles the text with the given style.

##### Declaration

```
protected virtual void ApplyTextStyle(TextMeshPro textMesh, SpatialButtonFacade.ButtonStyle style)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| TextMeshPro | textMesh | The text to style. |
| [SpatialButtonFacade.ButtonStyle] | style | The styles to apply. |

#### CalculateRectDimension(Vector3, Int32)

Calculates the new rectangle dimension scale for the given dimensions at the given Vector3 coordinate based on the Facade.transform scale.

##### Declaration

```
protected virtual float CalculateRectDimension(Vector3 rectScale, int coordinateIndex)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| Vector3 | rectScale | The dimensions of the rectangle to recalculate. |
| System.Int32 | coordinateIndex | The coordinate index of the given Vector3 to apply the scale calculate to. |

##### Returns

| Type | Description |
| --- | --- |
| System.Single | The newly calculated scaled coordinate. |

#### ConfigureButton()

Configures the button based on the settings in the [Facade].

##### Declaration

```
public virtual void ConfigureButton()
```

#### ConfigureDisabledHover()

Configures the disabled hover style of the button.

##### Declaration

```
public virtual void ConfigureDisabledHover()
```

#### ConfigureDisabledInactive()

Configures the disabled inactive style of the button.

##### Declaration

```
public virtual void ConfigureDisabledInactive()
```

#### ConfigureEnabledActive()

Configures the enabled active style of the button.

##### Declaration

```
public virtual void ConfigureEnabledActive()
```

#### ConfigureEnabledHover()

Configures the enabled hover style of the button.

##### Declaration

```
public virtual void ConfigureEnabledHover()
```

#### ConfigureEnabledInactive()

Configures the enabled inactive style of the button.

##### Declaration

```
public virtual void ConfigureEnabledInactive()
```

#### ConfigureEnabledState()

Configures the enabled state of the button.

##### Declaration

```
public virtual void ConfigureEnabledState()
```

#### NotifyActivated(SurfaceData)

Notifies the Facade.Activated event to raise.

##### Declaration

```
public virtual void NotifyActivated(SurfaceData data)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| SurfaceData | data | The data to raise with. |

#### NotifyDeactivated()

Notifies the Facade.Deactivated event to raise.

##### Declaration

```
public virtual void NotifyDeactivated()
```

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
```

#### RescaleButton(RectTransform)

Rescales the button based on the Facade.transform scale.

##### Declaration

```
protected virtual void RescaleButton(RectTransform buttonRect)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| RectTransform | buttonRect | The button to resize. |

#### Select(GameObject)

Selects the containing button.

##### Declaration

```
public virtual void Select(GameObject selectingObject = null)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | selectingObject | An optional GameObject that is selecting the button. |

#### Select(SurfaceData)

Selects the containing button.

##### Declaration

```
public virtual void Select(SurfaceData data)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| SurfaceData | data | The data to select with. |

[Tilia.Interactions.SpatialButtons]: README.md
[SpatialButtonFacade]: SpatialButtonFacade.md
[SpatialButtonConfigurator.ButtonElement]: SpatialButtonConfigurator.ButtonElement.md
[SpatialButtonFacade.ButtonStyle]: SpatialButtonFacade.ButtonStyle.md
[Facade]: SpatialButtonConfigurator.md#Facade
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[DisabledHoverState]: #DisabledHoverState
[DisabledNormalState]: #DisabledNormalState
[EnabledActiveState]: #EnabledActiveState
[EnabledHoverState]: #EnabledHoverState
[EnabledNormalState]: #EnabledNormalState
[Facade]: #Facade
[SpatialTargetDispatcher]: #SpatialTargetDispatcher
[SpatialTargetFacade]: #SpatialTargetFacade
[Methods]: #Methods
[ApplyButtonStyle(SpatialButtonConfigurator.ButtonElement, SpatialButtonFacade.ButtonStyle)]: #ApplyButtonStyleSpatialButtonConfigurator.ButtonElement-SpatialButtonFacade.ButtonStyle
[ApplyMeshStyle(MeshFilter, SpatialButtonFacade.ButtonStyle)]: #ApplyMeshStyleMeshFilter-SpatialButtonFacade.ButtonStyle
[ApplyTextStyle(TextMeshPro, SpatialButtonFacade.ButtonStyle)]: #ApplyTextStyleTextMeshPro-SpatialButtonFacade.ButtonStyle
[CalculateRectDimension(Vector3, Int32)]: #CalculateRectDimensionVector3-Int32
[ConfigureButton()]: #ConfigureButton
[ConfigureDisabledHover()]: #ConfigureDisabledHover
[ConfigureDisabledInactive()]: #ConfigureDisabledInactive
[ConfigureEnabledActive()]: #ConfigureEnabledActive
[ConfigureEnabledHover()]: #ConfigureEnabledHover
[ConfigureEnabledInactive()]: #ConfigureEnabledInactive
[ConfigureEnabledState()]: #ConfigureEnabledState
[NotifyActivated(SurfaceData)]: #NotifyActivatedSurfaceData
[NotifyDeactivated()]: #NotifyDeactivated
[OnEnable()]: #OnEnable
[RescaleButton(RectTransform)]: #RescaleButtonRectTransform
[Select(GameObject)]: #SelectGameObject
[Select(SurfaceData)]: #SelectSurfaceData
