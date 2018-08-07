using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlickrPhoto;

public class ApplicationInfo : MonoBehaviour
{

    public static ApplicationInfo applicationInfo = null;
    public static int numberOfDownloadingPhotos = 5;

    public string FLICKR_API_KEY = "811024968b13eba2bdfb1c40f7362f24";

    private void Awake()
    {
        if (applicationInfo != null)
        {
            Destroy(this);
        }
        else
        {
            applicationInfo = this;
            DontDestroyOnLoad(applicationInfo);
            FlickrAPI.API_KEY = FLICKR_API_KEY;
        }
    }
}
