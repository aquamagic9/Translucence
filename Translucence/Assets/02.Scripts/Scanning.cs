using UnityEngine;
using UnityEngine.UI;

public class Scanning : MonoBehaviour
{
    public Canvas canvas;
    public GameObject musicPaperPrefab;
    public GameObject musicNotePrefab;

    private GameObject _paper;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (_paper != null)
            {
                Destroy(_paper);
                _paper = null;
            }
            _paper = Instantiate(musicPaperPrefab, canvas.transform);
            foreach (var item in GameObject.FindGameObjectsWithTag("Scanable"))
            {
                var note = Instantiate(musicNotePrefab, _paper.transform);
                note.GetComponent<Image>().enabled = false;
                note.transform.position = Camera.main.WorldToScreenPoint(item.transform.position);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if(_paper != null)
            {
                _paper.SetActive(false);
            }
        }
    }
}
