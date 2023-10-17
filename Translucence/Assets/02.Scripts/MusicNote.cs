using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class MusicNote : MonoBehaviour
{
    private bool _isMusicLines = false;
    private bool _isMusicBlanks = false;

    private Transform _musicLine;
    private Transform _musicBlank;

    private void OnEnable()
    {
        StartCoroutine(CheckDestroy());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MusicLines"))
        {
            _isMusicLines = true;
            _musicLine = collision.transform;
        }
        if (collision.CompareTag("MusicBlanks"))
        {
            _isMusicBlanks = true;
            _musicBlank = collision.transform;
        }
        CheckLines();
        GetComponent<Image>().enabled = true;
    }

    private void CheckLines()
    {
        if(_isMusicLines && _isMusicBlanks)
        {
            float distanceLineY = Mathf.Abs(gameObject.transform.position.y - _musicLine.transform.position.y);
            float distanceBlankY = Mathf.Abs(gameObject.transform.position.y - _musicBlank.transform.position.y);

            if(distanceLineY <= distanceBlankY )
            {
                gameObject.transform.position = new(gameObject.transform.position.x, _musicLine.transform.position.y);
            }
            else
            {
                gameObject.transform.position = new(gameObject.transform.position.x, _musicBlank.transform.position.y);
            }
        }
        else if(_isMusicLines)
        {
            gameObject.transform.position = new(gameObject.transform.position.x, _musicLine.transform.position.y);
        }
        else if (_isMusicBlanks)
        {
            gameObject.transform.position = new(gameObject.transform.position.x, _musicBlank.transform.position.y);
        }
    }

    IEnumerator CheckDestroy()
    {
        yield return new WaitForFixedUpdate();
        if(!GetComponent<Image>().enabled)
        {
            Destroy(gameObject);
        }
    }
}
