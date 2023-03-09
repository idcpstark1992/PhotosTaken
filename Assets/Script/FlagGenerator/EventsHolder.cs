public static  class EventsHolder
{
    public delegate void DELEGATE_OnSphereshape();
    public delegate void DELEGATE_OnGetTextures(UnityEngine.Texture2D _textures);
    public static DELEGATE_OnSphereshape Event_OnSphere;
    public static DELEGATE_OnSphereshape Event_ReturnToPosition;
    public static DELEGATE_OnGetTextures SetTextures;
}