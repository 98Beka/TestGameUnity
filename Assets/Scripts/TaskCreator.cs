using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TaskCreator
{
    List<int> indexesOfCreatedCards;
    private CardData[] cardDatas;
    private Text taskTextUI;
    private char[] task;
    private LevelLoader levelLoader;

    public void SetLevelLoader(LevelLoader levelLoader)
    {
        this.levelLoader = levelLoader;
    }
    

    public TaskCreator(List<int> indexesOfCreatedCards, CardData[] cardDatas,
     Text taskTextUI, char[] task)
    {
        this.indexesOfCreatedCards = indexesOfCreatedCards;
        this.cardDatas = cardDatas;
        this.taskTextUI = taskTextUI;
        this.task = task;
    }

    public void CreateTask()
    {
        taskTextUI.DOFade(0, 0);
        if(indexesOfCreatedCards.Count == 0)
        {
            levelLoader.LoadLevel();
            return;
        }
        int random = Random.Range(0, indexesOfCreatedCards.Count);
        string cardIdentifier = cardDatas[indexesOfCreatedCards[random]].Identifier;
        taskTextUI.text = "Find " + cardIdentifier;
        task[0] = cardIdentifier.ToCharArray()[0];
        indexesOfCreatedCards.RemoveAt(random);
        taskTextUI.DOFade(0.5f, 1);
    }
}
