using UnityEngine;
using TMPro;

public class RuleUI : MonoBehaviour
{
    public RuleManager ruleManager;
    public TMP_Text ruleText;

    void Update()
    {
        ruleText.text = ruleManager.currentRuleName;
    }
}
