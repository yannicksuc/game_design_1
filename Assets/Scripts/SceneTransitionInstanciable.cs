using System.Collections.Generic;
using System.Linq;

public class SceneTransitionInstanciable : IInstanciable<SceneTransitionInstanciable> {
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
