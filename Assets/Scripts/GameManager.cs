using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//This class is responsible for randomizing the audio source and sound effects.
public class GameManager : MonoBehaviour
{
    private GameObject audioSourceGameObject;
    private AudioSource audioSource;
    public AudioClip winAudioClip;
    public float audioDelay;

    private GameObject[] targets;
    private GameObject secondTarget;
    private int currentTargetIndex;

    private bool isFirstTargetSelected;

    private XRSimpleInteractable interactable;
    private XRSimpleInteractable interactable2;

    void Awake()
    {
        //get audio source game object and component, get all possible target gameobjects, get chair (completes level)
        audioSourceGameObject = GameObject.Find("RandomAudioSource");
        audioSource = audioSourceGameObject.GetComponent<AudioSource>();
        audioDelay = 3.0f;
        targets = GameObject.FindGameObjectsWithTag("Target");
        secondTarget = GameObject.FindGameObjectWithTag("SecondTarget");
        interactable2 = secondTarget.GetComponent<XRSimpleInteractable>();
        if (interactable2 == null)
        {
            interactable2 = secondTarget.AddComponent<XRSimpleInteractable>();
        }
    }

    void Start()
    {
        //select random target, set position to that
        currentTargetIndex = UnityEngine.Random.Range(0, targets.Length);
        audioSourceGameObject.transform.position = targets[currentTargetIndex].transform.position;

        //get interactable of target
        interactable = targets[currentTargetIndex].GetComponent<XRSimpleInteractable>();
        if (interactable == null)
        {
            interactable = targets[currentTargetIndex].AddComponent<XRSimpleInteractable>();
        }

        StartCoroutine(playSound());
    }

    void Update()
    {
        if (interactable.isSelected)
        {
            StopCoroutine(playSound());
            audioSource.Stop();
            audioSource.PlayOneShot(winAudioClip);
            isFirstTargetSelected = true;
        }

        if (interactable2.isSelected && isFirstTargetSelected)
        {
            //you win, transition scene
        }
    }

    IEnumerator playSound()
    {
        while (true)
        {
            audioSource.PlayOneShot(audioSource.clip);
            yield return new WaitForSeconds(audioDelay);
        }
    }
}
