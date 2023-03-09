using UnityEngine;

public class ScriptedQuad : MonoBehaviour
{
    private Vector3 OriginalPosition;
    private Quaternion OriginalRotation; 
    [SerializeField] private SetImageOnRenderTexture renderTexture;
    private bool LookAtCamera;
    private void OnEnable()
    {
        EventsHolder.Event_OnSphere += OnSphereShape;
        EventsHolder.Event_ReturnToPosition += OnReturnToPosition;

    }
    private void OnDisable()
    {

        EventsHolder.Event_OnSphere += OnSphereShape;
    }
    private void Start()
    {
        
    }
    public void  Init(Vector3 _position, Material _material)
    {
        Mesh m_mesh;
        MeshFilter m_meshFilter     = gameObject.AddComponent<MeshFilter>();
        MeshRenderer m_meshRenderer = gameObject.AddComponent<MeshRenderer>();
        m_mesh = new();
        m_mesh.name = "scriptedQuad";

        Vector3[] m_vertices;
        Vector3[] m_normals;
        Vector2[] m_uvs;
        int[] m_triangles;

        float m_yoffset = .2f  *   _position.y;
        float m_xoffset = .1f  *   _position.x ;

        Vector2 m_uv00 = new (m_xoffset, m_yoffset);
        Vector2 m_uv10 = new (m_xoffset+.1f, m_yoffset);
        Vector2 m_uv01 = new (m_xoffset, m_yoffset + .2f);
        Vector2 m_uv11 = new (m_xoffset +.1f, m_yoffset+.2f);

        Vector3 m_p0 = new (-.5f, -.5f, .5f);
        Vector3 m_p1 = new (.5f, -.5f, .5f);
        Vector3 m_p2 = new (.5f, .5f, .5f);
        Vector3 m_p3 = new (-.5f, .5f, .5f);

        m_vertices  = new Vector3[] { m_p0, m_p1, m_p2, m_p3 };
        m_normals   = new Vector3[] { Vector3.forward, Vector3.forward, Vector3.forward, Vector3.forward };
        m_uvs       = new Vector2[] { m_uv11, m_uv01, m_uv00, m_uv10 };
        m_triangles = new int[] { 3, 1, 0, 3, 2, 1 };

        m_mesh.vertices = m_vertices;
        m_mesh.normals  = m_normals;
        m_mesh.uv       = m_uvs;
        m_mesh.triangles = m_triangles;
        m_mesh.RecalculateBounds();
        m_meshFilter.mesh = m_mesh;
        m_meshRenderer.material = _material;

        gameObject.transform.position = _position;
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
        renderTexture.Init();
        OriginalPosition = gameObject.transform.position;
        OriginalRotation = gameObject.transform.localRotation;
    }
    private void Update()
    {
        if (LookAtCamera)
            gameObject.transform.LookAt(CreateFlagDinamically.CameraTransform,Vector3.up);
    }
    private void OnSphereShape()
    {
        LookAtCamera = true;
        Vector3 m_finalPosition = Random.insideUnitSphere * 4;
        LeanTween.move(gameObject, m_finalPosition, 1f);

    }
    private void OnReturnToPosition()
    {
        LookAtCamera = false;
        LeanTween.move(gameObject, OriginalPosition, .5f);
        gameObject.transform.localRotation = OriginalRotation;
    }
}