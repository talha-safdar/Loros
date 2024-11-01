using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
	public ScrollRect scrollRect;
	public RectTransform content;
	private float[] screenPositions; // Array to store normalized positions for each screen
	private int screenCount = 4; // Total screens
	private int nearestScreenIndex = 0;

	void Start()
	{
		// Calculate normalized positions for each screen based on count
		screenPositions = new float[screenCount];
		for (int i = 0; i < screenCount; i++)
		{
			screenPositions[i] = i / (float)(screenCount - 1);
		}
	}

	public void OnEndDrag()
	{
		// Find nearest screen
		float horizontalPos = scrollRect.horizontalNormalizedPosition;
		float nearestDistance = Mathf.Abs(horizontalPos - screenPositions[0]);
		nearestScreenIndex = 0;

		for (int i = 1; i < screenPositions.Length; i++)
		{
			float distance = Mathf.Abs(horizontalPos - screenPositions[i]);
			if (distance < nearestDistance)
			{
				nearestDistance = distance;
				nearestScreenIndex = i;
			}
		}

		// Smoothly move to nearest screen
		StartCoroutine(SmoothScrollTo(screenPositions[nearestScreenIndex]));
	}

	private IEnumerator SmoothScrollTo(float targetPosition)
	{
		// Smoothly scroll over a short duration
		float duration = 0.3f;
		float elapsed = 0f;
		float start = scrollRect.horizontalNormalizedPosition;

		while (elapsed < duration)
		{
			elapsed += Time.deltaTime;
			scrollRect.horizontalNormalizedPosition = Mathf.Lerp(start, targetPosition, elapsed / duration);
			yield return null;
		}

		// Snap to final position
		scrollRect.horizontalNormalizedPosition = targetPosition;
	}







	// public GameObject scrollBar;
	// float scroll_pos = 0;
	// float[] pos;

	// // Update is called once per frame
	// void Update()
	// {
	// 	pos = new float[transform.childCount];
	// 	float distance = 1f / (pos.Length - 1f);
	// 	for (int i = 0; i < pos.Length; i++)
	// 	{
	// 		pos[i] = distance * i;
	// 	}
	// 	if (Input.GetMouseButton(0))
	// 	{
	// 		scroll_pos = scrollBar.GetComponent<Scrollbar>().value;
	// 	}
	// 	else
	// 	{
	// 		for (int i = 0; i < pos.Length; i++)
	// 		{
	// 			if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
	// 			{
	// 				scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
	// 			}
	// 		}
	// 	}
	// }
}
