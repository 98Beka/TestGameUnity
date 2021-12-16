using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initializer : MonoBehaviour
{
    [SerializeField] private CardBundleData cardBundleData;
    [SerializeField] private GameObject parentUI;
    [SerializeField] private GameObject starsEffect;
    [SerializeField] private Text taskTextUI;
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private GameObject restartButton;
    private List<int> indexesOfCreatedCards = new List<int>();
    private char[] task;

    private void Start()
    {
        task = new char[2];
        task[1] = '\0';
        var taskCreator = new TaskCreator(indexesOfCreatedCards, cardBundleData.CardData, taskTextUI, task);
        var cardCreator = new CardCreator(task, taskCreator, starsEffect);
        var levelGenerator = new LevelGenerator(indexesOfCreatedCards, cardCreator, parentUI, taskCreator);
        var levelLoader = new LevelLoader(cardBundleData, levelGenerator, indexesOfCreatedCards, restartPanel);
        taskCreator.SetLevelLoader(levelLoader);
        levelLoader.LoadLevel();
        restartButton.GetComponent<Button>().onClick.AddListener(levelLoader.RestartGame);
    }
}
