using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewSystem : MonoBehaviour
{
    private ScrollRect _scrollRect;

    [SerializeField] private ScrollButton _leftButton;
    [SerializeField] private ScrollButton _rightButton;
    [SerializeField] private float scrollSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _scrollRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_leftButton.isDown)
        {
            ScrollLeft();
        }

        if (_rightButton.isDown)
        {
            ScrollRight();
        }

    }

    private void ScrollLeft()
    {
        if (_scrollRect != null)
        {
            if (_scrollRect.horizontalNormalizedPosition >= 0f)
            {
                _scrollRect.horizontalNormalizedPosition -= scrollSpeed;
            }
        }
    }

    private void ScrollRight()
    {
        if (_scrollRect != null)
        {
            if (_scrollRect.horizontalNormalizedPosition <= 1f)
            {
                _scrollRect.horizontalNormalizedPosition += scrollSpeed;
            }
        }
    }
}
