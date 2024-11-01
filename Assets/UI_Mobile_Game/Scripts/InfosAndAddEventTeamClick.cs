using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfosAndAddEventTeamClick : MonoBehaviour
{
    public Button onclick;
    public Text NameTeam;
    public Text MembersTeam;
    public Text PointsTeam;
    public Image FlagTeam;
    int idTeam;

    // Init id team and add listener button for click
    //------------------------------------------------------------------------
    public void Init(int idteam)
    {
        idTeam = idteam;
        onclick = this.GetComponent<Button>();
        onclick.onClick.AddListener(TaskOnClick);//LAUNCHED AFTER CLICK ON TEAM, HERE LINE 25
    }

    //------------------------------------------------------------------------
    void TaskOnClick()
    {
        GlobalAudio.instance.PlayOpenWindow();
        Viewteam.instance.OpenTeamWindows(idTeam);
    }
}
