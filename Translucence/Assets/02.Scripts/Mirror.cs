using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField] GameObject playerCamera;
    [SerializeField] GameObject mirrorCamera;
    [SerializeField] MirrorCollider mirrorCollider;

    Vector3 dir;
    Vector3 inDir;
    [HideInInspector] public Vector3 outDir;
    Vector3 normal;

    private void Update()
    {
        CalculateDir();
    }

    void CalculateDir()
    {
        inDir = (this.transform.position - playerCamera.transform.position).normalized;
        normal = transform.TransformDirection(-Vector3.forward);
        outDir = Vector3.Reflect(inDir, normal);
        mirrorCamera.transform.rotation = Quaternion.LookRotation(outDir);
        mirrorCollider.transform.parent.transform.rotation = Quaternion.LookRotation(-outDir);
    }

    private void OnDrawGizmos()
    {
        CalculateDir();
        Gizmos.DrawRay(this.transform.position, outDir * 10f);

    }
}
