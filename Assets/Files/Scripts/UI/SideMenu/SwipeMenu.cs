using UnityEngine;
using System.Collections;

public class SwipeMenu : MonoBehaviour
{
    public RectTransform sideMenu;  // Reference to the SideMenu panel RectTransform
    public GameObject overlay;      // Reference to the overlay panel (optional)
    public float slideDuration = 0.1f; // Duration of the slide animation

    private bool isMenuOpen = false;
    private Vector2 closedPosition;
    private Vector2 openPosition;
    private float swipeThreshold = 50f; // Minimum swipe distance to trigger menu
    private Vector2 touchStartPosition;
    private bool isDragging = false;

    void Start()
    {
        // Set the open and closed positions of the menu
        closedPosition = new Vector2(-sideMenu.rect.width, 0); // Off-screen to the left
        openPosition = new Vector2(0, 0);                      // On-screen

        // Initially, position the menu off-screen
        sideMenu.anchoredPosition = closedPosition;
        overlay.SetActive(false); // Ensure overlay is hidden at start
    }

    void Update()
    {
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Input.touchCount == 1) // Ensure only one finger is used
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPosition = touch.position;

                    // Determine if the swipe started in an area relevant to opening or closing
                    isDragging = (!isMenuOpen && touchStartPosition.x < swipeThreshold) ||
                                 (isMenuOpen && touchStartPosition.x < sideMenu.rect.width);
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        float deltaX = touch.position.x - touchStartPosition.x;

                        // When opening, only move within menu's width
                        if (!isMenuOpen && deltaX > 0 && deltaX < sideMenu.rect.width)
                        {
                            sideMenu.anchoredPosition = new Vector2(closedPosition.x + deltaX, 0);
                        }
                        // When closing, move within the menu width in the opposite direction
                        else if (isMenuOpen && deltaX < 0 && Mathf.Abs(deltaX) < sideMenu.rect.width)
                        {
                            sideMenu.anchoredPosition = new Vector2(openPosition.x + deltaX, 0);
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    if (isDragging)
                    {
                        float swipeDistance = touch.position.x - touchStartPosition.x;

                        if (!isMenuOpen)
                        {
                            // If swipe is more than half the menu width, open it
                            if (swipeDistance > sideMenu.rect.width / 2)
                            {
                                OpenMenu();
                            }
                            else
                            {
                                // Otherwise, close it
                                CloseMenu();
                            }
                        }
                        else
                        {
                            // If swipe distance is more than half the width (negative), close it
                            if (swipeDistance < -sideMenu.rect.width / 2)
                            {
                                CloseMenu();
                            }
                            else
                            {
                                // Otherwise, open it fully
                                OpenMenu();
                            }
                        }
                    }
                    isDragging = false;
                    break;
            }
        }
    }

    public void OpenMenu()
    {
        StopAllCoroutines();
        StartCoroutine(SlideMenuTo(openPosition));
        overlay.SetActive(true); // Show overlay when menu opens
        isMenuOpen = true;
    }

    public void CloseMenu()
    {
        StopAllCoroutines();
        StartCoroutine(SlideMenuTo(closedPosition));
        overlay.SetActive(false); // Hide overlay when menu closes
        isMenuOpen = false;
    }

    private IEnumerator SlideMenuTo(Vector2 targetPosition)
    {
        float elapsed = 0f;
        Vector2 startingPosition = sideMenu.anchoredPosition;

        while (elapsed < slideDuration)
        {
            elapsed += Time.deltaTime;
            sideMenu.anchoredPosition = Vector2.Lerp(startingPosition, targetPosition, elapsed / slideDuration);
            yield return null;
        }

        sideMenu.anchoredPosition = targetPosition;
    }
}
