using UnityEngine;
using DG.Tweening;

public class AnsverChecker : MonoBehaviour
{
    private char[] task;
    private TaskCreator taskCreator;
    private GameObject starsEffect;
    private ParticleSystem particls;
    private float effectDuration = 0.3f;
    private Vector3 shakeStrength = new Vector3(15f, 0, 0);
    private int shakeVibrato = 3;
    private float shakeRandomness = 0;
    private float bounceDuration = 0.15f;
    private Vector3 bouceChangeSize = new Vector3 (1, 1, 1);

    public void SetParticleSystem(GameObject starsEffect)
    {
        this.starsEffect = starsEffect;
        particls = starsEffect.GetComponent<ParticleSystem>();
    }

    public void SetTask(char[] task)
    {
        this.task = task;
    }

    public void SetTaskCreator(TaskCreator taskCreator)
    {
        this.taskCreator = taskCreator;
    }

    public void AnsverCheckButton()
    {
        if (task[0] != name.ToCharArray()[0])
        {
            transform.DOShakePosition( effectDuration, shakeStrength, shakeVibrato, shakeRandomness);
        }
        else
        {
            starsEffect.transform.position = this.gameObject.transform.position;
            particls.Play();
            transform.DOPunchScale (bouceChangeSize, bounceDuration);
            Destroy(this.gameObject, 0.1f);
            taskCreator.CreateTask();
        }
    }
}
