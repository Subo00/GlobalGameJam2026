using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryBlock : MonoBehaviour
{
    private Image image;
    private Color equippedColor;
    private Color unequippedColor;
    void Awake()
    {
        //gameObject.SetActive(false);
        
        image = GetComponent<Image>();
        
        equippedColor = image.color;
        unequippedColor = image.color;
        unequippedColor.a = 0.5f;

        Equipped(false);
    }

    
    public void Equipped(bool isEquipped)
    {
        image.color = isEquipped ? equippedColor : unequippedColor;
    }
}
