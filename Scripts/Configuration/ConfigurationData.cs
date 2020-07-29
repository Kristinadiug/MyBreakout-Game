using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 1;
    static float ballImpulseForce = 20;
    static float ballLifeTimeDuration = 5;

    static float minBallSpawningTime = 1;
    static float maxBallSpawningTime = 10;

    static int standartBlockPoints = 10;
    static int bonusBlockPoints = 50;

    static float pickUpEffectDuration = 2;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }


    /// <summary>
    /// Gets the duration of ball's life
    /// </summary>
    /// <value>impulse force</value>
    public float BallLifeTimeDuration
    {
        get { return ballLifeTimeDuration; }
    }


    /// <summary>
    /// Gets minimal time to spawn a ball
    /// </summary>
    /// <value>impulse force</value>
    public float MinBallSpawningTime
    {
        get { return minBallSpawningTime; }
    }


    /// <summary>
    /// Gets minimal time to spawn a ball
    /// </summary>
    /// <value>impulse force</value>
    public float MaxBallSpawningTime
    {
        get { return maxBallSpawningTime; }
    }


    /// <summary>
    /// Gets points for a standart block
    /// </summary>
    /// <value>impulse force</value>
    public int StandartBlockPoints
    {
        get { return standartBlockPoints; }
    }

    /// <summary>
    /// Gets points for a bonus block
    /// </summary>
    /// <value>impulse force</value>
    public int BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    /// <summary>
    /// Gets the duration on puck up effects
    /// </summary>
    /// <value>impulse force</value>
    public float PickUpEffectDuration
    {
        get { return pickUpEffectDuration; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

            string names = input.ReadLine();
            string values = input.ReadLine();

            SetConfigurationFields(values);
        }
        catch (Exception e) { }
        finally
        {
            if(input != null)
            {
                input.Close();
            }
            
        }
    }

    #endregion

    #region Methods


    void SetConfigurationFields(string csvValues)
    {
        string[] values = csvValues.Split(',');

        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeTimeDuration = float.Parse(values[2]);

        minBallSpawningTime = float.Parse(values[3]);
        maxBallSpawningTime = float.Parse(values[4]);

        standartBlockPoints = int.Parse(values[5]);
        bonusBlockPoints = int.Parse(values[6]);
    }

    #endregion
}
