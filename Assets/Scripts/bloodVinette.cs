using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bloodVinette : MonoBehaviour
{
    [Header("Can Edit")] 
    [SerializeField] Vector2 shadeRange;//Min, Max
    [SerializeField] float lerpModifier;
    [SerializeField] float minPercent;
    [SerializeField] float minRegenRate;
    [Header("Read Only")]
    [SerializeField] float currentlyShaded;
    [SerializeField] float percentShaded;
    [SerializeField] float currentPercent;
    [SerializeField] float prevPercent;
    Image image;

    GameManager gm;
    float prevHealth;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        prevHealth = gm.health;
    }

    // Update is called once per frame
    void Update()
    {

        currentPercent = gm.health / gm.maxHealth;
        prevPercent = prevHealth / gm.maxHealth;
            if (0.01 < prevPercent - currentPercent)
            {
                 image.material.SetColor("_Color", Color.red);
                 percentShaded = prevPercent - currentPercent + minPercent;
            }
            else
            {
                 
                 if (0.2 > currentPercent)
                 {
                     percentShaded =  0.02f*Mathf.Sin(Time.time*3f) + minPercent;
                 }
                 else if (minRegenRate < currentPercent - prevPercent)
                 {
                     percentShaded = minPercent;
                     image.material.SetColor("_Color", Color.green);
                 }
                 else
                    percentShaded = Mathf.Lerp(percentShaded, 0, 0.01f);

            }

            // percentShaded = (currentlyShaded-shadeRange.x )/ (shadeRange.y - shadeRange.x);

        percentShaded = Mathf.Clamp(percentShaded, -1, 1);
        currentlyShaded = ((1 - percentShaded) * (shadeRange.y - shadeRange.x)) + shadeRange.x;
        currentlyShaded = Mathf.Clamp(currentlyShaded, shadeRange.x, shadeRange.y);
        image.material.SetFloat("_AmntShaded", currentlyShaded);

        prevHealth = Mathf.Lerp(prevHealth, gm.health, /*currentPercent **/lerpModifier) ;
        
    }

    
}
