using UnityEngine;

public class SceneTransitionController : MonoBehaviour
{
    private string triggerName = "Start";
    [HideInInspector]
    public bool closeTransitionFinished;

    [SerializeField] private Animator[] animators = null;

    public void LaunchCloseTransition() {
        if (animators == null)
            GetComponent<Animator>().SetTrigger(triggerName);
        else
            foreach (var animator in animators)
                animator.SetTrigger(triggerName);
    }

    public void Transitionned() {
        ScenesManager.Instance.ValidateSceneLoading();
        closeTransitionFinished = true;
    }
}
