using UnityEngine;
using System.Collections;

public class DataAnalyzer : MonoBehaviour {

    private static float AnalyzeHealth(Data[] p_data, float p_value)
    {
        if (p_data[0].health < p_data[1].health)
        {
            if (p_data[1].health < p_data[2].health)
            {
                p_value -= 0.1f;
            }
            else
            {
                p_value -= 0.2f;
            }
        }
        else if (p_data[0].health > p_data[1].health)
        {
            if (p_data[1].health < p_data[2].health)
            {
                p_value += 0.2f;
            }
            else if (p_data[1].health > p_data[2].health)
            {
                p_value += 0.1f;
            }
        }
        return p_value;
    }

    private static int AnalyzeState(Data[] p_data)
    {
        int __value = 0;
        for (int i = p_data.Length-1; i >=0;i--)
        {
            switch(p_data[i].playerState)
            {
                default:
                    __value += 0;
                    break;
                case States.JUMPING_LEFT:
                    __value += 100;
                    break;
                case States.JUMPING_RIGHT:
                    __value += 400;
                    break;
                case States.JUMPING_STANDING:
                    __value += 1300;
                    break;
                case States.WALKING_LEFT:
                    __value += 5;
                    break;
                case States.WALKING_RIGHT:
                    __value += 20;
                    break;
            }
        }
        return __value;
    }
      
    private static MoveType AnalyzeMovement(Data[] p_data)
    {
        var __distanceNow = Vector2.Distance(p_data[0].position, p_data[1].position);
        var __distanceBack = Vector2.Distance(p_data[1].position, p_data[2].position);
        var __distanceTotal = Vector2.Distance(p_data[0].position, p_data[2].position);
        
        if (__distanceNow > 2f)
        {
            if (__distanceBack > 2f)
            {
                if (__distanceTotal > 3f) return MoveType.ADVANCE;
                else return MoveType.ERRATIC;
            }
            else
            {
                if (__distanceTotal > 3f) return MoveType.ADVANCE;
                else return MoveType.IDLE;
            }
        }
        else if (__distanceNow >= 0.5f && __distanceNow <= 2f)
        {
            if (__distanceBack > 2f)
            {
                if (__distanceTotal > 2f) return MoveType.ADVANCE;
                else return MoveType.ERRATIC;
            }
            else
            {
                if (__distanceTotal > 2f) return MoveType.ERRATIC;
                else return MoveType.IDLE;
            }
        }
        else
        {
            if (__distanceBack > 2f)
            {
                if (__distanceTotal > 3f) return MoveType.ADVANCE;
                else return MoveType.ERRATIC;
            }
            else
            {
                if (__distanceTotal > 0.5f && __distanceTotal <= 1.5f) return MoveType.ERRATIC;
                else return MoveType.IDLE;
            }
        }
    }  
   
