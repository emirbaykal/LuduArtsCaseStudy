# LuduArtsCaseStudy

# Unity Interaction System

A modular interaction system for Unity using the **New Input System**. Supports **Instant**, **Hold**, and **Toggle** interaction types, with configurable inputs via **ScriptableObjects**. Designed for flexibility, scalability, and easy integration in any project.

---

## Features

- **Three interaction modes:**
  - **Instant:** Trigger interaction immediately on key press.
  - **Hold:** Trigger interaction while key is held.
  - **Toggle:** Trigger interaction on key press, deactivate on second press.
- **ScriptableObject-based configuration:** Store interactable data and input keys in ScriptableObjects for easy editing and reusability.
- **New Input System support:** Fully compatible with Unity's New Input System.
- **Raycast-based detection:** Works in 3D space using customizable layers and distance.
- **Modular and extensible:** Can be extended for new interaction types or special cases.

---

## Installation

1. Add the `Scripts/Runtime/Interactables` and `Scripts/Runtime/Player` folders to your Unity project.
2. Create an **Input Action Asset** and define your interaction action in the `Gameplay` action map.
3. Create **InteractableData ScriptableObjects** for each type of interactable object.
4. Attach the `PlayerInteraction` component to your player.

---

## Setup

### 1. Creating an Interactable Object

1. Create a new GameObject in your scene.
2. Add a component that inherits from `InteractableItem`.
3. Assign an `InteractableData` ScriptableObject to the component.

```csharp
public class Chest : InteractableItem
{
    public override void InteractionStart()
    {
        // Code to open chest
        Debug.Log("Chest opened!");
    }

    public override void InteractionStop()
    {
        // Code to stop interaction (if needed)
    }
}

```

2. Creating InteractableData ScriptableObject
   * Right-click in the Project window → Create → Interactable → InteractableData.
   * Configure:
     * InteractionType: Instant / Hold / Toggle
     * Key: Assign which key triggers this interaction

4. Setting Up Player Interaction

  * Attach the PlayerInteraction component to the player and configure:

  * InteractDistance: Maximum distance for raycast detection.

  * InteractLayerMask: Layer(s) to detect interactable objects.

  * Input Action Reference: Assign the Input Action from your Input Action Asset.
