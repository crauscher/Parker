using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This should identify the active target and follow them on the map

public class cameraController : MonoBehaviour
{
    // config parameters
    [SerializeField] private float followSpeed = 1.0f;
    [SerializeField] float cameraHeight = 10.0f;

    // state variables
    [SerializeField] ObjectValue CamFocus;

    private void Start()
    {
        var playerObject = GameObject.FindGameObjectWithTag("Attendant");
        CamFocus.SetValue(playerObject);
    }
    void LateUpdate()
    {
        FollowFocusItem();
    }

    //private methods
    void FollowFocusItem()
    {
        var _focus = CamFocus.value;
        transform.position = Vector3.Lerp( transform.position, new Vector3(_focus.transform.position.x, _focus.transform.position.y, _focus.transform.position.z - cameraHeight), followSpeed * Time.deltaTime);
    }
}
