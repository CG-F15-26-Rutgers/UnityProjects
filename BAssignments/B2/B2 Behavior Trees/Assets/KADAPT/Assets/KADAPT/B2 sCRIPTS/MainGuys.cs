using UnityEngine;
using System.Collections;
using TreeSharpPlus;

public class MainGuys : MonoBehaviour
{

    public Transform moveTo1;
    public GameObject person;
    public Transform orientTowardsThis;

    private BehaviorAgent theGuy;

    void Start()
    {
        theGuy = new BehaviorAgent(this.BuildTreeRoot());
        BehaviorManager.Instance.Register(theGuy);
        theGuy.StartBehavior();
    }

    void Update()
    {

    }

    protected Node WalkToPos(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(person.GetComponent<BehaviorMecanim>().Node_GoTo(position));
    }

    protected Node LookAtThing(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(person.GetComponent<BehaviorMecanim>().Node_OrientTowards(position));
    }

    protected Node HeadLookAtThing(Transform target)
    {
        Val<Vector3> position = Val.V(() => target.position);
        return new Sequence(person.GetComponent<BehaviorMecanim>().Node_HeadLook(position));
    }

    protected Node handWave()
    {
        return new Sequence(person.GetComponent<BehaviorMecanim>().Node_HandAnimation("Wave", true));
    }

    protected Node BuildTreeRoot()
    {
       // Debug.Log("Sequence" + );
        return new Sequence( LookAtThing(orientTowardsThis), new SequenceParallel(HeadLookAtThing(orientTowardsThis), WalkToPos(moveTo1)) ,  handWave());

    }

}
