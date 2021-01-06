# Class SpatialButtonFacade.ButtonStyle

A container for the elements used in a button state.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [ButtonText]
  * [Container]
  * [FontColor]
  * [FontSize]
  * [IsApplied]
  * [MeshColor]

## Details

##### Inheritance

* System.Object
* SpatialButtonFacade.ButtonStyle

##### Inherited Members

System.Object.ToString()

System.Object.Equals(System.Object)

System.Object.Equals(System.Object, System.Object)

System.Object.ReferenceEquals(System.Object, System.Object)

System.Object.GetHashCode()

System.Object.GetType()

System.Object.MemberwiseClone()

##### Namespace

* [Tilia.Interactions.SpatialButtons]

##### Syntax

```
[Serializable]
public class ButtonStyle
```

### Properties

#### ButtonText

The text to display on the button.

##### Declaration

```
public string ButtonText { get; set; }
```

#### Container

The container references for the button appearance objects.

##### Declaration

```
public ObjectReference Container { get; set; }
```

#### FontColor

The color for the font on the button.

##### Declaration

```
public Color FontColor { get; set; }
```

#### FontSize

The size for the font on the button.

##### Declaration

```
public float FontSize { get; set; }
```

#### IsApplied

Whether this style is applied.

##### Declaration

```
public bool IsApplied { get; set; }
```

#### MeshColor

The color for the button mesh.

##### Declaration

```
public Color MeshColor { get; set; }
```

[Tilia.Interactions.SpatialButtons]: README.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[ButtonText]: #ButtonText
[Container]: #Container
[FontColor]: #FontColor
[FontSize]: #FontSize
[IsApplied]: #IsApplied
[MeshColor]: #MeshColor
