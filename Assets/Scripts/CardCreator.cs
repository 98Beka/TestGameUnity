using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardCreator : MonoBehaviour
{
    private char[] task;
    private TaskCreator taskCreator;
    private GameObject starsEffect;
    public CardCreator(char[] task, TaskCreator taskCreator, GameObject starsEffect)
    {
        this.task = task;
        this.taskCreator = taskCreator;
        this.starsEffect = starsEffect;
    }

    public void CreatCard(CardData cardData, GameObject parentUI)
    {
        var card = new GameObject();
        card.AddComponent<RectTransform>();
        var ansverChecker = card.AddComponent<AnsverChecker>();
        card.name = cardData.Identifier;
        var image = card.AddComponent<Image>();
        image.sprite = cardData.Sprite;
        var btn = card.AddComponent<Button>();
        btn.onClick.AddListener(ansverChecker.AnsverCheckButton);
        ansverChecker.SetTask(task);
        ansverChecker.SetTaskCreator(taskCreator);
        ansverChecker.SetParticleSystem(starsEffect);
        card.transform.SetParent(parentUI.transform);
        card.transform.DORewind ();
        card.transform.DOPunchScale (new Vector3 (1, 1, 1), .15f);

    }
    
}
