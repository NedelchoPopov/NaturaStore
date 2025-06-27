using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Data.Common
{
    public static class EntityConstants
    {
        public static class Category
        {
           public const int NameMinLenght = 2;

           public const int NameMaxLenght = 70;

           public const int DescriptionMaxLenght = 500;
        }

        public static class Product 
        {
            public const int NameMaxLenght = 85;

            public const int DescriptionMaxLenght = 1000;

            public const int PricePrecision = 10;

            public const int PriceScale = 2;
        }

        public static class Producer
        {
            public const int NameMaxLength = 100;
            public const int DescriptionMaxLength = 500;
            public const int LocationMaxLength = 100;
            public const int ContactEmailMaxLength = 100;
            public const int PhoneNumberMaxLength = 20;
        }
    }
}
