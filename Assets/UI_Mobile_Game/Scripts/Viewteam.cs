using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Viewteam : MonoBehaviour
{
    public static Viewteam instance;
    public GameObject spawnteamPos;
    public GameObject prefabTeam;
    public List<Teams> teamlist = new List<Teams>();
    public GameObject windows_team;
    public Animator anim;
    public Image flagteam;
    public Text Memberstext;
    public Text titletext;
    public Text slogantext;
    public Text pointstext;
    public Text typetext;
    public Text countrytext;

    //------------------------------------------------------------------------
    void Awake()
    {
        instance = this;
    }

    //Add all gameobjects for all team in scrollview team with all teams details
    //------------------------------------------------------------------------
    void Start()
    {
        int countTeam = teamlist.Count;
        for(int i = 0; i < countTeam; i++)
        {
            GameObject teamPrefab = Instantiate(prefabTeam);
            teamPrefab.transform.SetParent(spawnteamPos.transform);
            teamPrefab.transform.localScale = Vector3.one;
            teamPrefab.transform.localPosition = new Vector3(spawnteamPos.transform.position.x, spawnteamPos.transform.position.y, 0f);
            teamPrefab.GetComponent<InfosAndAddEventTeamClick>().Init(i);
            teamPrefab.GetComponent<InfosAndAddEventTeamClick>().NameTeam.text = teamlist[i].titleteam;
            teamPrefab.GetComponent<InfosAndAddEventTeamClick>().MembersTeam.text = teamlist[i].membersteam;
            teamPrefab.GetComponent<InfosAndAddEventTeamClick>().PointsTeam.text = teamlist[i].pointsteam;
            teamPrefab.GetComponent<InfosAndAddEventTeamClick>().FlagTeam.sprite = teamlist[i].flagteam;
        }
    }

    //After click, open new window with all team detail
    //------------------------------------------------------------------------
    public void OpenTeamWindows(int idproduct)
    {
        windows_team.SetActive(true);
        flagteam.sprite = teamlist[idproduct].flagteam;
        flagteam.preserveAspect = true;
        Memberstext.text = teamlist[idproduct].membersteam;
        titletext.text = teamlist[idproduct].titleteam;
        pointstext.text = teamlist[idproduct].pointsteam;
        slogantext.text = teamlist[idproduct].sloganteam;
        typetext.text = teamlist[idproduct].typeteam == "close" ? "<color=#ff0000ff>CLOSED</color>" : "<color=#00ff00ff>OPEN</color>";
        countrytext.text = teamlist[idproduct].countryteam;
    }

    //After click, close window team detail
    //------------------------------------------------------------------------
    public void CloseTeamWindows()
    {
        GlobalAudio.instance.PlayCloseWindow();
        windows_team.SetActive(false);
    }
}

//------------------------------------------------------------------------
[System.Serializable]
public class Teams {
    public int id;
    public string titleteam;
    public string sloganteam;
    public Sprite flagteam;
    public string membersteam;
    public string pointsteam;
    public string typeteam;
    public string countryteam;
}