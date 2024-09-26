using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UIg‚¤‚Æ‚«‚Í–Y‚ê‚¸‚ÉB
using UnityEngine.UI;

public class HPBarDirection : MonoBehaviour
{
    public Canvas canvas;

    void Update()
    {
        Vector3 newCanvasPos = transform.position;
        newCanvasPos.z = transform.position.z + 1.5f;
        // EnemyCanvas‚ğMain Camera‚ÉŒü‚©‚¹‚é
        canvas.transform.position = newCanvasPos;
    }
}