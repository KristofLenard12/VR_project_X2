using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    private GameObject _hammer;
    [SerializeField]
    private GameObject _saw;
    [SerializeField]
    private GameObject _crowbar;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Setting positions");
        SetHammerPosition(int.Parse("" + UnityEngine.Random.Range(0, 3)));
        SetSawPosition(int.Parse("" + UnityEngine.Random.Range(0, 3)));
        SetCrowbarPosition(int.Parse("" + UnityEngine.Random.Range(0, 3)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetHammerPosition(int number)
    {
        switch (number)
        {
            case 0:
                _hammer.transform.position = new Vector3(-2.297f, 1.886134f, -1.46619f);
                break;
            case 1:
                _hammer.transform.position = new Vector3(0.65f, 0.573f, -1.919f);
                break;
            case 2:
                _hammer.transform.position = new Vector3(2.487f, 2.21f, -1.784f);
                break;
        }
    }

    private void SetSawPosition(int number)
    {
        switch (number)
        {
            case 0:
                _saw.transform.position = new Vector3(-2.435f, 1.065f, 1.048f);
                break;
            case 1:
                _saw.transform.position = new Vector3(-2.137f, 1.854f, -2.053f);
                break;
            case 2:
                _saw.transform.position = new Vector3(-1.5f, 0.057f, -1.998f);
                break;
        }
    }

    private void SetCrowbarPosition(int number)
    {
        switch (number)
        {
            case 0:
                _crowbar.transform.position = new Vector3(2.668f, 1.154f, -0.852f);
                break;
            case 1:
                _crowbar.transform.position = new Vector3(2.5f, 0.064f, -2.015f);
                break;
            case 2:
                _crowbar.transform.position = new Vector3(0.638f, 0.064f, -1.933f);
                break;
        }
    }
}
