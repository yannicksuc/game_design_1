using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Time;

public class StressSystem : MonoBehaviour
{
    [SerializeField] private PlayerConstitution constitution;
    [Tooltip("Time in second to reach the stress limit")]
    [SerializeField] private float stressCooldown;
    public UnityEvent onPlayerStressedOut;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        constitution.stressLevel += deltaTime * PlayerConstitution.StressLimit / stressCooldown;
        if (constitution.stressLevel > PlayerConstitution.StressLimit) {
            constitution.stressLevel = PlayerConstitution.StressLimit;
            onPlayerStressedOut?.Invoke();
            constitution.stressLevel = 0;
        }
    }
}
