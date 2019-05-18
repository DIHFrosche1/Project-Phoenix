using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// place this script on a empty Gameobject

[RequireComponent(typeof(BoxCollider))]
public class DrawRoomTest : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 1f, 0f);
        Gizmos.DrawWireCube(GetComponent<BoxCollider>().transform.localPosition, GetComponent<BoxCollider>().transform.localScale);

        Gizmos.color = new Color(0f, 1f, 0f, 0.3f);
        Gizmos.DrawCube(GetComponent<BoxCollider>().transform.localPosition, GetComponent<BoxCollider>().transform.localScale);
    }
}
