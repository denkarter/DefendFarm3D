using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    //public GameObject buildEffect;
    public GameObject turret;

    //private TurretBlueprint turretToBuild;
    private Node selectedNode;

    //public NodeUI nodeUI;

    public bool CanBuild { get { return turret != null; } }

    public void SelectNode (Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turret = null;

        //nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
       // nodeUI.Hide();
    }

    public void SelectTurretToBuild ()
    {
        
        DeselectNode();
    }

    public GameObject GetTurretToBuild ()
    {
        return turret;
    }

}