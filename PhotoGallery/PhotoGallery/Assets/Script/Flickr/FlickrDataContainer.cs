using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlickrPhoto;

public class FlickrDataContainer : MonoBehaviour {

    private FlickrData flickrData;

    public void SetFlickrData(FlickrData data)
    {
        flickrData = data;
    }

    public int GetNumberOfPhotosInGallery()
    {
        return flickrData.photos.photo.Count;
    }

    public PhotoData GetPhotoData(int index)
    {
        return flickrData.photos.photo[index];
    }

}
