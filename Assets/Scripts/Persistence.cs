using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//contains all code stuff needed to persist between scenes
public class Persistence : MonoBehaviour
{
    public static Persistence Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        OVRScreenFade fade = OVRScreenFade.instance;
        fade.FadeIn();
    }
}
