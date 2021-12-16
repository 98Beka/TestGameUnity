using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelLoader
{
    private CardBundleData cardBundleData;
    private LevelGenerator levelGenerator;
    private List<int> indexesOfCreatedCards;
    private int level = 0;
    private int maxLevel = 3;
    private GameObject restartPanel;


    public LevelLoader(CardBundleData cardBundleData, LevelGenerator levelGenerator,
     List<int> indexesOfCreatedCards, GameObject restartPanel)
    {
        this.cardBundleData = cardBundleData;
        this.levelGenerator = levelGenerator;
        this.indexesOfCreatedCards = indexesOfCreatedCards;
        this.restartPanel = restartPanel;
    }

    public void RestartGame()
    {
        restartPanel.SetActive(false);
        level = 0;
        LoadLevel();
    }

    public void LoadLevel()
    {
        if (level < 1)
            level = 1;
        if (level > maxLevel)
        {
            restartPanel.SetActive(true);
            restartPanel.GetComponent<Image>().DOFade(0.7f,2f);
            return;
        }
        else
            levelGenerator.LevelGenerat(level, cardBundleData.CardData);
        level++;
    }

}
