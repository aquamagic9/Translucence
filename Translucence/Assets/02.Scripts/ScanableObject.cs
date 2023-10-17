using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanableObject : MonoBehaviour
{
    private void OnBecameVisible()
    {
        Camera.main.transform.parent.GetComponent<Scanning>().scanningObjects.Add(gameObject);
    }

    private void OnBecameInvisible()
    {
        Camera.main.transform.parent.GetComponent<Scanning>().scanningObjects.Remove(gameObject);
    }
}
