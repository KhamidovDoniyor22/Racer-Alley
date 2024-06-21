using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DailyRewards : MonoBehaviour
{
    [SerializeField] private Text _status;
    [SerializeField] private Button _claimButton;

    [Space(5)]
    [SerializeField] private RewardPrefab _rewardPrefab;
    [SerializeField] private Transform _rewardsGrid;

    [Space(5)]
    [SerializeField] private List<Reward> _rewards;


    private int CurrentDay
    {
        get => PlayerPrefs.GetInt("currentDay", 0);
        set => PlayerPrefs.SetInt("currentDay", value);
    }

    private DateTime? lastClaimTime
    {
        get
        {
            string data = PlayerPrefs.GetString("lastClaimedTime", null);

            if (!string.IsNullOrEmpty(data)) return DateTime.Parse(data);

            return null;
        }
        set
        {
            if(value != null)
            {
                PlayerPrefs.SetString("lastClaimedTime", value.ToString());
            }
            else
            {
                PlayerPrefs.DeleteKey("lastClaimedTime");
            }

        }
    }

    private bool canClaimReward;
    private int maxDayCount = 6;
    private float claimCoolDown = 24f;
    private float claimDeadline = 48f;

    private List<RewardPrefab> rewardPrefabs;

    private void Start()
    {
        InitPrefabs();
        StartCoroutine(RewardStateUpdator());
    }
    private void InitPrefabs()
    {
        rewardPrefabs = new List<RewardPrefab>();

        for(int i = 0; i < maxDayCount; i++)
        {
            rewardPrefabs.Add(Instantiate(_rewardPrefab, _rewardsGrid, false));
        }
    }
    private void UpdateRewardState()
    {
        canClaimReward = true;

        if(lastClaimTime.HasValue)
        {
            var timeSpan = DateTime.UtcNow - lastClaimTime.Value;

            if(timeSpan.TotalHours > claimDeadline)
            {
                lastClaimTime = null;
                CurrentDay = 0;
            }
            else if(timeSpan.TotalHours < claimCoolDown)
            {
                canClaimReward = false; 
            }
        }
        UpdateRewardUI();
    }
    private IEnumerator RewardStateUpdator()
    {
        while(true)
        {
            UpdateRewardState();
            yield return new WaitForSeconds(1f);
        }
    }
    private void UpdateRewardUI()
    {
        _claimButton.interactable = canClaimReward;

        if (canClaimReward) _status.text = "Claim your reward";
        else
        {
            var nextClaimTime = lastClaimTime.Value.AddHours(claimCoolDown);
            var currentClaimCoolDown = nextClaimTime - DateTime.UtcNow;

            string cd = $"{currentClaimCoolDown.Hours:D2} : {currentClaimCoolDown.Minutes:D2}:{currentClaimCoolDown.Seconds:D2}";

            _status.text = $"Come back in {cd} for";

        }
        for(int i = 0; i < rewardPrefabs.Count; i++)
        {
            rewardPrefabs[i].SetRewardData(i, CurrentDay, _rewards[i]);
        }
    }
    public void ClaimReward()
    {
        if (!canClaimReward) return;

        var reward = _rewards[CurrentDay];

        switch(reward.Type)
        {
            case Reward.RewardType.Coins:
                UIMenuManager.Instance.CoinPlus(reward.Value);
                break;
        }
        ClaimRewardPanel.Instance.Show(reward);

        lastClaimTime = DateTime.UtcNow;
        CurrentDay = (CurrentDay + 1) % maxDayCount;

        UpdateRewardState();
    }
}
