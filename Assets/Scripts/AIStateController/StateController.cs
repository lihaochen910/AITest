using UnityEngine;

public class StateController : MonoBehaviour {
    /// <summary>
    /// AI当前状态引用
    /// </summary>
    public State currentState;
    /// <summary>
    /// AI备选状态
    /// </summary>
    public State remainState;
    /// <summary>
    /// AI基本属性
    /// </summary>
    //public EnemyStats enemyStats;

    /// <summary>
    /// AI是否激活
    /// </summary>
    private bool aiActive;


	void Awake () 
	{

	}

	public void SetupAI()
	{
		
	}

    void Update()
    {
        UpdateState();
    }
    /// <summary>
    /// 更新AI逻辑:状态->条件判定(是否切状态)->执行指定状态逐帧逻辑
    /// </summary>
    private void UpdateState()
    {
        if (!aiActive)
            return;
        currentState.UpdateState(this);
    }

    void OnDrawGizmos()
    {
        if (currentState)
        {
            Gizmos.color = currentState.SceneGizmoColor;
            //Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
        }
    }

    void OnGUI()
    {
        //if (chaseTarget != null)
        //{
        //    GUI.Label(new Rect(0,0,100,100), "Distance:" + Vector3.Distance(transform.position, chaseTarget.position));
        //}
    }

    /// <summary>
    /// 切换到指定状态
    /// </summary>
    /// <param name="nextState">指定状态</param>
    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }
}