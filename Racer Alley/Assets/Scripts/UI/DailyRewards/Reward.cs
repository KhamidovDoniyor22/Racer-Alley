[System.Serializable]
public class Reward
{
    public enum RewardType
    {
        Coins,
    }
    public RewardType Type;
    public int Value;
    public string Name;
    
}
