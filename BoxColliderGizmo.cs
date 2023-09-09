/* 
* BoxColliderGizmo Class
* (C)2023 Marco Capelli
* 
* The "BoxColliderGizmo" script allows you to visualize box colliders
* in the Unity Editor by drawing gizmos around them. It collects all
* the box colliders in the children of the script's parent object and
* automatically updates the collection whenever a child collider is added
* or removed. The gizmos are drawn using the OnDrawGizmosSelected() and
* OnDrawGizmos() methods, giving you a visual representation of the collider's
* position and size. This script can be useful during development to visually
* inspect and adjust box colliders without the need to enter play mode.
*/

// Import the necessary namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Execute the script in the Editor and at runtime
[ExecuteInEditMode]

public class BoxColliderGizmo : MonoBehaviour
{
	// Array to store the box colliders in the children of this object
	private Transform[] BoxColliders;
	public Color gizmoColor = new Color(1f, 1f, 1f, 1f);

	// Method to draw gizmos when the object is selected
	private void OnDrawGizmosSelected()
	{
		DrawGizmos();
	}

	// Method to draw gizmos when the object is not selected
	private void OnDrawGizmos()
	{
		DrawGizmos();
	}

	// Draw the gizmos
	private void DrawGizmos()
	{
		if (BoxColliders != null)
		{
			// Set the color of the gizmos
			Gizmos.color = gizmoColor;
			
			foreach (Transform boxCollider in BoxColliders)
			{
				if (boxCollider != null)
				{
					// Get the BoxCollider component
					BoxCollider collider = boxCollider.gameObject.GetComponent<BoxCollider>();

					// Set the matrix for Gizmos to the transform's local-to-world matrix
					Gizmos.matrix = boxCollider.localToWorldMatrix;

					// Get the local position and size of the BoxCollider
					Vector3 localPosition = collider.center;
					Vector3 size = collider.size;

					// Draw the gizmo cube at the local position and with the collider size
					Gizmos.DrawCube(localPosition, size);
				}
			}
		}
	}

	// Called when the script component is enabled
	private void OnEnable()
	{
		// Collect all the box colliders in the children of this object
		CollectBoxColliders();
	}

	// Called when a value is changed in the inspector
	private void OnValidate()
	{
		// Collect all the box colliders in the children of this object
		CollectBoxColliders();
	}

	// Called when a child of the object is added or removed
	private void OnTransformChildrenChanged()
	{
		// Collect all the box colliders in the children of this object
		CollectBoxColliders();
	}

	// Collect all the box colliders in the children of this object
	private void CollectBoxColliders()
	{
		// Collect all the box colliders in the children of this object, including inactive ones
		BoxColliders = GetComponentsInChildren<Transform>(true);

		// Exclude the root transform from the array
		BoxColliders = RemoveRootTransform(BoxColliders);
	}

	// Exclude the root transform from the array
	private Transform[] RemoveRootTransform(Transform[] transforms)
	{
		if (transforms.Length > 0)
		{
			List<Transform> childTransforms = new List<Transform>(transforms);
			childTransforms.Remove(transform);
			return childTransforms.ToArray();
		}

		return transforms;
	}
}
