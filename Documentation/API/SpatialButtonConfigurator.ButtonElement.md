# Class SpatialButtonConfigurator.ButtonElement

A container for the elements used in a button state.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [ButtonMeshFilter]
  * [ButtonMeshRenderer]
  * [Text]
  * [TextRect]

## Details

##### Inheritance

* System.Object
* SpatialButtonConfigurator.ButtonElement

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
public class ButtonElement
```

### Properties

#### ButtonMeshFilter

The MeshFilter for the state of the button.

##### Declaration

```
public MeshFilter ButtonMeshFilter { get; protected set; }
```

#### ButtonMeshRenderer

The MeshRenderer for the state of the button.

##### Declaration

```
public MeshRenderer ButtonMeshRenderer { get; protected set; }
```

#### Text

The TextMeshPro for the state of the button.

##### Declaration

```
public TextMeshPro Text { get; protected set; }
```

#### TextRect

The RectTransform for the state of the button.

##### Declaration

```
public RectTransform TextRect { get; protected set; }
```

[Tilia.Interactions.SpatialButtons]: README.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[ButtonMeshFilter]: #ButtonMeshFilter
[ButtonMeshRenderer]: #ButtonMeshRenderer
[Text]: #Text
[TextRect]: #TextRect
