using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DidacticielManager : MonoBehaviour
{
    public List<string> scenarioText;
    public int index;
    public TextMeshProUGUI m_textMeshPro;
    public PlayerControllerDidact player;
    public GameObject stressSystem;

    public enum TypeDialog
    {
        Simple,
        EventWaiting
    }
    public TypeDialog m_type;
    public int Step;


    // Start is called before the first frame update
    void Start()
    {
        Step = 0;
        ScenarioNext();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            ScenarioNext();
        }
    }

    public void ScenarioNext()
    {
        if (index < scenarioText.Count)
        {
            player.canMove = false;
            m_textMeshPro.text = scenarioText[index];
            //StartCoroutine(TextReveal());
            index++;
        }
        else if (index == scenarioText.Count)
        {
            this.gameObject.SetActive(false);
            Step++;
            player.canMove = true;
            if (Step >= 2)
                player.canJump = true;
            if (Step >= 4)
                stressSystem.SetActive(true);
            Debug.Log(Step);
        }
    }

    public void NewScenario(List<string> scenario)
    {
        this.gameObject.SetActive(true);
        index = 0;
        scenarioText = scenario;
        ScenarioNext();
    }

    IEnumerator TextReveal()
    {
        int totalVisibleCharacter = m_textMeshPro.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (totalVisibleCharacter + 1);
            m_textMeshPro.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacter)
                yield return new WaitForSeconds(1.0f);
            counter += 1;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
