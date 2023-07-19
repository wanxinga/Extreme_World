﻿using Models;
using SkillBridge.Message;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuestInfo : MonoBehaviour {


	public Text title;

	public Text[] targets;

	public Text description;

	public Text overview;

	public UIIconItem rewardItems;

	public Text rewardMoney;
	public Text rewardExp;

	// Use this for initialization
	void Start () {
		
	}

	public void SetQuestInfo(Quest quest)
    {
		this.title.text = string.Format("[{0}]{1}", quest.Define.Type, quest.Define.Name);
		if (this.overview != null) this.overview.text = quest.Define.Overview;

        if (this.description != null)
        {
			if (quest.Info == null)
			{
				this.description.text = quest.Define.Dialog;
			}
			else
			{
				if (quest.Info.Status == QuestStatus.InProgress)
				{
					this.description.text = quest.Define.Dialog;
				}
				else if (quest.Info.Status == QuestStatus.Complated)
				{
					this.description.text = quest.Define.DialogFinish;
				}
				else
				{
					this.description.text = "任务已完成";
				}
			}
		}
        

		this.rewardMoney.text = quest.Define.RewardGold.ToString();
		this.rewardExp.text = quest.Define.RewardExp.ToString();

		foreach(var fitter in this.GetComponentsInChildren<ContentSizeFitter>())
        {
			fitter.SetLayoutVertical();
        }
    }


	public void OnClickAbandon()
    {

    }
	
	
}
