﻿using Location.WCFServiceReferences.LocationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonneiAlarmInfo : MonoBehaviour
{

    public Text PerNum;
    public Text PerName;
    public Text perJob;
    public Text Type;
    public Text Content;
    public Text StartTime;
    public Text EndTime;
    public Button But;
    private string PerID;
    void Start()
    {

    }
    public void SetEachItemInfo(LocationAlarm info)
    {

        PerNum.text = info.Personnel.WorkNumber.ToString();
        PerName.text = info.Personnel.Name.ToString();
        perJob.text = info.Personnel.Pst.ToString();
        Content.text = info.Content.ToString();
        Type.text = info.AlarmType.ToString();
        string startTime1 = info.CreateTime.ToString();
        if (startTime1 == "1/1/0001 12:00:00 AM")
        {
            StartTime.text = "";
        }
        else
        {
            DateTime NewTime = Convert.ToDateTime(startTime1);
            StartTime.text = NewTime.ToString("yyyy年MM月dd日 HH:mm:ss");
        }

        string endTime1 = info.HandleTime.ToString();

        if (endTime1 == "1/1/2000 12:00:00 AM")
        {
            EndTime.text = "<color=#C66BABFF>未消除</color>"; ;
        }
        else
        {
            DateTime NewTime = Convert.ToDateTime(endTime1);
            EndTime.text = "<color=#FFFFFFFF>已消除</color>" + " " + NewTime.ToString("yyyy年MM月dd日 HH:mm:ss");
        }
        PerID = info.TagId.ToString();
        But.onClick.AddListener(() =>
       {
           PersonPosition(PerID);
       });

    }
    public void PersonPosition(string PerID)
    {
        int perId = int.Parse(PerID);
        LocationManager.Instance.FocusPersonAndShowInfo(perId);
        PersonnelAlarmParkInfo.Instance.ShowPersonnelAlarmParkWindow(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
