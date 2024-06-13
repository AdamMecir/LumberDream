using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WoodIndicatorLogic : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Vector2 endLocation;
    [SerializeField] private float timeOfTravel = 2f;
    [SerializeField] private float currentTime = 0;
    [SerializeField] private float normalizedValue;
    [SerializeField] private Vector2 currentLocation;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] Image image;


    private void Start()
    {
        endLocation = new Vector2(30f, -290f);
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    public void SetImage(WoodType type)
    {
        switch (type)
        {
            case WoodType.Oak:
                image.sprite = sprites[0];
                break;
            case WoodType.Birch:
                image.sprite = sprites[1];
                break;
            case WoodType.Pine:
                image.sprite = sprites[2];
                break;
            case WoodType.Sakura:
                image.sprite = sprites[3];
                break;
        }
    }

    public void OnStart()
    {
        StartCoroutine(Animate());
    }

    private void Update()
    {
        currentLocation = rectTransform.anchoredPosition;

        if (currentLocation.normalized == endLocation.normalized)
            Destroy(gameObject);
    }

    public IEnumerator Animate()
    {
        rectTransform.localScale = Vector3.zero;
        yield return new WaitForSeconds(0.015f);
        rectTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        yield return new WaitForSeconds(0.015f);
        rectTransform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        yield return new WaitForSeconds(0.015f);
        rectTransform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        yield return new WaitForSeconds(0.015f);
        rectTransform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        yield return new WaitForSeconds(0.015f);
        rectTransform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds(0.015f);
        rectTransform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        yield return new WaitForSeconds(0.015f);
        rectTransform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        yield return new WaitForSeconds(0.015f);
        rectTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        yield return new WaitForSeconds(0.015f);
        rectTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        yield return new WaitForSeconds(0.015f);
        rectTransform.localScale = new Vector3(1f, 1f, 1f);
        yield return new WaitForSeconds(0.015f);
        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel; // we normalize our time 

            rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, endLocation, normalizedValue);
            yield return null;
        }
    }
}

