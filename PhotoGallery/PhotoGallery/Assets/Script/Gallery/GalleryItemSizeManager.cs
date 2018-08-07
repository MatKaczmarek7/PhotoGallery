using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlickrPhoto;
using Newtonsoft.Json;
using System;

public class GalleryItemSizeManager : MonoBehaviour
{
    private Vector2 imageOriginalSize;

    private const float scaleFactor = 3; //delete this variable in hololens build
    private const string originalSizeHeader = "Large";


    public void SetImageSize(string imageURL)
    {
        StartCoroutine(LoadOriginalSizeImage(imageURL));
    }

    private IEnumerator LoadOriginalSizeImage(string imageURL)
    {
        using (WWW www = new WWW(imageURL))
        {
            yield return www;
            string textToDeserialize = www.text;
            SizeObject sizeObject = JsonConvert.DeserializeObject<SizeObject>(textToDeserialize);
            SizeData sizeData = sizeObject.sizes.size.Find(item =>item.label == originalSizeHeader);
            imageOriginalSize = new Vector2(Convert.ToInt32(sizeData.width)/scaleFactor, Convert.ToInt32(sizeData.height)/scaleFactor);
        }
    }

    public Vector2 GetImageOriginalSize()
    {
        return imageOriginalSize;
    }
}
