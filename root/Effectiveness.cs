using System.Reflection.Metadata;
using System.Text;

namespace root;

public class Effectiveness
{

    public float multiplier1 = 1f;
    public float multiplier2 = 1f;
    
    public void Effective(Types attackType = Types.NORMAL, Types defenseType1 = Types.NORMAL, Types defenseType2 = Types.NORMAL)
    {
        switch (attackType)
        {
            case Types.NORMAL:
                switch (defenseType1)
                {
                    case Types.ROCK:
                        multiplier1 = 0.5f;
                        break;
                    case Types.GHOST:
                        multiplier1 = 0f;
                        break;
                }
                break;
            case Types.FIRE:
                switch (defenseType1)
                {
                    
                }
                break;
        }
        
    }
}