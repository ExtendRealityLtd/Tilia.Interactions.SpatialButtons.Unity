# Installing the package

> * Level: Beginner
>
> * Reading Time: 2 minutes
>
> * Checked with: Unity 2018.3.14f1

## Introduction

The Spatial Buttons provide the ability to create user interface buttons within a spatial environment that can be interacted with via Object Pointers. These prefabs can be included in a Unity software project via the [Unity Package Manager].

## Let's Start

### Step 1: Creating a Unity project

> You may skip this step if you already have a Unity project to import the package into.

* Create a new project in the Unity software version `2018.3.10f1` (or above) using `3D Template` or open an existing project.

### Step 2: Configuring the Unity project

* Ensure the project `Scripting Runtime Version` is set to `.NET 4.x Equivalent`:
  * In the Unity software select `Main Menu -> Edit -> Project Settings` to open the `Project Settings` inspector.
  * Select `Player` from the left hand menu in the `Project Settings` window.
  * In the `Player` settings panel expand `Other Settings`.
  * Ensure the `Scripting Runtime Version` is set to `.NET 4.x Equivalent`.

### Step 3: Adding the package to the Unity project manifest

* Navigate to the `Packages` directory of your project.
* Adjust the [project manifest file][Project-Manifest] `manifest.json` in a text editor.
  * Ensure `https://registry.npmjs.org/` is part of `scopedRegistries`.
    * Ensure `io.extendreality` is part of `scopes`.
  * Add `io.extendreality.tilia.interactions.spatialbuttons.unity` to `dependencies`, stating the latest version.

  A minimal example ends up looking like this. Please note that the version `X.Y.Z` stated here is to be replaced with [the latest released version][Latest-Release] which is currently [![Release][Version-Release]][Releases].
  ```json
  {
    "scopedRegistries": [
      {
        "name": "npmjs",
        "url": "https://registry.npmjs.org/",
        "scopes": [
          "io.extendreality"
        ]
      }
    ],
    "dependencies": {
      "io.extendreality.tilia.interactions.spatialbuttons.unity": "X.Y.Z",
      ...
    }
  }
  ```
* Switch back to the Unity software and wait for it to finish importing the added package.

### Step 4: Installing the TextMeshPro dependencies

The `Tilia Interactions SpatialButtons Unity` package will now be available in your Unity project `Packages` directory but will need the [TextMeshPro] dependencies before the prefabs can be used.

Expand the `Tilia Interactions SpatialButtons Unity` package directory in the Unity Project window and select the `Packages -> Tilia Interactions SpatialButtons Unity -> Runtime -> Prefabs` directory then drag and drop the `Interactions.SpatialButton.ClickButton` prefab into the Unity Hierarchy window.

You will now see a `TMP Importer` window appear within the Unity software. Click on the `Import TMP Essentials` button within this window to install the relevant TextMeshPro dependencies.

> You may see a couple of errors in your console window in relation to TextMeshPro, but these errors will go away when the TextMeshPro dependencies are installed.

### Done

The `Interactions.SpatialButton.ClickButton` prefab can now be deleted from the scene and the Spatial Button prefabs are now ready to be used.

The package will now also show up in the Unity Package Manager UI. From then on the package can be updated by selecting the package in the Unity Package Manager and clicking on the `Update` button or using the version selection UI.

[Unity]: https://unity3d.com/
[Unity Package Manager]: https://docs.unity3d.com/Manual/upm-ui.html
[Project-Manifest]: https://docs.unity3d.com/Manual/upm-manifestPrj.html
[Version-Release]: https://img.shields.io/github/release/ExtendRealityLtd/Tilia.Interactions.SpatialButtons.Unity.svg
[Releases]: ../../../../../releases
[Latest-Release]: ../../../../../releases/latest
[TextMeshPro]: https://docs.unity3d.com/Manual/com.unity.textmeshpro.html