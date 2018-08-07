using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaximumGalleryItemWindowController : MonoBehaviour
{

    public GalleryItemsContainer galleryItemsContainer;
    public RawImage image;
    public RectTransform imageRectTransform;

    private GalleryItem galleryItem;

    private void OnEnable()
    {
        GalleryItem.OnGalleryItemClicked += OpenFullSizeImage;
    }

    private void OnDisable()
    {
        GalleryItem.OnGalleryItemClicked -= OpenFullSizeImage;
    }

    public void OpenFullSizeImage(int index)
    {
        galleryItem = galleryItemsContainer.GetGalleryItem(index);
        image.texture = galleryItem.GetImageTexture();
        imageRectTransform.sizeDelta = galleryItem.GetImageOriginalSize();
        imageRectTransform.gameObject.SetActive(true);
    }

    public void CloseImage()
    {
        imageRectTransform.gameObject.SetActive(false);
    }
}
