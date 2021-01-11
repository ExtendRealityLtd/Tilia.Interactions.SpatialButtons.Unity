# Changelog

## [1.1.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/compare/v1.0.5...v1.1.0) (2021-01-11)

#### Features

* **HowToGuides:** add guide for option buttons ([2df0363](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/commit/2df0363e9b08aae912f7f691deef11b0ec76df66))
  > A new guide has been added showing how to create a group of option buttons.
* **HowToGuides:** add guide for toggle button ([e24eb0d](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/commit/e24eb0d3b874017112dc7fe540bfad7063323700))
  > A new guide has been added showing how to add a toggle button and also how to use the Spatial Target Processor along with the Button Groups to make this guide a bit more worthwhile.
* **HowToGuides:** add guide on how to add click button ([714c1cb](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/commit/714c1cb931961b3f2f8c5a987df4419b057e4e95))
  > A new guide has been added to show how to add a simple click button to a scene.

### [1.0.5](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/compare/v1.0.4...v1.0.5) (2021-01-09)

#### Bug Fixes

* **prefab:** ensure inner events are propagated to facade events ([8aeaa90](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/commit/8aeaa90c83d0f60981d409f5eb7ca964f7573d9f))
  > The Facade events were not doing anything because the inner events had not been linked to notify the Facade to raise the event.

### [1.0.4](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/compare/v1.0.3...v1.0.4) (2021-01-07)

#### Bug Fixes

* **HowToGuides:** add step to install TextMeshPro dependencies ([7f75062](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/commit/7f750625dcc2f25d867bf6f947809cef5932578c))
  > The installation guide now includes the steps required to install the TextMeshPro depdendencies via the TMP Importer popup window.

### [1.0.3](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/compare/v1.0.2...v1.0.3) (2021-01-07)

#### Bug Fixes

* **API:** add missing API documentation ([64ab7a8](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/commit/64ab7a8e8329a0ac46299b168b74bf1e53d9e4d4))
  > The API docs have been auto generated for the latest changes.

### [1.0.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/compare/v1.0.1...v1.0.2) (2021-01-07)

#### Bug Fixes

* **prefab:** update ActiveButtonIndex when group button changes ([3b327af](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/commit/3b327af37473bd1911a990399b673dcf2513a68f))
  > The ActiveButtonIndex property will now correctly reflect the actual selected button and not only used for the initial set.

### [1.0.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/compare/v1.0.0...v1.0.1) (2021-01-07)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.tilia.indicators.spatialtargets.unity ([fc21a02](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/commit/fc21a02934567e120f219f7e350e6566e554119c))
  > Bumps [io.extendreality.tilia.indicators.spatialtargets.unity](https://github.com/ExtendRealityLtd/Tilia.Indicators.SpatialTargets.Unity) from 1.3.0 to 1.3.2. - [Release notes](https://github.com/ExtendRealityLtd/Tilia.Indicators.SpatialTargets.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Tilia.Indicators.SpatialTargets.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Tilia.Indicators.SpatialTargets.Unity/compare/v1.3.0...v1.3.2)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

## 1.0.0 (2021-01-06)

#### Features

* **SpatialButton:** add prefabs for spatial button types ([dd57e18](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/commit/dd57e18037644c6a1dda18c67772978744c55ee1))
  > The new Spatial Button prefabs have been added in the following types:
  > 
  > * ClickButton - a simple button that is clicked on and auto off * ToggleButton - a button that is toggled on and off per click * OptionButton - a button used as a group of buttons for options
  > 
  > The Group prefab also allows SpatialButtons to be grouped into a distinct group to be processed via a distinct dispatcher.
* **structure:** add initial documentation content ([c98a364](https://github.com/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity/commit/c98a3641b10cd1ae65cd07fd2f1f95bf31fdc1e8))
  > The content of documentation and other supplement files has been added to the repo.
