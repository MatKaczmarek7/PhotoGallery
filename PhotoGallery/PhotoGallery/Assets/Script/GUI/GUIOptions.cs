using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIOptions : MonoBehaviour {

    public Text numberOfDownloadingPhotosText;

    public void UpdateNumberOfDownloadingPhotosGUI(int number)
    {
        numberOfDownloadingPhotosText.text = number.ToString();
    }

}
