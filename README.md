[![Tilia logo][Tilia-Image]](#)

> ### Interactions -> Spatial Buttons for the Unity Software
> User interface button types that can be used within a spatial environment for the Unity software.

[![Release][Version-Release]][Releases]
[![License][License-Badge]][License]
[![Backlog][Backlog-Badge]][Backlog]

## Introduction

The Spatial Button prefabs provide the ability to add spatial user interface button elements to a scene that can be interacted with via an [Object Pointer].

The included Spatial Button prefabs are:

* `Interactions.SpatialButton.ClickButton` - A simple button that is clicked and automatically unclicks.
* `Interactions.SpatialButton.ToggleButton` - A button that is toggled on and off whenever it is clicked.
* `Interactions.SpatialButton.OptionButton` - A button that is used as a group of other options buttons where only one can be selected.
* `Interactions.SpatialButton.Group` - A container for Spatial Buttons to group them under a single, distinct dispatcher (required for `Interactions.SpatialButton.OptionButton`).

> **Requires** the Unity software version `2018.3.10f1` (or above).

## Getting Started

Please refer to the [installation] guide to install this package.

## Documentation

Please refer to the [How To Guides] for usage of this package.

Further documentation can be found within the [Documentation] directory and at https://academy.vrtk.io

## Contributing

Please refer to the Extend Reality [Contributing guidelines] and the [project coding conventions].

## Code of Conduct

Please refer to the Extend Reality [Code of Conduct].

## License

Code released under the [MIT License][License].

[License-Badge]: https://img.shields.io/github/license/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity.svg
[Version-Release]: https://img.shields.io/github/release/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity.svg
[project coding conventions]: https://github.com/ExtendRealityLtd/.github/blob/master/CONVENTIONS/UNITY3D.md

[Tilia-Image]: https://raw.githubusercontent.com/ExtendRealityLtd/related-media/main/github/readme/tilia.png
[License]: LICENSE.md
[Documentation]: Documentation/
[How To Guides]: Documentation/HowToGuides/
[Installation]: Documentation/HowToGuides/Installation/README.md
[Backlog]: http://tracker.vrtk.io
[Backlog-Badge]: https://img.shields.io/badge/project-backlog-78bdf2.svg
[Releases]: ../../releases
[Contributing guidelines]: https://github.com/ExtendRealityLtd/.github/blob/master/CONTRIBUTING.md
[Code of Conduct]: https://github.com/ExtendRealityLtd/.github/blob/master/CODE_OF_CONDUCT.md
[Object Pointer]: https://github.com/ExtendRealityLtd/Tilia.Indicators.ObjectPointers.Unity