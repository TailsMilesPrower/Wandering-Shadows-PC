using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public EndOfLevelManager endOfLevelManager;
    [SerializeField] private AudioClip finishClip;
    [SerializeField] private AudioMixerGroup audioMixer;

    AudioSource burningSoundSource;
    public GameObject hitBox;
    public GameObject pointers;

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            SoundEffectManager.instance.PlaySoundFXClip(finishClip, transform, 1f);
            //Debug.Log("Finish!");
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            endOfLevelManager.Finish();
            hitBox.SetActive(false);
            pointers.SetActive(false);
            //burningSoundSource = GetComponent<AudioSource>();

        }
    }

    public void RetryLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    /*public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }*/
}
