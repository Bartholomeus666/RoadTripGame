using System.ComponentModel;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapPresenter : PresenterBase<MapModel>
{
	[SerializeField]Tilemap origin;
	[SerializeField] TileBase[] tiles;
	protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		throw new System.NotImplementedException();
	}
	private void Start()
	{
		foreach (TileBase tile in tiles)
		{

		}
	}
	// Update is called once per frame
	void Update()
    {
    }
}
