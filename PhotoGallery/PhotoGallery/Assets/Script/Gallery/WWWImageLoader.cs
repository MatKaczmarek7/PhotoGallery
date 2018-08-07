using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WWWImageLoader : MonoBehaviour
{
    public RawImage image;

    public void LoadImage(string imageURL)
    {
        StartCoroutine(SetWWWImage(imageURL));
    }

    IEnumerator SetWWWImage(string imageURL)
    {
        using (WWW www = new WWW(imageURL))
        {
            yield return www;
            image.texture = www.texture;
            image.color = Color.white;
        }
    }
}
