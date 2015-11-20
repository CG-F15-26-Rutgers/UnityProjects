using UnityEngine;
using System.Collections;
using TreeSharpPlus;

public class BG_goTo : MonoBehaviour {

    public Transform moveTo1;
    public GameObject person;

    private BehaviorAgent theGuy;

	void Start () {
        theGuy = new BehaviorAgent(this.BuildTreeRoot());
        BehaviorManager.Instance.Register(theGuy);
        theGuy.StartBehavior();
	}
	
	void Update () {
	
	}

    protected Node WalkToPos(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(person.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(2));
    }

    protected Node BuildTreeRoot()
    {
        return new DecoratorLoop(new Sequence(this.WalkToPos(this.moveTo1)));

    }

}
