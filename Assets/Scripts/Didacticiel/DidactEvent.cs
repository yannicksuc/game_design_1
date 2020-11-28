using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DidactEvent : MonoBehaviour
{
    [SerializeField] DidacticielManager m_didac;
    [SerializeField] List<string> m_didacText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_didac.NewScenario(m_didacText);
        this.gameObject.SetActive(false);
    }
}
