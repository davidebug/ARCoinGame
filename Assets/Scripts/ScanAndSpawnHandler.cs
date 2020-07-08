using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ScanAndSpawnHandler : MonoBehaviour
{
    [SerializeField]
    public GameObject startPanel;

    [SerializeField]
    private ARPlaneManager aRPlaneManager;
    
    [SerializeField]
    private Button scanButton;

    private void DismissStartPanel() => startPanel.SetActive(false);

    private void DismissButton() => scanButton.gameObject.SetActive(false);

    private ARRaycastManager raycastManager;
    private GameObject spawnedObj;

    [SerializeField]
    public GameObject PlaceablePrefab;


    void Update()
    {
        Debug.Log("Coin position --> " +  spawnedObj.transform.position.ToString());
    }
    

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = aRPlaneManager.GetComponent<ARPlaneManager>();
        aRPlaneManager.enabled = false;
        if (scanButton != null)
        {
            scanButton.onClick.AddListener(() =>  TogglePlaneDetection());
        }
    }


     Vector3 CalculateNextPosition()
    {
        List<Vector3> possiblePositions = new List<Vector3>();
        Debug.Log("COIN - Trackable Planes found: " + aRPlaneManager.trackables.count.ToString());
        foreach (ARPlane plane in aRPlaneManager.trackables)
        {
            Debug.Log("COIN - Plane Rand");
            Vector3 min = plane.gameObject.GetComponent<MeshFilter>().mesh.bounds.min;
            Vector3 max = plane.gameObject.GetComponent<MeshFilter>().mesh.bounds.max;
            Debug.Log("COIN - MIN Plane Bound --> " + min.ToString());
            Debug.Log("COIN - MAX Plane Bound --> " + max.ToString());
            Debug.Log(plane.gameObject.transform.position.y);
            Vector3 position = plane.gameObject.transform.position - new Vector3((Random.Range(min.x , max.x)), plane.gameObject.transform.position.y*0.05f, (Random.Range(min.z , max.z )));
            possiblePositions.Add(position);
        }
        if(possiblePositions.Count == 0){
            Debug.Log("COIN - No possible positions found");
            return new Vector3(0,0,0);
        }
        int r = Random.Range(0, possiblePositions.Count);
        return possiblePositions[r];
        
    }


    private void TogglePlaneDetection()
    {
        aRPlaneManager.enabled = !aRPlaneManager.enabled;
        foreach (ARPlane plane in aRPlaneManager.trackables)
        {
            plane.gameObject.SetActive(aRPlaneManager.enabled);
        }
        
        if(aRPlaneManager.enabled){
            DismissStartPanel();
        }else{
            DismissButton();
            spawnedObj = Instantiate(PlaceablePrefab, CalculateNextPosition(), Quaternion.identity);
        }

        scanButton.GetComponentInChildren<Text>().text = aRPlaneManager.enabled ? "Stop and Play" : "Start Scan";
    }

}
