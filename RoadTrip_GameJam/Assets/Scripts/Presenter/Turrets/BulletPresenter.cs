using System.ComponentModel;
using UnityEngine;

public class BulletPresenter : PresenterBase<BulletModel>
{


    private void Update()
    {
        if (Vector2.Distance(transform.position, Model.Target) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, Model.Target, Model.Speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D<TModel>(Collision2D collision) where TModel : IEnemyModel
    {
        if(collision.gameObject.layer == 11)
        {
            collision.gameObject.GetComponent<TModel>().DeleteThis();
            Destroy(this.gameObject);
        }

    }

    protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        
    }
}
