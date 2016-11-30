using UnityEngine;
using System.Collections;

public class DataAnalizer : MonoBehaviour {

    public static int AnalizeData(Data[] p_data)
    {
        if (p_data[0].health < p_data[1].health)
        {
            if (p_data[1].health < p_data[2].health)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        else
        {
            if (p_data[1].health < p_data[2].health)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }

    public static MoveType AnalizeMovement(Data[] p_data)
    {
        return MoveType.IDLE;
    }
}
