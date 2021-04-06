using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildPanel : MonoBehaviour
{
    [SerializeField] private Button _archerTowerButton;
    [SerializeField] private Button _magicTowerButton;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _destroyButton;
    private Transform _buildPoint;
    private Contexts _contexts;
    private RectTransform _rectTransform;
    

    public void ShowPanel(BuildingClickComponent component)
    {
        if (!gameObject.activeSelf 
            || !RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, Input.mousePosition))
        {
            if(_buildPoint) _buildPoint.GetComponent<Collider>().enabled = true;
            _buildPoint = component.BuildingPlace;
            _buildPoint.GetComponent<Collider>().enabled = false;

            if (component.IsBuilding)
            {
                _archerTowerButton.gameObject.SetActive(false);
                _magicTowerButton.gameObject.SetActive(false);
                _upgradeButton.gameObject.SetActive(true);
                _destroyButton.gameObject.SetActive(true);
            }
            else
            {
                _archerTowerButton.gameObject.SetActive(true);
                _magicTowerButton.gameObject.SetActive(true);
                _upgradeButton.gameObject.SetActive(false);
                _destroyButton.gameObject.SetActive(false);
            }
        
            gameObject.SetActive(true);
            transform.position = component.CursorPosition;
        }
    }

    public void HidePanel()
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, Input.mousePosition))
        {
            if(_buildPoint) _buildPoint.GetComponent<Collider>().enabled = true;
            gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        _archerTowerButton.onClick.RemoveAllListeners();
        _magicTowerButton.onClick.RemoveAllListeners();
        _destroyButton.onClick.RemoveAllListeners();
        _archerTowerButton.onClick.AddListener(() =>
        {
            _contexts.game.CreateEntity().AddBuildCommand(TowerType.ARCHER, _buildPoint);
            gameObject.SetActive(false);
        });
        _magicTowerButton.onClick.AddListener(() =>
        {
            _contexts.game.CreateEntity().AddBuildCommand(TowerType.MAGE, _buildPoint);
            gameObject.SetActive(false);
        });
        _destroyButton.onClick.AddListener(() =>
        {
            _buildPoint.GetComponentInParent<EntityLink>().LinkedEntity.isDemolish = true;
            gameObject.SetActive(false);
        });

    }
}