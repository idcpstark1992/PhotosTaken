using UnityEngine;
using UnityEngine.UI;
public class SetImageOnRenderTexture : MonoBehaviour
{
    [SerializeField] private RawImage imageTexture;

    public void Init()
    {
        imageTexture.texture = Pictures.GetRandomTexture();
    }
}
