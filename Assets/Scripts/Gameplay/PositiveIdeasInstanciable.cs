using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class PositiveIdeasManager : IInstanciable<PositiveIdeasManager>
    {
        [SerializeField] private List<PositiveIdeaData> ideas;

        public PositiveIdeaData GetRandomIdea()
        {
            return ideas.Count <= 0 ? null : ideas[Random.Range(0, ideas.Count)];
        }
    }
}