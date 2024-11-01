using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopCoins : MonoBehaviour
{
	public static PopCoins inst;
	public GameObject Money;
	public GameObject AmountText;
	public GameObject Gems;
	public RectTransform finalPosMoney;
	public RectTransform finalPosGems;
	public List<GameObject> Currentmoney = new List<GameObject>();
	public List<GameObject> Currentgems = new List<GameObject>();
	public int maxMoney;
	public int maxGems;

    bool currentAddmoneys;
	bool currentAddgems;
    int ListCountMoney;
	int ListCountGems;

    RectTransform rt;

    void Awake()
	{
		inst = this;
        rt = this.GetComponent<RectTransform>();
    }

	public void AddCoins(int countmoney)
	{
		if (!currentAddmoneys)
		{

            currentAddmoneys = true;
			if (countmoney > 15)
			{
                countmoney = 15;
			}
			maxMoney = countmoney;
			ListCountMoney = maxMoney - 1;
			for (int i = 0; i < maxMoney; i++)
			{
                GameObject moneyObj = Instantiate(Money);
                moneyObj.transform.SetParent(this.transform);
                moneyObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                moneyObj.GetComponent<RectTransform>().localPosition = new Vector3(rt.localPosition.x, rt.localPosition.y, 0);
                Currentmoney.Add(moneyObj as GameObject);
				Currentmoney[i].GetComponent<moveCoins>().pop = this;
				Currentmoney[i].GetComponent<moveCoins>().id = i;
			}
			StartCoroutine("sendFinalmon");
            GameObject textAmount = Instantiate(AmountText);
            textAmount.transform.SetParent(this.transform);
            textAmount.transform.localScale = new Vector3(1f, 1f, 1f);
            textAmount.GetComponent<RectTransform>().localPosition = new Vector3(rt.localPosition.x, rt.localPosition.y, -200f);
            textAmount.GetComponent<Text>().text = "+" + GlobalManager.instance.AmountMoneyBuy.ToString("0");
        }
	}

	public void AddGems(int countgems)
	{
		if (!currentAddgems)
		{
			currentAddgems = true;
			if (countgems > 8)
			{
				countgems = 8;
			}
			maxGems = countgems;
			ListCountGems = maxGems - 1;
			for (int i = 0; i < maxGems; i++)
			{
				Currentgems.Add(Instantiate(Gems, rt.position, Quaternion.identity) as GameObject);
				Currentgems[i].GetComponent<moveCoins>().pop = this;
				Currentgems[i].GetComponent<moveCoins>().id = i;
			}
			StartCoroutine("sendFinalgem");
		}	}




	IEnumerator sendFinalmon()
	{
		yield return new WaitForSeconds(1f);
        StopCoroutine("sendFinalmon");
		StartCoroutine("sendFinalMoney");
	}

	IEnumerator sendFinalgem()
	{
		yield return new WaitForSeconds(0.5f);
		StopCoroutine("sendFinalgem");
		StartCoroutine("sendFinalGems");	}







	IEnumerator sendFinalMoney()
	{
		yield return new WaitForSeconds(0.05f);
		if (ListCountMoney >= 0)
		{
			Currentmoney[ListCountMoney].GetComponent<moveCoins>().GoFinal();
			Currentmoney.RemoveAt(ListCountMoney);
			ListCountMoney--;
			StartCoroutine("sendFinalMoney");
		}
		else
		{
			currentAddmoneys = false;
            StopCoroutine("sendFinalMoney");
		}
	}

	IEnumerator sendFinalGems()
	{
		yield return new WaitForSeconds(0.05f);
		if (ListCountGems >= 0)
		{
			Currentgems[ListCountGems].GetComponent<moveCoins>().GoFinal();
			Currentgems.RemoveAt(ListCountGems);
			ListCountGems--;
			StartCoroutine("sendFinalGems");
		}
		else
		{
			currentAddgems = false;
			StopCoroutine("sendFinalGems");
		}	}
}
