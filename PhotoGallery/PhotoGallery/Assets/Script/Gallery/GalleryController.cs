using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlickrPhoto;
using UnityEngine.UI;

public class GalleryController : MonoBehaviour
{
    public FlickrDataContainer flickrDataContainer;
    public GalleryItemsContainer galleryItemsContainer;
    public GUIGallery guiGallery;

    private RectTransform galleryRowRectTransform;

    private void OnEnable()
    {
        GUIGallery.OnScrollBarValueChanged += TryToCreateGalleryItems;
    }

    private void OnDisable()
    {
        GUIGallery.OnScrollBarValueChanged -= TryToCreateGalleryItems;
    }

    public void Initialize(FlickrData flickrdata)
    {
        flickrDataContainer.SetFlickrData(flickrdata);
        TryToCreateGalleryItems();
    }

    public void TryToCreateGalleryItems()
    {
        if (flickrDataContainer.GetNumberOfPhotosInGallery() == guiGallery.GalleryItemCount)
        {
            return;
        }
        else if (flickrDataContainer.GetNumberOfPhotosInGallery() - guiGallery.GalleryItemCount < ApplicationInfo.numberOfDownloadingPhotos)
        {
            CreateGalleryItems(flickrDataContainer.GetNumberOfPhotosInGallery() - guiGallery.GalleryItemCount);
        }
        else
        {
            CreateGalleryItems(ApplicationInfo.numberOfDownloadingPhotos);
        }

    }

    private void CreateGalleryItems(int numberOfItems)
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            CreateGalleryItem();
        }
    }

    private void CreateGalleryItem()
    {
        GameObject galleryItemObject = guiGallery.InstantiateGalleryItem();
        InitializeGalleryItem(galleryItemObject, guiGallery.GalleryItemCount);
        guiGallery.GalleryItemCount++;
    }


    private void InitializeGalleryItem(GameObject item, int index)
    {
        GalleryItem galleryItem = item.GetComponent<GalleryItem>();
        galleryItem.Initialize(flickrDataContainer.GetPhotoData(index), index);
        galleryItemsContainer.AddGaleryItemToList(galleryItem);
    }

}
