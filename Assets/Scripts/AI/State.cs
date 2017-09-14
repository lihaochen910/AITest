using UnityEngine;
/// <summary>
/// AI状态类
/// </summary>
[CreateAssetMenu(menuName = "PluggableAI/State")]
public class State : ScriptableObject
{
    /// <summary>
    /// 逻辑组
    /// </summary>
    public Action[] actions;
    /// <summary>
    /// 状态变换组
    /// </summary>
    public Transition[] transitions;

    public Color SceneGizmoColor = Color.gray;

    /// <summary>
    /// 逐帧更新状态逻辑
    /// </summary>
    /// <param name="controller"></param>
    public void UpdateState(StateController controller)
    {
        DoAction(controller);
        CheckTransitions(controller);
    }
    /// <summary>
    /// 执行该状态下的逻辑组
    /// </summary>
    /// <param name="controller"></param>
    private void DoAction(StateController controller)
    {
        for (int i = 0;i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }
    /// <summary>
    /// 检查状态切换条件
    /// </summary>
    /// <param name="controller"></param>
    private void CheckTransitions(StateController controller)
    {
        for (int i = 0;i < transitions.Length;i++)
        {
            bool decisionIsTrue = transitions[i].decision.Decide(controller);

            if (decisionIsTrue)
            {
                controller.TransitionToState(transitions[i].trueState);
            }else
            {
                controller.TransitionToState(transitions[i].falseState);
            }
        }
    }
}
