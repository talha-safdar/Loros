using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfosAndAddEventShopClick : MonoBehaviour
{
    public Text title;
    public Button[] ButtonOnclick;
    public Text[] NameShop;
    public Text[] AmountShop;
    public Text[] MoneyShop;
    public Image[] FlagMoney;
    public Image[] Imgproduct;
    int idList;

    // "Init()" Apply to the prefabs the ID list in "Shop.cs" and create all buttons and the events listener for click
    //------------------------------------------------------------------------
    public void Init(int listid)
    {
        idList = listid;
        for (int i = 0; i < ButtonOnclick.Length; i++)
        {
            int x = i;//"x" is id button (0, 1, 2...)
            ButtonOnclick[i].onClick.AddListener(() => TaskOnClick(x));
        }
    }

    //Event after clicked button white id button and list id
    //------------------------------------------------------------------------
    void TaskOnClick(int buttonId)
    {
        GlobalAudio.instance.PlayOpenWindow();
        Shop.instance.OpenBuyWindows(idList, buttonId);
    }
}
