using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryItemsContainer : MonoBehaviour {

    private List<GalleryItem> galleryItems;

    private void Awake()
    {
        galleryItems = new List<GalleryItem>();
    }

    public void AddGaleryItemToList(GalleryItem item)
    {
        galleryItems.Add(item);
    }

    private void OnDisable()
    {
        DestroyGalleryItems();
    }

    private void DestroyGalleryItems()
    {
        galleryItems.ForEach(item => Destroy(item.gameObject));
        galleryItems.Clear();
    }

    public GalleryItem GetGalleryItem(int index)
    {
        return galleryItems[index];
    }
}
