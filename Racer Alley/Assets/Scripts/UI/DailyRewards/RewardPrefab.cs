using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardPrefab : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _currentColor;

    [Space(5)]
    [SerializeField] private Text _dayText;
    [SerializeField] private Text _rewardValue;

    public void SetRewardData(int day, int currentStreak, Reward reward)
    {
        _dayText.text = $"Day {day + 1}";
        _rewardValue.text = reward.Value.ToString();

        _background.color = day == currentStreak ? _currentColor : _defaultColor;
    }
}
