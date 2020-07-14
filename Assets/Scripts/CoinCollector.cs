﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;


public class CoinCollector : MonoBehaviour
{
    public AudioSource coinSound;

    [SerializeField]
    public ARPlaneManager planeManager;

    public Text textScore;

    private int score = 0;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Coin")
        {
            Debug.Log("COIN COLLECTED");
            
            collision.gameObject.transform.position = CalculateNextPosition();
            Debug.Log("COIN - New Position --> " + collision.gameObject.transform.position.ToString());
            score ++;
            textScore.text = score.ToString();
            coinSound.Play();
        }
    }

    Vector3 CalculateNextPosition()
    {
        List<Vector3> possiblePositions = new List<Vector3>();
        planeManager = planeManager.GetComponent<ARPlaneManager>();
        Debug.Log("COIN - Trackable Planes found: " + planeManager.trackables.count.ToString());
        foreach (ARPlane plane in planeManager.trackables)
        {
            Debug.Log("COIN - Plane Rand");
            Vector3 min = plane.gameObject.GetComponent<MeshFilter>().mesh.bounds.min;
            Vector3 max = plane.gameObject.GetComponent<MeshFilter>().mesh.bounds.max;
            Debug.Log("COIN - MIN Plane Bound --> " + min.ToString());
            Debug.Log("COIN - MAX Plane Bound --> " + max.ToString());
            Debug.Log(plane.gameObject.transform.position.y);
            Vector3 position = plane.gameObject.transform.position - new Vector3((Random.Range(min.x*0.98f, max.x*0.98f)), plane.gameObject.transform.position.y * 0.02f, (Random.Range(min.z*0.98f, max.z*0.98f)));
            possiblePositions.Add(position);
        }
        if(possiblePositions.Count == 0){
            Debug.Log("COIN - No possible positions found");
            return new Vector3(0,0,0);
        }
        int r = Random.Range(0, possiblePositions.Count);
        return possiblePositions[r];
        
    }

}
