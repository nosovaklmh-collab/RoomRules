using UnityEngine;

public enum Rule
{
    Normal,
    LowGravity,
    HeavyGravity,
    InvertedGravity,
    SlowMotion
}

public class RuleManager : MonoBehaviour
{
    public Rule currentRule = Rule.Normal;
    public string currentRuleName = "Normal";

    public void ApplyRandomRule()
    {
        Rule[] rules = (Rule[])System.Enum.GetValues(typeof(Rule));
        currentRule = rules[Random.Range(0, rules.Length)];
        ApplyRule(currentRule);
    }

    void ApplyRule(Rule rule)
    {
        // Сбрасываем всё к нормальному состоянию
        Physics.gravity = new Vector3(0, -9.81f, 0);
        Time.timeScale = 1f;

        switch (rule)
        {
            case Rule.LowGravity:
                Physics.gravity = new Vector3(0, -3f, 0);
                currentRuleName = "Low gravity";
                break;
            case Rule.HeavyGravity:
                Physics.gravity = new Vector3(0, -25f, 0);
                currentRuleName = "Heavy gravity";
                break;
            case Rule.InvertedGravity:
                Physics.gravity = new Vector3(0, 9.81f, 0);
                currentRuleName = "Inverted gravity";
                break;
            case Rule.SlowMotion:
                Time.timeScale = 0.5f;
                currentRuleName = "Slow motion";
                break;
            default:
                currentRuleName = "Normal";
                break;
        }
    }

    void OnDisable()
    {
        // Возвращаем физику в норму при остановке игры
        Physics.gravity = new Vector3(0, -9.81f, 0);
        Time.timeScale = 1f;
    }
}
