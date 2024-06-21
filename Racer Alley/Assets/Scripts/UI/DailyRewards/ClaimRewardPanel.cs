using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClaimRewardPanel : MonoBehaviour
{
    public static ClaimRewardPanel Instance;

    [SerializeField] private Text _rewardValue;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private GameObject _claimPanel;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Hide();
    }
    public void Show(Reward reward)
    {
        _rewardValue.text = "+ " + reward.Value.ToString();

        _claimPanel.SetActive(true);
        _canvasGroup.blocksRaycasts = true;
    }
    public void Hide()
    {
        _canvasGroup.blocksRaycasts = true;
        _claimPanel.SetActive(false);
    }
}
