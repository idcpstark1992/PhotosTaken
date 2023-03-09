using UnityEngine;
using System.IO;
using System.Collections.Generic;
public class Pictures : MonoBehaviour
{
    [SerializeField]private List<Texture2D> TexturesList = new ();
    private static List<Texture2D> Txtures2d = new List<Texture2D>();
    [SerializeField]private List<string> TexturesPathList = new ();
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
        Txtures2d = TexturesList;
    }

    public static Texture2D GetRandomTexture()
    {
        return Txtures2d[Random.Range(0, Txtures2d.Count)];
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
