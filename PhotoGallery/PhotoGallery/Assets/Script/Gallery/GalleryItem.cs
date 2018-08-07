using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FlickrPhoto;

[RequireComponent(typeof(WWWImageLoader))]
[RequireComponent(typeof(GalleryItemSizeManager))]
public class GalleryItem : MonoBehaviour
{

    public RawImage image;
    public WWWImageLoader wwwImageLoader;
    public GalleryItemSizeManager sizeManager;

    public delegate void OnReactGalleryItem(int index);
    public static event OnReactGalleryItem OnGalleryItemClicked;

    private int indexGalleryItem = 0;

    private void Awake()
    {
        wwwImageLoader = GetComponent<WWWImageLoader>();
        sizeManager = GetComponent<GalleryItemSizeManager>();
    }

    public void Initialize(PhotoData photoData, int index)
    {
        indexGalleryItem = index;
        string imageURL = FlickrAPI.GetImageUrl(photoData);
        string imageSizeURL = FlickrAPI.GetSizePhoto(photoData.id);
        wwwImageLoader.LoadImage(imageURL);
        sizeManager.SetImageSize(imageSizeURL);
    }

    public Texture GetImageTexture()
    {
        return image.texture;
    }

    public void ReatctOnGalleryItemClick()
    {
        if (OnGalleryItemClicked != null)
        {
            OnGalleryItemClicked(indexGalleryItem);
        }
    }

    public Vector2 GetImageOriginalSize()
    {
        return sizeManager.GetImageOriginalSize();
    }
}
