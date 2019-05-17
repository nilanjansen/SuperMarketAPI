using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace Supermarket.API.Extensions
{
    public static class EnumExtensions
    {

        /*First we define a generic method(a method that can receive more than onc
         * type of arguement, in this case,represented by the TEnum declaration) that
         *receives a given enum as an arguement
         Since enum is a reserved keyword in C#, we added an @ in front of Parameters name
`         The first execution step of this method is to get the type information(the class,
         interface,enum or struct def) of the parameter using the GetType method

        Then the method gets the specific enum value(for instance Kilogram) using
        GetField(@enum.ToString())
        The next line finds all the Description attribute applied over the enumeration
        value and stores their data into an array ( we can specify multiple attribute 
        for a same property in some cases)
        The last line uses a short syntax to check if we have at least one description attribute
        for the enum type. If we have, we return the Description value provided by this attribute.
        if not we return the enumeration as a string using the defult casting.

        ?. -> a null conditional operator checks if the value is null before accessing its property
        ?? -> a null coalescing operator,  tells the applicaiton to return the value at the left if its 
        not empty, or the value at the right otherwise.
             */
        public static string ToDescriptionString<TEnum>(this TEnum @enum)
        {
            FieldInfo info = @enum.GetType().GetField(@enum.ToString());
            var attribute = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attribute?[0].Description ?? @enum.ToString();
        }
    }
}
