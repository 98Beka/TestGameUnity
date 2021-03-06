using UnityEngine;

[CreateAssetMenu]
public class CardData : ScriptableObject
{
    [SerializeField]
    private string _identifier;

    [SerializeField]
    private Sprite _sprite;

    public string Identifier => _identifier;

    public Sprite Sprite => _sprite;
}
