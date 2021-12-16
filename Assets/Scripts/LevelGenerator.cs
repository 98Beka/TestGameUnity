using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator
{
    #region Fields and constractor
    private List<int> indexesOfExistingCards;
    private GameObject parentUI;
    private CardCreator cardCreator;
    private TaskCreator taskCreator;
    
    public LevelGenerator(List<int> indexesOfCreatedCards, CardCreator cardCreator,
     GameObject parentUI, TaskCreator taskCreator)
    {
        this.indexesOfExistingCards = indexesOfCreatedCards;
        this.parentUI = parentUI;
        this.taskCreator = taskCreator;
        this.cardCreator = cardCreator;
    }
    #endregion

    
    public void LevelGenerat(int level, CardData[] cardData)
    {
        for(int i = 0; i < level * 3; i++)
        {
            int randomIndex = -1;
            while(randomIndex == -1)
                randomIndex = random_next(cardData.Length);
            indexesOfExistingCards.Add(randomIndex);
            cardCreator.CreatCard(cardData[randomIndex], parentUI);
        }
        taskCreator.CreateTask();
    }

    //Get random index in indexesOfExistingCards without repeating
    private int random_next(int length)
    {
        int newIndex = Random.Range(0, length);

        foreach(int ind in indexesOfExistingCards)
        {
            if (ind == newIndex)
                return -1;
        }
        return newIndex;
    }
}
