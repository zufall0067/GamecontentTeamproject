using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Transform movePoint;

    public void Move(Transform player)
    {
        player.position = movePoint.position;
    }
}
