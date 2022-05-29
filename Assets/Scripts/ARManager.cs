using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARManager : MonoBehaviour
{

    private ARPlaneManager planeManager;
    private ARSessionOrigin sessionOrigin;
    private ARPointCloudManager pointCloudManager;
    public GameObject asset;


   void Awake()
    {        
        planeManager = FindObjectOfType<ARPlaneManager>();
        sessionOrigin = FindObjectOfType<ARSessionOrigin>();
        pointCloudManager = FindObjectOfType<ARPointCloudManager>();
    }

    // Unity Messages
    private void OnEnable() {
        SetEvents();
    }

    private void OnDisable() {
        ClearEvents();
    }

    // Methods
    private void SetEvents() {
        pointCloudManager.pointCloudsChanged += OnPointCloudsChanged;
        planeManager.planesChanged += OnPlanesChanged;
    }

    private void ClearEvents() {
        pointCloudManager.pointCloudsChanged -= OnPointCloudsChanged;
        planeManager.planesChanged -= OnPlanesChanged;
    }

    private void OnPointCloudsChanged(ARPointCloudChangedEventArgs pEventArgs) {
        // Debug.Log("Point Cloud Changed");
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs pEventArgs) {
        Debug.Log($"AR Planes Changed. Added {pEventArgs.added.Count}, Updated {pEventArgs.updated.Count}, Removed {pEventArgs.removed.Count}");
    }

}
