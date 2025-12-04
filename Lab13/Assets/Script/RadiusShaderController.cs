using UnityEngine;

public class RadiusShaderController : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] float radius;
    [SerializeField] Renderer targetRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mat = targetRenderer.material;
        mat.SetVector("_PlayerPos", Player.position);
        mat.SetFloat("_Radius", radius);
    }
}
