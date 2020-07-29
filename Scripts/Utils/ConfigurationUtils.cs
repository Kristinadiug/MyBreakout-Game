using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationDataFile.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return configurationDataFile.BallImpulseForce; }
    }

    public static float BallLifeTimeDuration
    {
        get { return configurationDataFile.BallLifeTimeDuration; }
    }

    /// <summary>
    /// Gets minimal time to spawn a ball
    /// </summary>
    /// <value>impulse force</value>
    public static float MinBallSpawningTime
    {
        get { return configurationDataFile.MinBallSpawningTime; }
    }


    /// <summary>
    /// Gets minimal time to spawn a ball
    /// </summary>
    /// <value>impulse force</value>
    public static float MaxBallSpawningTime
    {
        get { return configurationDataFile.MaxBallSpawningTime; }
    }

    /// <summary>
    /// Gets points for a standar block
    /// </summary>
    /// <value>impulse force</value>
    public static int StandartBlockPoints
    {
        get { return configurationDataFile.StandartBlockPoints; }
    }

    /// <summary>
    /// Gets points for a bonus block
    /// </summary>
    /// <value>impulse force</value>
    public static int BonusBlockPoints
    {
        get { return configurationDataFile.BonusBlockPoints; }
    }

    /// <summary>
    /// Gets the duration on puck up effects
    /// </summary>
    /// <value>impulse force</value>
    public static float PickUpEffectDuration
    {
        get { return 2f; }
    }

    public static ConfigurationData configurationDataFile;


    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationDataFile = new ConfigurationData();
    }
}
