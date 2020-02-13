using System.Collections;
using System.Collections.Generic;
using Production.Plugins.RyanScriptableObjects.SOEvents.VoidEvents;
using UnityEngine;

public class ArrowComponent : MonoBehaviour
{
    public Transform Arrow;
    [SerializeField] private float arrowY;
    public void DisplayOnRespawn()
    {
        Arrow.gameObject.SetActive(true);
    }

    public void UnactiveArrow()
    {
        Arrow.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 8.5f)
        {
            Arrow.gameObject.SetActive(true);
        }
        Vector2 newPos = transform.position;
        newPos.y = arrowY;
        Arrow.position = newPos;
    }
}
