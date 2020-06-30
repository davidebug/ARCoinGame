using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public GameObject playerObject;

    // Update is called once per frame
    void Update()
    {
                Debug.Log("Player position --> " +  playerObject.transform.position.ToString());
    }
}
