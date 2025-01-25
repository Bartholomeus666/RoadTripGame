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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 11)
        {
            Destroy(this.gameObject);
        }

    }

    protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        
    }
}
