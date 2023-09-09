# BoxColliderGizmo
The "BoxColliderGizmo" script allows you to visualize box colliders in the Unity Editor by drawing gizmos around them. It collects all the box colliders in the children of the script's parent object and automatically updates the collection whenever a child collider is added or removed. The gizmos are drawn using the OnDrawGizmosSelected() and OnDrawGizmos() methods, giving you a visual representation of the collider's position and size. This script can be useful during development to visually inspect and adjust box colliders without the need to enter play mode.

# Usage
To use this script, attach it to a GameObject in Unity that contains child objects with box colliders. The script will automatically collect and update the box colliders in the array. The gizmos will be visible even when the parent object is not selected in the Unity Editor. You can customize the color and transparency of the gizmos to suit your needs.
