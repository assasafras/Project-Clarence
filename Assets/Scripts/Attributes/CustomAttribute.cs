using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Attributes
{
    public class CustomAttribute : BaseAttribute
    {

        public List<RawBonus> _rawBonuses;
        public List<FinalBonus> _finalBonuses;

        private float _finalValue;

        public CustomAttribute() : this(1) { }

        public CustomAttribute(float startingValue) : base(startingValue)
        {
            _rawBonuses = new List<RawBonus>();
            _finalBonuses = new List<FinalBonus>();

            _finalValue = baseValue;
        }

        public void RemoveBonus(Player.BonusType bt, BaseAttribute bonus)
        {
            switch (bt)
            {
                case Player.BonusType.Raw:
                    RemoveRawBonus((RawBonus)bonus);
                    break;
                case Player.BonusType.Final:
                    RemoveFinalBonus((FinalBonus)bonus);
                    break;
            }
        }

        public void AddBonus(Player.BonusType bt, BaseAttribute bonus)
        {
            switch (bt)
            {
                case Player.BonusType.Raw:
                    AddRawBonus( (RawBonus) bonus);
                    break;
                case Player.BonusType.Final:
                    AddFinalBonus( (FinalBonus) bonus);
                    break;
            }
        }

        public void AddRawBonus(RawBonus bonus)
        {
            _rawBonuses.Add(bonus);
        }

        public void AddFinalBonus(FinalBonus bonus)
        {
            _finalBonuses.Add(bonus);
        }

        public void RemoveRawBonus(RawBonus bonus)
        {
            _rawBonuses.Remove(bonus);
        }
         
        public void RemoveFinalBonus(FinalBonus bonus)
        {
            _finalBonuses.Remove(bonus);
        }

        public float CalculateValue()
        {
            _finalValue = baseValue;
             
            // Adding value from raw
            var rawBonusValue = 0f;
            var rawBonusMultiplier = 0f;
             
            foreach(var bonus in _rawBonuses)
            {
                rawBonusValue += bonus.baseValue;
                rawBonusMultiplier += bonus.baseMultiplier;
            }

            _finalValue += rawBonusValue;
            _finalValue *= (1 + rawBonusMultiplier);
             
            // Adding value from final
            var finalBonusValue = 0f;
            var finalBonusMultiplier = 0f;
             
            foreach(var bonus in _finalBonuses)
            {
                finalBonusValue += bonus.baseValue;
                finalBonusMultiplier += bonus.baseMultiplier;
            }

            _finalValue += finalBonusValue;
            _finalValue *= (1 + finalBonusMultiplier);
             
            return _finalValue;
        }

        public float FinalValue { get { return CalculateValue(); } }

        // Implicit Operators

        /// <summary>
        /// Returns the Final Value as a float.
        /// </summary>
        /// <param name="attribute"></param>
        static public implicit operator float(CustomAttribute attribute)
        {
            return attribute.FinalValue;
        }

        public static CustomAttribute operator + (CustomAttribute a, CustomAttribute b)
        {
            // Make a deep copy of a to remove referential issues
            var newAttribute = a.DeepCopy();

            // Collect all raw bonuses from b.
            newAttribute._rawBonuses.AddRange(b._rawBonuses);

            //Collect all final bonuses from b.
            newAttribute._finalBonuses.AddRange(b._finalBonuses);

            return newAttribute;
        }

        public static CustomAttribute operator + (CustomAttribute a, RawBonus b)
        {
            //a._rawBonuses.Add(b);
            //return a;
            var newAttribute = a.DeepCopy();

            // Collect all raw bonuses from a
            newAttribute._rawBonuses.Add(b);

            return newAttribute;
        }

        public CustomAttribute DeepCopy()
        {
            var newAttribute = new CustomAttribute(this.baseValue);
            // grab the raw bonuses.
            newAttribute._rawBonuses.AddRange(this._rawBonuses);
            // grab the final bonuses.
            newAttribute._finalBonuses.AddRange(this._finalBonuses);
            return newAttribute;
        }

        public override string ToString()
        {
            return this.FinalValue.ToString();
        }
    }
}
