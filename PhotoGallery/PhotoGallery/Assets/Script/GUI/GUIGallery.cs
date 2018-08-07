using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GUIGallery : MonoBehaviour
{

    public Scrollbar scrollBar;

    public GameObject galleryItemTemplate;
    public RectTransform contentScrollView;

    public static event Action OnScrollBarValueChanged;

    public int GalleryItemCount { get; set; }

    private int galleryWidthIterator = 0;
    private int GalleryWidthIterator
    {
        get
        {
            return galleryWidthIterator;
        }
        set
        {
            galleryWidthIterator = value;
            if (galleryWidthIterator == numberOfGalleryItemsInRow)
            {
                galleryWidthIterator = 0;
            }
            else if (galleryWidthIterator == firstElement)
            {
                ResizeScrollViewContent();
            }

        }
    }

    private CachedRectTransformInfo cachedRectTransform;
    struct CachedRectTransformInfo
    {
        public float height;
        public Vector3 cachedPosition;
    }

    private RectTransform galleryRowRectTransform;

    private const int numberOfGalleryItemsInRow = 3;
    private const int firstElement = 1;
    private const float positionOffset = 5f;
    private const int scrollBarHandleStartValuePosition = 1;

    private void Awake()
    {
        galleryRowRectTransform = galleryItemTemplate.GetComponent<RectTransform>();
        cachedRectTransform.height = contentScrollView.rect.height;
        cachedRectTransform.cachedPosition = contentScrollView.anchoredPosition3D;
    }

    private void OnDisable()
    {
        ResetValue();
        ResetScrollViewRectTransform();
    }

    private void ResetValue()
    {
        GalleryWidthIterator = 0;
        GalleryItemCount = 0;
        scrollBar.value = scrollBarHandleStartValuePosition;
    }

    private void ResetScrollViewRectTransform()
    {
        contentScrollView.sizeDelta = new Vector2(contentScrollView.sizeDelta.x, cachedRectTransform.height);
        contentScrollView.anchoredPosition3D = cachedRectTransform.cachedPosition;
    }

    private void ResizeScrollViewContent()
    {
        contentScrollView.sizeDelta = new Vector2(contentScrollView.sizeDelta.x,
            contentScrollView.sizeDelta.y + galleryRowRectTransform.rect.height + positionOffset);
    }

    public GameObject InstantiateGalleryItem()
    {
        GameObject galleryItem = Instantiate(galleryItemTemplate);
        galleryItem.SetActive(true);
        galleryItem.transform.parent = contentScrollView.transform;
        SetGalleryItemPosition(galleryItem);
        return galleryItem;
    }

    void SetGalleryItemPosition(GameObject galleryItem)
    {
        RectTransform rectTransformGalleryItem = galleryItem.GetComponent<RectTransform>();
        Vector3 pos = galleryRowRectTransform.anchoredPosition3D;
        pos.y -= ((int)(GalleryItemCount / numberOfGalleryItemsInRow) * (galleryRowRectTransform.rect.height + positionOffset));
        pos.x += GalleryWidthIterator * (galleryRowRectTransform.rect.height + positionOffset);
        rectTransformGalleryItem.anchoredPosition3D = pos;
        GalleryWidthIterator++;
    }

    public void ReactOnScrollBarValueChanged()
    {
        if (scrollBar.value <= 0 && OnScrollBarValueChanged != null)
        {
            OnScrollBarValueChanged();
            Canvas.ForceUpdateCanvases();
        }
    }

}
