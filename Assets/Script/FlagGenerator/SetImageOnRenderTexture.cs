using UnityEngine;
using UnityEngine.UI;
public class SetImageOnRenderTexture : MonoBehaviour
{
    [SerializeField] private RawImage imageTexture;

    private void OnEnable()
    {
        EventsHolder.SetTextures += OnTexture;
    }
    private void OnDisable()
    {
        EventsHolder.SetTextures -= OnTexture;
    }
    private void OnTexture (Texture2D _imageTexture)
    {
        imageTexture.texture = _imageTexture;
    }
}
