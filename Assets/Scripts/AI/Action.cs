using UnityEngine;
/// <summary>
/// 行为抽象类
/// </summary>
public abstract class Action : ScriptableObject {
    /// <summary>
    /// 行为具体实现
    /// </summary>
    public abstract void Act(StateController controller);
}
