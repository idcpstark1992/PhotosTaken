using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;
public class Pictures : MonoBehaviour
{
    [SerializeField] RawImage testprint;
    [SerializeField] private string path;
    private List<Texture2D> TexturesList;
    private List<string> TexturesPathList;
    // Start is called before the first frame update
    void Start()
    {
        foreach (string file in Directory.GetFiles(string.Concat(Application.persistentDataPath), "*.png"))
            TexturesPathList.Add(file);

        LoadTexturesInMemory();
    }
    void LoadTexturesInMemory()
    {
        foreach (var item in TexturesPathList)
        {
            TexturesList.Add(LoadPNG(item));
        }

        EventsHolder.SetTextures?.Invoke(TexturesList[Random.Range(0, TexturesList.Count)]);
    }



    private  Texture2D LoadPNG(string filePath)
    {
        Texture2D tex = null;
        byte[] fileData;
        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
        }
        return tex;
    }
}
