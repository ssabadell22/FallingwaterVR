using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Transform _XROrigin;
    [SerializeField] private List<Transform> _locations;
    [SerializeField] private TMP_Dropdown _locationDropdown;

    private Vector3 _requestedPosition;
    private Quaternion _requestedRotation;
    private bool _checkMoveRequest = false;
    private float _positionResetTimer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        _locationDropdown.ClearOptions();
        List<string> ddlist = new List<string>();
        foreach (var loc in _locations)
            ddlist.Add(loc.name);
        _locationDropdown.AddOptions(ddlist);
    }

    public void GoToLocation(int index)
    {
        _requestedPosition = _locations[index].position;
        _requestedRotation = _locations[index].rotation;
        _XROrigin.rotation = _requestedRotation;
        _XROrigin.position = _requestedPosition;
        _checkMoveRequest = true;
        _positionResetTimer = 0f;
        CloseMenu();

        // TeleportRequest tpReq;
        // {
        //     Transform tpTM = _locations[index];
        //     tpReq.destinationPosition = tpTM.position;
        //     tpReq.destinationRotation = tpTM.rotation;
        //     if (tpTM.TryGetComponent(out TeleportationAnchor anchor))
        //         tpReq.matchOrientation = anchor.matchOrientation;
        //     else
        //         tpReq.matchOrientation = MatchOrientation.TargetUpAndForward;
        //     tpReq.requestTime = Time.time;
        // }
        // _teleportationProvider.QueueTeleportRequest(tpReq);
    }

    // Update is called once per frame
    void Update()
    {
        // Sometimes, the continuous move provider fights with our "insta" position
        // change. I tried a few ways to get around it, but it seems teleportation
        // (either through the XR Toolkit or as done here) is somewhat incompatible.
        // My "fix" is to just continue setting the new position for 1 second. 
        if (!_checkMoveRequest)
            return;
        if (_positionResetTimer > 1f)
        {
            _checkMoveRequest = false;
            return;
        }
        _positionResetTimer += Time.deltaTime;
        // This uses a toleranced comparison. Unfortunately a update cycle with a matching
        // position was not sufficient, so I added the timer-based mechanism, and with that,
        // the comparison is not needed.
        //if (_XROrigin.position == _requestedPosition)
        //{
        //    _checkMoveRequest = false;
        //    return;
        //}
        // Just keep pushing the new position for 1 second.
        _XROrigin.position = _requestedPosition;
        // Generally, rotations take effect, so leave it off for now
    }

    public void CloseMenu()
    {
        // This was done in the Foundations course to avoid a brief flash, when we had multiple
        // windows (canvases?) that might be closed all at once, when the menu was re-activated.
        // I don't see any reason why we should keep this.
        Invoke(nameof(DeactivateMenu), 0.1f);
    }
    private void DeactivateMenu()
    {
        gameObject.SetActive(false);
    }
}
