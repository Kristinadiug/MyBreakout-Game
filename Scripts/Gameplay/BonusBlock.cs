using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block
{
    // Start is called before the first frame update
    protected override void Start()
    {
        points = ConfigurationUtils.BonusBlockPoints;
        base.Start();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        //AudioManager.Play(AudioName.Bonus);
        base.OnCollisionEnter2D(collision);
    }
}
