using System;
using System.Collections.Generic;
using Nexio.Models;

namespace Nexio.Services
{
    public class ResultValidator
    {
        public Dictionary<string, PersonModel> Dic { get; set; }
        private ResultValidator()
        {
            Dic = new Dictionary<string, PersonModel>();
        }

        private static ResultValidator instance = null;
        public static ResultValidator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResultValidator();
                }
                return instance;
            }
        }

        public string ValidateResult()
        {
            var count = 0;

            var heightDiff = CalculateHeightDifference();
            if (heightDiff >= 0.1)
                count += 1;

            var isEyeColorSame = CheckEyeColors();
            if (isEyeColorSame)
                count += 1;

            var ageDiff = CalculateAgeDifference();
            if (ageDiff <= 5)
                count += 1;

            if (count < 2)
            {
               return $"{Dic["woman"].Name} i {Dic["man"].Name} nie pasują do siebie.";
            }
            return $"{Dic["woman"].Name} i {Dic["man"].Name} pasują do siebie.";
        }

        private bool CheckEyeColors()
        {
            return Dic["man"].EyeColor == Dic["woman"].EyeColor;
        }

        private float CalculateHeightDifference()
        {
            return Dic["man"].Height - Dic["woman"].Height;
        }

        private int CalculateAgeDifference()
        {
            int ageDiff = 0;
            DateTime dt1, dt2;
            if (Dic["man"].DateOfBirth.Year < Dic["woman"].DateOfBirth.Year)
            {
                dt1 = Dic["man"].DateOfBirth;
                dt2 = Dic["woman"].DateOfBirth;
            }
            else
            {
                dt1 = Dic["woman"].DateOfBirth;
                dt2 = Dic["man"].DateOfBirth;
            }

            while (dt2 >= dt1)
            {
                ageDiff++;
                dt2 = dt2.AddYears(-1);
            }
            dt2 = dt2.AddYears(1);
            ageDiff--;
            return ageDiff;
        }

        public void Clear()
        {
            Dic.Clear();
        }
    }
}