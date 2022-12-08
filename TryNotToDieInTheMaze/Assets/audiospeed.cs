using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audiospeed : MonoBehaviour
{
    [SerializeField] AudioMixer m_audioMixer;
    float pitch = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changePitch());
    }

    IEnumerator changePitch()
    {
        yield return new WaitForSecondsRealtime(20);
        pitch += 0.01f;
        m_audioMixer.SetFloat("Pitch", pitch);
        StartCoroutine(changePitch());
    }
}
