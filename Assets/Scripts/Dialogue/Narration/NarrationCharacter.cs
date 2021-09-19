using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Character")]
public class NarrationCharacter : ScriptableObject
{
    [SerializeField] private string m_CharacterName;
    [SerializeField] private Texture icon;


    public string CharacterName => m_CharacterName;
    public Texture Icon => icon;
}