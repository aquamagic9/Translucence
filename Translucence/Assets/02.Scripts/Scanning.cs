using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Scanning : MonoBehaviour
{
    public Canvas canvas;
    public GameObject musicPaperPrefab;
    public GameObject musicNotePrefab;

    public List<GameObject> scanningObjects = new List<GameObject>();

    private GameObject _paper;
    private List<GameObject> _mirrorList = new List<GameObject>();
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckMirror();
            CreateNote();
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (_paper != null)
            {
                _paper.SetActive(false);
            }
            ResetMirror();
        }
    }

    public void CreateNote()
    {
        if (_paper != null)
        {
            Destroy(_paper);
            _paper = null;
        }
        _paper = Instantiate(musicPaperPrefab, canvas.transform);
        foreach (var item in scanningObjects)
        {
            var note = Instantiate(musicNotePrefab, _paper.transform);
            note.GetComponent<Image>().enabled = false;
            note.transform.position = Camera.main.WorldToScreenPoint(item.transform.position);
        }
    }

    public void CreateMirrorNote(Vector3 pos)
    {
        var note = Instantiate(musicNotePrefab, _paper.transform);
        note.GetComponent<Image>().enabled = false;
        note.transform.position = Camera.main.WorldToScreenPoint(pos);
    }

    private void CheckMirror()
    {
        var mirror = scanningObjects.Where((item) => item.layer.Equals(LayerMask.NameToLayer("Mirror"))).ToList();
        if (mirror.Count > 0)
        {
            foreach (var item in mirror)
            {
                Destroy(item.GetComponent<ScanableObject>());
                scanningObjects.Remove(item);
                item.GetComponentInChildren<BoxCollider>().enabled = true;
                _mirrorList.Add(item);
            }
        }
    }

    private void ResetMirror()
    {
        if (_mirrorList.Count > 0)
        {
            foreach (var item in _mirrorList)
            {
                item.AddComponent<ScanableObject>();
                item.GetComponentInChildren<BoxCollider>().enabled = false;
                scanningObjects.Add(item);
            }
        }
        _mirrorList = new List<GameObject>();
    }
}
