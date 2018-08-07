using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using FlickrPhoto;

public class WWWGalleryLoader : MonoBehaviour {

    public string ID_GALLERY = "72157692049980335";
    public GalleryController galleryController;

    void OnEnable()
    {
        StartCoroutine(DownloadFlickrGalleryData());
    }

    IEnumerator DownloadFlickrGalleryData()
    {
        string baseUrl = FlickrAPI.GetGalleryUrl(ID_GALLERY);

        using (WWW www = new WWW(baseUrl))
        {
            yield return www;
            string textToDeserialize = www.text;
            FlickrData flickrData = JsonConvert.DeserializeObject<FlickrData>(textToDeserialize);
            galleryController.Initialize(flickrData);
        }
    }
}
