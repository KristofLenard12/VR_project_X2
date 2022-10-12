using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _triggerTextObject;
    [SerializeField]
    private GameObject _hammerTextObject;
    [SerializeField]
    private GameObject _sawTextObject;
    [SerializeField]
    private GameObject _crowBarTextObject;

    [SerializeField]
    private GameObject _hammer;
    [SerializeField]
    private GameObject _saw;
    [SerializeField]
    private GameObject _crowbar;

    private TextMeshPro _triggerText;
    private TextMeshPro _hammerText;
    private TextMeshPro _sawText;
    private TextMeshPro _crowBarText;

    List<string> _tabooTriggers;

    string _hammerCode = "000";
    string _sawCode = "0000";
    string _crowBarCode = "0000";
    string _favoriteTool = "";
    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = int.Parse("" + UnityEngine.Random.Range(0, 7));
        Debug.Log("Random number: " + randomNumber);
        SetupPath(randomNumber);

        SetTriggerText();

        SetCrowbarText();
        SetHammerText();
        SetSawText();

        SetFavoriteToolPos();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Trigger"))
        {
            string triggerName = other.gameObject.name.Substring(7);
            CheckCollider(triggerName);
        }
    }

    private void CheckCollider(string name)
    {
        if (_tabooTriggers.Contains(name))
        {
            _triggerText.text = name;
        }
    }

    private void SetupPath(int randomNumber)
    {
        switch (randomNumber)
        {
            case 0:
                _tabooTriggers = new List<string> { "A1","C1","D1","D2","D3","C3","B3","D4","C2"};
                _hammerCode = "199AD34";
                _favoriteTool = "hammer";
                break;
            case 1:
                _tabooTriggers = new List<string> { "A1","B1","D2","D1","D3","D4","C4"};
                _hammerCode = "191AD35";
                _favoriteTool = "hammer";
                break;
            case 2:
                _tabooTriggers = new List<string> { "D1","C1","B1","A1","B2","B3","D4"};
                _crowBarCode = "189AD31";
                _favoriteTool = "crowbar";
                break; 
            case 3:
                _tabooTriggers = new List<string> { "B4","A1","B1","A2","B2","D3","D2","D1","C1"};
                _crowBarCode = "190DY12";
                _favoriteTool = "crowbar";
                break;
            case 4:
                _tabooTriggers = new List<string> { "B1","C1","D1","D2","D3","D4","B3","A3"};
                _sawCode = "190DY30";
                _favoriteTool = "saw";
                break;
            case 5:
                _tabooTriggers = new List<string> { "D1","D2","D4","C1","C2","B1","B2","B3","A1"};
                _sawCode = "190DD11";
                _favoriteTool = "saw";
                break;
        }
    }

    private void SetTriggerText()
    {
        _triggerText = _triggerTextObject.GetComponent<TextMeshPro>();
        string full = "";
        foreach (string item in _tabooTriggers)
        {
            full += item + " ";
        }
        _triggerText.text = full;
        _triggerTextObject.transform.SetParent(this.transform);
    }

    private void SetHammerText()
    {
        _hammerText = _hammerTextObject.GetComponent<TextMeshPro>();
        _hammerText.text = _hammerCode;
    }

    private void SetCrowbarText()
    {
        _crowBarText = _crowBarTextObject.GetComponent<TextMeshPro>();
        _crowBarText.text = _crowBarCode;
    }

    private void SetSawText()
    {
        _sawText = _sawTextObject.GetComponent<TextMeshPro>();
        _sawText.text = _sawCode;
    }

    private void SetFavoriteToolPos()
    {
        switch (_favoriteTool)
        {
            case "hammer":
                Instantiate(_hammer, new Vector3(-2.811f, 1.371f, 2.913f), Quaternion.identity);
                break;
            case "saw":
                Instantiate(_saw, new Vector3(-2.803f, 1.356f, 2.938f), Quaternion.identity);
                break;
            case "crowbar":
                Instantiate(_crowbar, new Vector3(-2.799f, 1.389f, 2.97f), Quaternion.identity);
                break;
        }
    }
}
