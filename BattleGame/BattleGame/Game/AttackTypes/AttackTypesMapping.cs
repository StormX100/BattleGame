using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Game.Options
{
    public class AttackTypesMapping
    {
        public static readonly IDictionary<PlayerType, IList<AllAttackTypes>> Mapping
            = new Dictionary<PlayerType, IList<AllAttackTypes>>() { { PlayerType.Warrior, new List<AllAttackTypes>() {  AllAttackTypes.Atack} },     
                                                                    { PlayerType.Wizard, new List<AllAttackTypes>()  {  AllAttackTypes.DealDamage, 
                                                                                                                        AllAttackTypes.RestoreHealth,
                                                                                                                        AllAttackTypes.IncreaseMaxAttack, 
                                                                                                                        AllAttackTypes.IncreaseMaxArmor } } };

    }
}
