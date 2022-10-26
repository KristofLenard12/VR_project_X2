using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    float _currentTime;
    string _putPosition;
    bool _timer;
    [SerializeField]
    private TextMeshPro _currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_currentTimeText, new Vector3(-2.282f, 2.315f, 3.695714f), Quaternion.identity);
        _currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer == true)
        {
            _currentTime = _currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        _currentTimeText.text = "Time: " + time.ToString(@"mm\:ss\:fff");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Trigger"))
        {
            string triggerName = other.gameObject.name.Substring(7);
            if (triggerName.Equals(_putPosition))
            {
                _timer = false;
                _currentTimeText.text = "YOU HAVE WON";
            }
        }
    }

    public void SetPutPosition(string position)
    {
        _putPosition = position;
        _timer = true;
    }
}
