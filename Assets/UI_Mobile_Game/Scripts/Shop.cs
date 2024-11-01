using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    public ScrollRectEx scrollRect;
    public GameObject spawnOfferPos;
    public GameObject prefabShop;
    public int idoffer; // choose your element number in "offerToDay" list, for spawn specific "offer to day" line 48
    public List<Offer_to_day> offerToDay = new List<Offer_to_day>();
    public List<List_Shop> list = new List<List_Shop>();
    public GameObject windows_buy;
    public Animator anim;
    public Image productimg;
    public Image moneyimg;
    public Text pricetext;
    public Text titletext;
    public Text amounttext;

    int o = 0;
    int p = 0;
    GameObject prefab;

    //Instance this component
    //------------------------------------------------------------------------
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    //------------------------------------------------------------------------
    void Start()
    {
        //Change size to "Content" in scrollview
        RectTransform rt = spawnOfferPos.GetComponent<RectTransform>();
        int countOffertoday = offerToDay.Count;

        //Instantiate to "OFFER TO DAY" the offer id "0". Variable "idoffer".
        if (countOffertoday > 0)
        {
            for (int i = 0; i < countOffertoday; i++)
            {
                GameObject offerday = Instantiate(offerToDay[idoffer].offerObj);
                offerday.transform.SetParent(spawnOfferPos.transform);
                offerday.transform.localScale = Vector3.one;
                offerday.transform.localPosition = new Vector3(spawnOfferPos.transform.position.x, spawnOfferPos.transform.position.y, 0f);
            }
        }

        //Boucle for add all packs in scroll view shop
        for (int j = 0; j < list.Count; j++)
        {
            if (o == 0)
            {
                prefab = Instantiate(prefabShop);
                prefab.transform.SetParent(spawnOfferPos.transform);
                prefab.transform.localScale = Vector3.one;
                prefab.transform.localPosition = new Vector3(spawnOfferPos.transform.position.x, spawnOfferPos.transform.position.y, 0f);
                prefab.GetComponent<InfosAndAddEventShopClick>().title.text = list[j].name;
                prefab.GetComponent<InfosAndAddEventShopClick>().Init(j);
            }

            for(int p = 0; p < list[j].productslist.Count; p++)
            {
                prefab.GetComponent<InfosAndAddEventShopClick>().NameShop[p].text = list[j].productslist[p].name;
                prefab.GetComponent<InfosAndAddEventShopClick>().MoneyShop[p].text = list[j].productslist[p].price;
                prefab.GetComponent<InfosAndAddEventShopClick>().AmountShop[p].text = list[j].productslist[p].showAmount == true ? "<size=18><color=#ffffffff>x</color></size>" + list[j].productslist[p].amount : "";
                prefab.GetComponent<InfosAndAddEventShopClick>().FlagMoney[p].sprite = list[j].productslist[p].imgCurrency;
                prefab.GetComponent<InfosAndAddEventShopClick>().Imgproduct[p].sprite = list[j].productslist[p].imgProduct;
            }
        }

        Canvas.ForceUpdateCanvases();
        scrollRect.content.GetComponent<ContentSizeFitter>().SetLayoutVertical();
    }

    //Open the new window with multiple détails after clicked of pack in game
    //------------------------------------------------------------------------
    public void OpenBuyWindows(int idList, int idproduct)
    {
        windows_buy.SetActive(true);
        productimg.sprite = list[idList].productslist[idproduct].imgProduct;
        productimg.preserveAspect = true;
        moneyimg.sprite = list[idList].productslist[idproduct].imgCurrency;
        moneyimg.preserveAspect = true;
        pricetext.text = list[idList].productslist[idproduct].price;
        titletext.text = list[idList].productslist[idproduct].name;
        amounttext.text = list[idList].productslist[idproduct].showAmount == true ? "<size=25><color=#ffffffff>x</color></size>" + list[idList].productslist[idproduct].amount : "";
        GlobalManager.instance.AmountMoneyForBuy = list[idList].productslist[idproduct].TypeCurrencyOfPurchase == GlobalManager.TypeMoney.Dollar ? 0 : int.Parse(list[idList].productslist[idproduct].price);
        GlobalManager.instance.AmountMoneyBuy = int.Parse(list[idList].productslist[idproduct].amount);
        GlobalManager.instance.typeMoneyForBuy = list[idList].productslist[idproduct].TypeCurrencyOfPurchase;
        GlobalManager.instance.typeMoneyBuy = list[idList].productslist[idproduct].PurchaseCurrency;
    }

    //Close window with multiples details of pack shop
    //------------------------------------------------------------------------
    public void CloseBuyWindows()
    {
        GlobalAudio.instance.PlayCloseWindow();
        windows_buy.SetActive(false);
    }
}

//------------------------------------------------------------------------
[System.Serializable]
public class List_Shop
{
    public string name;
    public List<Products_List> productslist = new List<Products_List>();
}

[System.Serializable]
public class Products_List
{
    public string name;
    public string price;
    public GlobalManager.TypeMoney TypeCurrencyOfPurchase;
    public Sprite imgCurrency;
    public string amount;
    public GlobalManager.TypeMoney PurchaseCurrency;
    public bool showAmount = false;
    public Sprite imgProduct;
}

[System.Serializable]
public class Offer_to_day
{
    public int id;
    public GameObject offerObj;
}
