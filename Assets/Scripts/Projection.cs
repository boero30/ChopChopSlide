using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projection : MonoBehaviour
{
    private Scene _simulationScene;
    private PhysicsScene _physicsScene;

    [SerializeField] private Transform _kitchenParent;

    private void Start()
    {
        createPhysicsScene();
    }
    void createPhysicsScene()
    {
        _simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        _physicsScene = _simulationScene.GetPhysicsScene();

        foreach (Transform obj in _kitchenParent)
        {
            var ghostObj = Instantiate(obj.gameObject,obj.position,obj.rotation);
            ghostObj.GetComponent<Renderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(ghostObj,_simulationScene);
        }
    }

    [SerializeField] private LineRenderer _line;
    [SerializeField] private int _maxPhysicsFrameIterations;
    public void SimulateTrajectory(Controlpoint veg, Vector3 pos, Vector3 velocity)
    {
        var ghostObj = Instantiate(veg, pos, Quaternion.identity);
        ghostObj.GetComponent<Renderer>().enabled = false;
        SceneManager.MoveGameObjectToScene(ghostObj.gameObject, _simulationScene);

        ghostObj.Shoot();

        _line.positionCount = _maxPhysicsFrameIterations;

        for(int i = 0; i < _maxPhysicsFrameIterations; i++)
        {
            _physicsScene.Simulate(Time.fixedDeltaTime);
            _line.SetPosition(i, ghostObj.transform.position);
        }

        Destroy(ghostObj.gameObject);
    }

}
