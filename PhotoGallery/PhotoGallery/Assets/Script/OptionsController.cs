using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    public GUIOptions guiOptions;
    public int[] numbersOfDownloadingOption;

    private int choosenNumberIndex = 0;
    private int ChooseNumberIndex
    {
        get
        {
            return choosenNumberIndex;
        }
        set
        {
            if (value >= 0 && value < numbersOfDownloadingOption.Length)
            {
                choosenNumberIndex = value;
                UpdateNumberOfDownLoadingPhotos(numbersOfDownloadingOption[value]);
            }
        }
    }

    private void Awake()
    {
        UpdateNumberOfDownLoadingPhotos(GetNumberOfDownloadingPhotos());
    }

    public void ReactOnOptionRightButton()
    {
        ChooseNumberIndex++;
    }

    public void ReactOnOptionLeftButton()
    {
        ChooseNumberIndex--;
    }

    private void UpdateNumberOfDownLoadingPhotos(int number)
    {
        guiOptions.UpdateNumberOfDownloadingPhotosGUI(number);
        ApplicationInfo.numberOfDownloadingPhotos = number;
    }


    public int GetNumberOfDownloadingPhotos()
    {
        return numbersOfDownloadingOption[ChooseNumberIndex];
    }
}
