using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARPlaneManager))]
public class SpawnObjectOnPlane : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private GameObject spawnedObj;

    [SerializeField]
    public GameObject PlaceablePrefab;

    [SerializeField]
    public ARPlaneManager arPlaneManager;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    public void Awake(){
        raycastManager = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += SpawnFirstTime;
    }

    private void SpawnFirstTime(ARPlanesChangedEventArgs args){
        if(args.added != null && spawnedObj == null){
            ARPlane arPlane = args.added[0];
            // Vector3 min = arPlane.GetComponent<MeshFilter>().mesh.bounds.min;
            // Vector3 max = arPlane.GetComponent<MeshFilter>().mesh.bounds.max;
            // Vector3 position = arPlane.transform.position -  new Vector3 ((Random.Range(min.x*5, max.x*5)), arPlane.transform.position.y, (Random.Range(min.z*5, max.z*5)));
            spawnedObj = Instantiate(PlaceablePrefab, arPlane.transform.position, Quaternion.identity);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log("Coin position --> " +  spawnedObj.transform.position.ToString());
    }
}
