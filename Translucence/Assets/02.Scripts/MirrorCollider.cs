using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCollider : MonoBehaviour
{
    public List<Vector3> collisionObjectsPosition;
    [SerializeField] Mirror mirror;
    public LayerMask layerMask;

    private void Start()
    {
        collisionObjectsPosition = new List<Vector3>();
        this.transform.GetComponent<BoxCollider>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TestObject"))
        {
            Ray ray = new Ray(other.transform.position, -mirror.outDir * 100f);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData, layerMask))
            {
                collisionObjectsPosition.Add(hitData.point);
            }
        }
    }

}
