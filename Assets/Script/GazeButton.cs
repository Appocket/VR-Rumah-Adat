using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class GazeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image loadingImage;
    public AudioSource audio;
    public float loadingTime = 1.5f;
    private float elapsedTime;

    bool loadingClick;
    public UnityEvent onClick, onEnter, onExit;

    public bool interactable = true;
    private void Start()
    {
        if (loadingImage==null)
        {
            loadingImage = GameObject.FindGameObjectWithTag("LoadingClick").GetComponent<Image>();
            loadingImage.enabled = false;
            audio = loadingImage.GetComponent<AudioSource>();
        }
        elapsedTime = 0;
        loadingClick = false;
    }
    private void OnMouseEnter()
    {
        pointerEnter();
    }

    private void OnMouseExit()
    {
        pointerExit();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointerExit();
    }

    void pointerEnter()
    {
        if (interactable)
        {
            loadingClick = true;
            elapsedTime = 0;
            loadingImage.enabled = true;
            audio.Play();
            onEnter.Invoke();
        }
    }
    void pointerExit()
    {
        if (interactable)
        {
            loadingClick = false;
            elapsedTime = 0;
            loadingImage.enabled = false;
            audio.Stop();
            onExit.Invoke();
        }
    }
    private void Update()
    {
        if (loadingClick && interactable)
        {
            if (elapsedTime>loadingTime)
            {
                loadingClick = false;
                loadingImage.enabled = false;
                audio.Stop();
                onClick.Invoke();
            }
            elapsedTime += Time.deltaTime;
            loadingImage.fillAmount = elapsedTime / loadingTime;
        }
    }

    Image GetLoadingImage()
    {
        return GameObject.FindGameObjectWithTag("LoadingClick").GetComponent<Image>();
    }
}
