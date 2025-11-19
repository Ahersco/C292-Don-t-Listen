using UnityEngine;

public class ProximityCameraControl : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera proximityCamera;
    [SerializeField] float revealDistance = 15f;
    [SerializeField] LayerMask hiddenLayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupCameras();
    }

    // Update is called once per frame
    void Update()
    {
        if (proximityCamera != null)
        {
            proximityCamera.farClipPlane = revealDistance;
        }
    }

    void SetupCameras()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        mainCamera.cullingMask &= ~hiddenLayer;

        if (proximityCamera == null)
        {
            GameObject camObj = new GameObject("ProximityCamera");
            camObj.transform.SetParent(transform);
            camObj.transform.localPosition = Vector3.zero;
            camObj.transform.localRotation = Quaternion.identity;

            proximityCamera = camObj.AddComponent<Camera>();
        }

        proximityCamera.cullingMask = hiddenLayer;
        proximityCamera.clearFlags = CameraClearFlags.Depth;
        proximityCamera.depth = mainCamera.depth + 1;
        proximityCamera.farClipPlane = revealDistance;
    }

    public void SetupProximityObject(GameObject obj)
    {
        int layerIndex = LayerMaskToLayer(hiddenLayer);
        SetLayerRecursively(obj, layerIndex);
    }

    // Convert LayerMask to layer index
    private int LayerMaskToLayer(LayerMask mask)
    {
        int layerNumber = 0;
        int layer = mask.value;
        while (layer > 1)
        {
            layer = layer >> 1;
            layerNumber++;
        }
        return layerNumber;
    }

    // Set layer for object and all children
    private void SetLayerRecursively(GameObject obj, int layer)
    {
        obj.layer = layer;
        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, layer);
        }
    }
}
