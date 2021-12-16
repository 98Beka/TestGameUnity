using UnityEngine;

[CreateAssetMenu(fileName = "CardBundleData", menuName = "")]
public class CardBundleData : ScriptableObject
{
    [SerializeField]
    private CardData[] _cardData;

    public CardData[] CardData => _cardData;
}
