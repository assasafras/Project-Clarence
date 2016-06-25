using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Attributes
{
    public class RawBonus : BaseAttribute
    {

        public RawBonus(float value) : this(value, 0) { }

        public RawBonus(float value, float multiplier) : base(value, multiplier) { }
    }
}
