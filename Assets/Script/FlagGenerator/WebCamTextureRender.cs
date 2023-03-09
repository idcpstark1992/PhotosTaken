using UnityEngine;
using UnityEngine.UI;

public class WebCamTextureRender : MonoBehaviour
{
    [SerializeField] private RawImage ImageRenderCamera;
    void Start()
    {
        WebCamTexture webcamTexture = new (1920,1080);
        webcamTexture.requestedFPS = 30;
        ImageRenderCamera.texture = webcamTexture;
        ImageRenderCamera.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }
}
