using System.Collections.Generic;
using System.Linq;

public class SceneTransitionManager : IInstanciable<SceneTransitionManager> {
    private List<SceneTransitionController> _controllers;

    void Start()
    {
        _controllers = FindObjectsOfType<SceneTransitionController>().ToList();
    }
    public void LaunchCloseTransition()
    {
        _controllers.ForEach(it => it.LaunchCloseTransition());
    }

    public bool HasTransitions()
    {
        return _controllers != null && _controllers.Count > 0;
    }
}
