using UnityEngine;

public class CreateFlagDinamically : MonoBehaviour
{
    [SerializeField] private Vector3 InitialCameraPosition, FinalCameraPosition;
    [SerializeField] private ScriptedQuad ScriptedFlagItemObject;
    [SerializeField] private int HorizontalAmount;
    [SerializeField] private int VerticalAmount;
    [SerializeField] private Material MeshMaterial;
    [SerializeField] private Transform FlagContainer;
    [SerializeField] private Transform AimPointReference;
    [SerializeField] private Transform PhotosHolderTransform;
    [SerializeField] private Transform MainCameraTransform;
    [SerializeField] private float RotationSpeed;
    private bool RotatePhotosHolder;
    public static Transform CameraTransform;
    

    private void Start()
    {
        MainCameraTransform.transform.position = InitialCameraPosition;
        CameraTransform = AimPointReference;
        Vector3 m_position = Vector3.zero;
        for (int x = 0; x < HorizontalAmount; x++)
            for (int y = 0; y < VerticalAmount; y++)
            {
                m_position.Set(x, y, 1);
                ScriptedQuad m_toInstantiate = Instantiate(ScriptedFlagItemObject);
                m_toInstantiate.Init(m_position, MeshMaterial);
                m_toInstantiate.transform.SetParent(FlagContainer);
            }               
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventsHolder.Event_OnSphere?.Invoke();
            LeanTween.move(MainCameraTransform.gameObject, FinalCameraPosition, .5f);
            RotatePhotosHolder = true;
        }
            

        
    }
    private void FixedUpdate()
    {
        if (RotatePhotosHolder)
            PhotosHolderTransform.Rotate(Vector3.up, RotationSpeed);
    }



}
