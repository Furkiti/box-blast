using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    [Header("Space between menu items")] 
    [SerializeField] private Vector2 spacing;
    [SerializeField]private MenuItem[] menuItems;

    [Space] [Header("MainButton Rotation")] [SerializeField]
    private float rotationDuration;
    [SerializeField]private Ease rotationEase;
    
    [Space] [Header("Items Animation")] [SerializeField]
    private float expandDuration;
    [SerializeField]private float collapseDuration;
    [SerializeField]private Ease expandEase;
    [SerializeField]private Ease collapseEase;
    
    [Space] [Header("Fading")] [SerializeField]
    private float expandfadingDuration;
    [SerializeField]private float collapseFadingDuration;
    
    
    private Button _mainButton;
    private Vector2 _mainButtonPosition;
    private int _menuItemCount;
    private bool _isExpanded;

    
    [SerializeField] private GameObject startButton;



   
    
    void Start()
    {
        
        _mainButton = transform.GetChild(0).GetComponent<Button>();
        _mainButton.transform.SetAsLastSibling();          //Move the transform to the end of the local transform list.
        _mainButtonPosition = _mainButton.transform.position;
        _menuItemCount = menuItems.Length;
        _isExpanded = false;
        ResetPositions(); //if want to make settings expanded pass this function.
        
    }

    public void ResetPositions()
    {
        for (int i = 0; i < _menuItemCount; i++)
        {
            menuItems[i].trans.position = _mainButtonPosition; //fit to all menu items behind to MainButton
        }
    }

    public void ToggleMenu() //if the user click the MainButton this function changes to Menu statement.
    {
        if (!_isExpanded)
        {
            for (int i = 0; i < _menuItemCount; i++)
            {
                //menuItems[i].trans.position = _mainButtonPosition + spacing*(i+1);
                menuItems[i].trans.DOMove(_mainButtonPosition + spacing * (i + 1), expandDuration).SetEase(expandEase);
                menuItems[i].img.DOFade(1, expandfadingDuration).From(0);
            }
            
            startButton.gameObject.SetActive(false);
        }
        else
        {
            for (int i = 0; i < _menuItemCount; i++)
            {
                //menuItems[i].trans.position = _mainButtonPosition;  //fit to all menu items behind to MainButton
                menuItems[i].trans.DOMove(_mainButtonPosition, collapseDuration).SetEase(collapseEase);
                menuItems[i].img.DOFade(0, collapseFadingDuration);
            }
            
            startButton.gameObject.SetActive(true);
        }

        _mainButton.transform.DORotate(Vector3.forward * 180f, rotationDuration).From(Vector3.zero).SetEase(rotationEase);
        _isExpanded = !_isExpanded; //change the Menu statement after clicking.

    }

   
    public void OnItemClick(int index)
    {
        switch (index)
        {
            case 0:
                Debug.Log("Sound!");
                GameManager.Instance.GetSettingsMenuActionController().GetComponent<SettingsMenuActionController>().ChangeSound(menuItems[index]);
                break;
            case 1:
                Debug.Log("Music!");
                GameManager.Instance.GetSettingsMenuActionController().GetComponent<SettingsMenuActionController>().ChangeMusic(menuItems[index]);
                break;
            case 2:
                Debug.Log("Vibration!");
                GameManager.Instance.GetSettingsMenuActionController().GetComponent<SettingsMenuActionController>().ChangeVibration(menuItems[index]);
                break;
            case 3:
                Debug.Log("Notifications!");
                GameManager.Instance.GetSettingsMenuActionController().GetComponent<SettingsMenuActionController>().ChangeNotifications(menuItems[index]);
                break;
                
        }
    }
}
