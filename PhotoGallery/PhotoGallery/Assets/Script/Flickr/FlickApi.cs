using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlickrPhoto
{
    public class PhotoData
    {
        public string id { get; set; }
        public string owner { get; set; }
        public string secret { get; set; }
        public string server { get; set; }
        public int farm { get; set; }
        public string title { get; set; }
        public int ispublic { get; set; }
        public int isfriend { get; set; }
        public int isfamily { get; set; }
        public int is_primary { get; set; }
        public int has_comment { get; set; }
    }

    public class PhotosContainer
    {
        public int page { get; set; }
        public int pages { get; set; }
        public int perpage { get; set; }
        public int total { get; set; }
        public List<PhotoData> photo { get; set; }
    }

    public class FlickrData
    {
        public PhotosContainer photos { get; set; }
        public string stat { get; set; }
    }

    public class SizeData
    {
        public string label { get; set; }
        public object width { get; set; }
        public object height { get; set; }
        public string source { get; set; }
        public string url { get; set; }
        public string media { get; set; }
    }

    public class Sizes
    {
        public int canblog { get; set; }
        public int canprint { get; set; }
        public int candownload { get; set; }
        public List<SizeData> size { get; set; }
    }

    public class SizeObject
    {
        public Sizes sizes { get; set; }
        public string stat { get; set; }
    }

    public class FlickrAPI
    {
        private const string FLICKR_ENDPOINT = "https://api.flickr.com/services/rest";
        private const string FLICKR_FARM = "https://farm";
        private const string FLICK_IMAGE_ENDPOINT = ".staticflickr.com/";
        private const string method = "?method={0}";
        private const string api_key_header = "&api_key={1}";
        private const string gallery_id_header = "&gallery_id={2}";
        private const string photo_id_header = "&photo_id={2}";
        private const string jsonFormat = "&format=json&nojsoncallback=1";

        private const string flickr_galleries_getPhotos = "flickr.galleries.getPhotos";
        private const string flickr_photos_getSize = "flickr.photos.getSizes";
        public static string API_KEY = "811024968b13eba2bdfb1c40f7362f24";

        public static string GetGalleryUrl(string ID_GALLERY)
        {
            return string.Format(FLICKR_ENDPOINT + method + api_key_header + jsonFormat + gallery_id_header, flickr_galleries_getPhotos, API_KEY, ID_GALLERY);
        }

        public static string GetImageUrl(PhotoData photoData)
        {
            return FLICKR_FARM + photoData.farm + FLICK_IMAGE_ENDPOINT + photoData.server + "/" + photoData.id + "_" + photoData.secret + ".jpg";
        }

        public static string GetSizePhoto(string ID_IMAGE)
        {
            return string.Format(FLICKR_ENDPOINT + method + api_key_header + photo_id_header + jsonFormat, flickr_photos_getSize, API_KEY, ID_IMAGE);
        }
    }


}
