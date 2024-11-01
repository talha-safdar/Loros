using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager instance;
    public enum TypeMoney { Coin, Star, Energy, Dollar, Treasure };
    public int PageCount;
    public int coin;
    public int star;
    public int energy;
    public Text coinText;
    public Text starText;
    public Text energyText;
    public GameObject WindowsShop;
    public GameObject WindowsPop;

    public TypeMoney typeMoneyForBuy;
    public int AmountMoneyForBuy;
    public TypeMoney typeMoneyBuy;
    public int AmountMoneyBuy;

    //Apply all variable money's and TEXT components
    //------------------------------------------------------------------------
    void Awake()
    {
        instance = this;
        coin = 10000;
        star = 10000;
        energy = 10000;

        coinText.text = coin.ToString("0");
        starText.text = star.ToString("0");
        energyText.text = energy.ToString("0");
    }

    //Add pop money animation after purchase if you have minimum money required
    //------------------------------------------------------------------------
    public void PopMoney()
    {
        if (typeMoneyBuy != TypeMoney.Treasure)
        {
            if (typeMoneyForBuy != TypeMoney.Dollar)
            {
                if (typeMoneyForBuy == TypeMoney.Coin)
                {
                    if (coin >= AmountMoneyForBuy)
                    {
                        WindowsShop.SetActive(false);
                        WindowsPop.SetActive(true);
                        GlobalAudio.instance.PlayPurchase();
                        PopCoins.inst.AddCoins(AmountMoneyBuy);
                    }
                }
                else if (typeMoneyForBuy == TypeMoney.Star)
                {
                    if (star >= AmountMoneyForBuy)
                    {
                        WindowsShop.SetActive(false);
                        WindowsPop.SetActive(true);
                        GlobalAudio.instance.PlayPurchase();
                        PopCoins.inst.AddCoins(AmountMoneyBuy);
                    }
                }
                else if (typeMoneyForBuy == TypeMoney.Energy)
                {
                    if (energy >= AmountMoneyForBuy)
                    {
                        WindowsShop.SetActive(false);
                        WindowsPop.SetActive(true);
                        GlobalAudio.instance.PlayPurchase();
                        PopCoins.inst.AddCoins(AmountMoneyBuy);
                    }
                }
            }
        }
    }

    //Add money's in variable and TEXT components
    //------------------------------------------------------------------------
    public void AddMoney()
    {
        if (typeMoneyForBuy == TypeMoney.Coin)
        {
            coin -= AmountMoneyForBuy;
            coinText.text = coin.ToString("0");

            if (typeMoneyBuy == TypeMoney.Star)
            {
                star += AmountMoneyBuy;
                starText.text = star.ToString("0");
            }
            else if (typeMoneyBuy == TypeMoney.Energy)
            {
                energy += AmountMoneyBuy;
                energyText.text = energy.ToString("0");
            }

        }
        else if (typeMoneyForBuy == TypeMoney.Star)
        {

            star -= AmountMoneyForBuy;
            starText.text = star.ToString("0");

            if (typeMoneyBuy == TypeMoney.Coin)
            {
                coin += AmountMoneyBuy;
                coinText.text = coin.ToString("0");
            }
            else if (typeMoneyBuy == TypeMoney.Energy)
            {
                energy += AmountMoneyBuy;
                energyText.text = energy.ToString("0");
            }

        }
        else if (typeMoneyForBuy == TypeMoney.Energy)
        {

            energy -= AmountMoneyForBuy;
            energyText.text = energy.ToString("0");

            if (typeMoneyBuy == TypeMoney.Coin)
            {
                coin += AmountMoneyBuy;
                coinText.text = coin.ToString("0");
            }
            else if (typeMoneyBuy == TypeMoney.Star)
            {
                star += AmountMoneyBuy;
                starText.text = star.ToString("0");
            }
        }
    }
}
