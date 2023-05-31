using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI labelTxt;
    public TextMeshProUGUI stackSizeTxt;

    public void ClearSlot(){
        icon.enabled = false;
        labelTxt.enabled = false;
        stackSizeTxt.enabled = false;
    }

    public void DrawSlot(InvItem item){

        if (item == null){
            ClearSlot();
            return;
        }

        icon.enabled = true;
        labelTxt.enabled = true;
        stackSizeTxt.enabled = true;

        icon.sprite = item.itemData.icon;
        labelTxt.text = item.itemData.displayName;
        stackSizeTxt.text = item.stack_size.ToString();
    }
}
