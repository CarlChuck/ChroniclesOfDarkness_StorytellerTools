using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExportFile : MonoBehaviour
{
    #region Singleton
    public static ExportFile Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    //Object To Screenshot
    [SerializeField] private RectTransform _objToScreenshot;
    [SerializeField] private GameObject loadingScreen;

    public void OnClickTakeScreenshotAndSaveButton()
    {

        StartCoroutine(TakeSnapShotAndSave());
    }
    //Using a Coroutine instead of normal method
    public IEnumerator TakeSnapShotAndSave()
    {
        string nameOfCharacter = CharGenerator.Instance.selectedTemplate.GetName();

        //Code will throw error at runtime if this is removed
        yield return new WaitForEndOfFrame();

        //Get the corners of RectTransform rect and store it in a array vector
        Vector3[] corners = new Vector3[4];
        _objToScreenshot.GetWorldCorners(corners);

        //Remove 100 and you will get error
        int width = ((int)corners[3].x - (int)corners[0].x);
        int height = (int)corners[1].y - (int)corners[0].y;
        var startX = corners[0].x;
        var startY = corners[0].y;

        //Make a temporary texture and read pixels from it
        Texture2D ss = new Texture2D(width, height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
        ss.Apply();

        //Save the screenshot to disk
        byte[] byteArray = ss.EncodeToPNG();
        string savePath = Application.persistentDataPath + "/" + nameOfCharacter + ".png";
        System.IO.File.WriteAllBytes(savePath, byteArray);

        // Destroy texture to avoid memory leaks
        Destroy(ss);
        loadingScreen.SetActive(true);
        StartCoroutine(EndLoadingScreen(loadingScreen, 0.5f));
    }

    public IEnumerator EndLoadingScreen(GameObject load, float time = 1f)
    {
        yield return new WaitForSeconds(time);
        load.SetActive(false);
    }
}
