using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour
{

    public Transform vrCamera;
    public float toggleAngle = 30.0f;
    public float speed = 3.0f;
    public bool moveForward;
    public AudioSource audio;
    private CharacterController cc;
    bool isPlayingSound;
    public float delay = 1;
    public List<AudioClip> clip;
    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
        isPlayingSound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveForward = true;
        }
        else
        {
            moveForward = false;
        }

        if (moveForward )
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);

            cc.SimpleMove(forward * speed);
            if (!isPlayingSound)
            {
                StartCoroutine(delaySound());
            }
        }
        else
        {
            if (isPlayingSound)
            {
                audio.Stop();
                isPlayingSound = false;
            }
        }
    }
    IEnumerator delaySound()
    {
        audio.clip = clip[Random.Range(0, clip.Count)];
        audio.Play();
        isPlayingSound = true;
        yield return new WaitForSeconds(delay);
        audio.Stop();
        isPlayingSound = false;
    }
}
