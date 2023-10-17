using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCollider : MonoBehaviour
{
    
    [SerializeField] Mirror mirror;
    public LayerMask layerMask;
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TestObject"))
        {
            Debug.Log("실행이 되는거니?");
            Ray ray = new Ray(other.transform.position, -mirror.outDir * 100f);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData, layerMask))
            {
                Player.GetComponent<Scanning>().CreateMirrorNote(hitData.point);
            }
        }
    }
}