    private static float CalculateMovements(Data[] p_data, float p_value)
    {
        var __state = AnalyzeState(p_data);
        var __moveType = AnalyzeMovement(p_data);
      
        //Jogador no chão
        if (__state < 100)
        {
            if (__moveType == MoveType.ADVANCE)
            {
                if (__state > 40)
                {
                    p_value += 0.02f;
                }
                else if (__state > 20)
                {
                    p_value += 0.01f;
                } 
                else
                {                    
                    if (p_value < -0.1f)
                    {
                        p_value += 0.01f;
                    }
                    else
                    {
                        p_value -= 0.01f;
                    }
                }
            }
            else if (__moveType == MoveType.ERRATIC)
            {
                if (__state > 40)
                {
                    p_value -= 0.02f;
                }
                else if (__state < 20)
                {
                    p_value -= 0.01f;
                }
            }
            else
            {
                if (__state > 40)
                {
                    if (p_value < -0.1f)
                    {
                        p_value += 0.01f;
                    }
                    else
                    {
                        p_value -= 0.01f;
                    }
                }
                else if (__state < 20)
                {
                    if (p_value < -0.1f)
                    {
                        p_value += 0.02f;
                    }
                    else
                    {
                        p_value -= 0.02f;
                    }
                }
            }
        }
        else if (__state < 400) // Jogador pulando para o lado esquerdo
        {
            if (__moveType == MoveType.ADVANCE)
            {
                if (__state > 40)
                {
                    if(p_value<0.2f)
                    {
                        p_value += 0.03f;
                    }
                    else
                    {
                        p_value += 0.02f;
                    }
                }
                else if (__state > 20)
                {
                    if(p_value>-0.4f)
                    {
                        p_value -= 0.03f;
                    }
                    else
                    {
                        p_value -= 0.02f;
                    }
                }
                else
                {
                    p_value -= 0.01f;
                }
            }
            else if (__moveType == MoveType.ERRATIC)
            {
                if (__state > 40)
                {
                    if (p_value < -0.4f)
                    {
                        p_value -= 0.02f;
                    }
                    else p_value -= 0.03f;
                }
                else if (__state < 20)
                {
                    p_value -= 0.04f;
                }
            }
            else
            {
                if (__state > 40)
                {
                    if (p_value < -0.4f)
                    {
                        p_value -= 0.01f;
                    }
                    else p_value -= 0.02f;
                }
                else if (__state < 20)
                {
                    if (p_value < -0.1f)
                    {
                        p_value += 0.02f;
                    }
                    else
                    {
                        p_value -= 0.02f;
                    }
                }
            }
        }
        else if (__state < 1200) // Jogador pulando para o lado direito
        {
            if (__moveType == MoveType.ADVANCE)
            {
                if (__state > 40)
                {
                  if(p_value<0.4f)
                   {
                        p_value += 0.03f;
                   }
                  else
                   {
                        p_value += 0.02f;
                   }
                }
                else if (__state > 20)
                {
                    if (p_value < 0.4f)
                    {
                        p_value += 0.02f;
                    }
                    else
                    {
                        p_value += 0.01f;
                    }
                }
                else
                {
                    p_value += 0.02f;
                }
            }
            else if (__moveType == MoveType.ERRATIC)
            {
                if (__state > 40)
                {
                    if (p_value > 0.4f)
                    {
                        p_value -= 0.03f;
                    }
                    else if (p_value < -0.4f)
                    {
                        p_value += 0.03f;
                    }
                    else
                    {
                        if(p_value>0)
                        {
                            p_value -= 0.01f;
                        }
                        else
                        {
                            p_value += 0.01f;
                        }
                    }
                }
                else if (__state < 20)
                {
                    if (p_value > 0.4f)
                    {
                        p_value -= 0.04f;
                    }
                    else 
                    {
                        p_value -= 0.02f;
                    }
                }
            }
            else
            {
                if (__state > 40)
                {
                    if (p_value > 0.4f)
                    {
                        p_value -= 0.02f;
                    }
                    else
                    {
                        p_value -= 0.01f;
                    }
                }
                else if (__state < 20)
                {
                    if(p_value<-0.4f)
                    {
                        p_value += 0.03f;
                    }
                    else
                    if (p_value > 0.4f)
                    {
                        p_value -= 0.02f;
                    }
                    else
                    {
                        if (p_value > 0)
                        {
                            p_value -= 0.01f;
                        }
                        else
                        {
                            p_value += 0.01f;
                        }
                    }
                }
            }
        }
        else  // Jogador pulando no mesmo lugar
        {
            if (__moveType == MoveType.ADVANCE)
            {
                if (__state > 40)
                {
                    if (p_value < 0.4f)
                    {
                        p_value += 0.04f;
                    }
                    else
                    {
                        p_value += 0.03f;
                    }
                }
                else if (__state > 20)
                {
                    if (p_value < 0.4f)
                    {
                        p_value += 0.03f;
                    }
                    else
                    {
                        p_value += 0.02f;
                    }
                }
                else
                {
                    if(p_value<-0.3f)
                    {
                        p_value -= 0.02f;
                    }
                    else if (p_value > 0.3f)
                    {
                        p_value -= 0.04f;
                    }
                    else
                    {
                        p_value -= 0.03f;
                    }
                }
            }
            else if (__moveType == MoveType.ERRATIC)
            {
                if (__state > 40)
                {
                    if (p_value < -0.3f)
                    {
                        p_value -= 0.03f;
                    }
                    else if (p_value > 0.3f)
                    {
                        p_value -= 0.05f;
                    }
                    else
                    {
                        p_value -= 0.02f;
                    }
                }
                else if (__state < 20)
                {

                    if (p_value < -0.3f)
                    {
                        p_value -= 0.02f;
                    }
                    else
                    {
                        p_value -= 0.02f;
                    }
                }
            }
            else
            {
                if (__state > 40)p_value -= 0.02f;
                else if (__state < 20)
                {
                    if(p_value > -0.3f)
                    {
                        p_value -= 0.05f;
                    }
                    else p_value -= 0.03f;
                }
            }
        }
        return p_value;
    }

    //Modifica os valores de emoções recebidos
    public static float CalculateEmotionLevels(Data[] p_data, float p_value)
    {
        p_value = AnalyzeHealth(p_data, p_value);
        p_value = CalculateMovements(p_data, p_value);     
        return p_value;
    }
}
