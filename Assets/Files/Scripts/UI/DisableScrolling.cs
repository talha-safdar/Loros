/*
	This script is used to disable scrolling if all contents
	are visible on the screen
*/

using UnityEngine;
using UnityEngine.UI;

public class DisableScrolling : MonoBehaviour
{
	public ScrollRect scrollRect;          // The ScrollRect component
	public RectTransform content;          // The Content RectTransform
	public RectTransform viewport;         // The Viewport RectTransform

	void Start()
	{
		UpdateScrollability();
	}

	void UpdateScrollability()
	{
		// Check if the content width is less than or equal to the viewport width
		bool contentFitsHorizontally = content.rect.width <= viewport.rect.width;
		bool contentFitsVertically = content.rect.height <= viewport.rect.height;

		// Disable scrolling if the content fits within the viewport
		scrollRect.horizontal = !contentFitsHorizontally;
		scrollRect.vertical = !contentFitsVertically;
	}

	void Update()
	{
		// Continuously check for changes in content size (optional if content size can change dynamically)
		UpdateScrollability();
	}
}
