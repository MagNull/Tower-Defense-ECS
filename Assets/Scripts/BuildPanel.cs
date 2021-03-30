using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildPanel : MonoBehaviour
{
    [SerializeField] private Button _archerButton;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _destroyButton;
    private Transform _buildPoint;
    private Contexts _contexts;

    public void ShowPanel(BuildingClickComponent component)
    {
        if(_buildPoint) _buildPoint.GetComponent<Collider>().enabled = true;
        _buildPoint = component.BuildingPlace;
        _buildPoint.GetComponent<Collider>().enabled = false;
        
        if (component.IsBuilding)
        {
            _archerButton.gameObject.SetActive(false);
            _upgradeButton.gameObject.SetActive(true);
            _destroyButton.gameObject.SetActive(true);
        }
        else
        {
            _archerButton.gameObject.SetActive(true);
            _upgradeButton.gameObject.SetActive(false);
            _destroyButton.gameObject.SetActive(false);
        }
        
        gameObject.SetActive(true);
        transform.position = component.CursorPosition;
    }

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
    }

    private void OnEnable()
    {
        _archerButton.onClick.RemoveAllListeners();
        _destroyButton.onClick.RemoveAllListeners();
        _archerButton.onClick.AddListener(() =>
        {
            _contexts.game.CreateEntity().AddBuildCommand(BuildingType.ARCHER, _buildPoint);
            gameObject.SetActive(false);
        });
        _destroyButton.onClick.AddListener(() =>
        {
            _buildPoint.GetComponentInParent<EntityLink>().LinkedEntity.isDemolish = true;
            
            gameObject.SetActive(false);
        });

    }
}