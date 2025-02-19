using UnityEngine;
using System.Collections;

// This script handles the behaviour of the weapon as hole.
public class WeaponCtrl : MonoBehaviour
{
	public GameObject CartridgesPrefab;
	public float CartridgeExpulsionForce = 5;
	
	public GameObject SpotLightPrefab;
	
	public GameObject ShootPrefab;
	
	public int ReloadAmount;
	public int CurrentAmunition { get; private set; }
	
	private CartridgeSpawnPoint _cartridgeSpawPoint;
	private ShootSpawnPoint _shootSpawnPoint;
	private SpotLightSpawnPoint _spotlightSpawnPoint;
	
	void Awake()
	{
		// Determine which components this weapon will have
		_cartridgeSpawPoint = GetComponentInChildren<CartridgeSpawnPoint>();
		if (_cartridgeSpawPoint == null)
		{
			Debug.LogWarning("There is no Cartridge Spawn Point defined in the weapon");
		}
		_shootSpawnPoint = GetComponentInChildren<ShootSpawnPoint>();
		if (_shootSpawnPoint == null)
		{
			Debug.LogWarning("There is no Shoot Spawn Point defined in the weapon");
		}
		_spotlightSpawnPoint = GetComponentInChildren<SpotLightSpawnPoint>();
		if (_spotlightSpawnPoint == null)
		{
			Debug.LogWarning("There is no SpotLight Spawn Point defined in the weapon");
		}
	}
	
	void Start()
	{
		// init the available components.
		if (_cartridgeSpawPoint != null)
		{
			_cartridgeSpawPoint.Setup(CartridgesPrefab.gameObject);
		}
		if (_shootSpawnPoint != null)
		{
			_shootSpawnPoint.Setup(_cartridgeSpawPoint, ShootPrefab.gameObject);
		}
		if (_spotlightSpawnPoint != null)
		{
			_spotlightSpawnPoint.Setup(SpotLightPrefab.gameObject);
		}
	}
	
	public void EnableFocus()
	{
		if (_spotlightSpawnPoint != null)
		{
			_spotlightSpawnPoint.SwitchOn();
		}
	}
	
	public bool IsFocusEnabled()
	{
		if (_spotlightSpawnPoint == null)
		{
			return false;
		}
		return _spotlightSpawnPoint.Status;
	}
	
	public void DisableFocus()
	{
		if (_spotlightSpawnPoint != null)
		{
			_spotlightSpawnPoint.SwitchOff();
		}
	}
	
	public void Reload()
	{
		// Add the indicated bullets
		// TODO: Add this as another prefab so the weapon known nothing about this.
		CurrentAmunition = ReloadAmount;
	}
	
	public void DoShoot()
	{
		if (CurrentAmunition > 0)
		{
			// Consume a bullet
			CurrentAmunition -= 1;
			if (_shootSpawnPoint != null)
			{
				_shootSpawnPoint.DoShoot();
			}
		}
		else
		{
			// We can not shoot
			// TODO: make empty cartridge noise?
		}
	}
}
