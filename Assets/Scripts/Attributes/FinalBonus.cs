using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Attributes
{
    public class FinalBonus : BaseAttribute
    {
        public FinalBonus(float value) : base(value, 0) { }
        public FinalBonus(float value, float multiplier) : base(value, multiplier) { }
    }
}
