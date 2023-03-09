using UnityEngine;

public class WebCamShotSnapSave : MonoBehaviour
{
    [SerializeField] private Camera MainCameraReference;
    [SerializeField] private float xmin, ymin;
    [SerializeField] private int xmax, ymax;
    [SerializeField] private GameObject textureObject;
    public void saveImage()
    {
        int width = 1000;
        int height = 700;

        RenderTexture RT = new RenderTexture(width, height,24);
        Camera snapCam = MainCameraReference;
        snapCam.targetTexture = RT;
        snapCam.Render();
        RenderTexture.active = RT;
        Texture2D snap = new Texture2D(width, height, TextureFormat.ARGB32, false);
        snap.ReadPixels(new Rect(xmin, ymin, width, height), xmax, ymax);
        
        RenderTexture.active = null;
        snapCam.targetTexture = null;

        saveToPNG(snap);
    }

    void saveToPNG(Texture2D snap)
    {
        string iter = System.DateTime.UtcNow.ToLongTimeString().Replace(":", "_");
        byte[] bytes = snap.EncodeToPNG();
        System.IO.File.WriteAllBytes(string.Concat(Application.persistentDataPath + $"\\{iter}.png"), bytes);
        LeanTween.scale(textureObject, Vector3.zero, .4f);
    }
}
