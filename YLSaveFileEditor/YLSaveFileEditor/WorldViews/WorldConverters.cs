using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace YLSaveFileEditor.WorldViews
{

    public class WorldStateConverter : IValueConverter
    {
        const string LockedString = "";
        const string UnlockedString = "{\"_variables\":{\"worldUnlocked\":{\"_value\":true,\"_name\":\"worldUnlocked\"" +
            ",\"$type\":\"NodeCanvas.Framework.Variable`1[[System.Boolean, mscorlib, Version=2.0.5.0, Culture=neutral," +
            " PublicKeyToken=7cec85d7bea7798e]]\"}}}";
        const string ExpandedString1 = "{\"_variables\":{\"worldUnlocked\":{\"_value\":true,\"_name\":\"worldUnlocked\"," +
            "\"$type\":\"NodeCanvas.Framework.Variable`1[[System.Boolean, mscorlib, Version=2.0.5.0, Culture=neutral," +
            " PublicKeyToken=7cec85d7bea7798e]]\"},\"extensionUnlocked\":{\"_value\":true,\"_name\":\"extensionUnlocked" +
            "\",\"$type\":\"NodeCanvas.Framework.Variable`1[[System.Boolean, mscorlib, Version=2.0.5.0, Culture=neutral," +
            " PublicKeyToken=7cec85d7bea7798e]]\"}}}";
        const string ExpandedString2 = "{\"_name\":\"WorldState\",\"_variables\":{\"extensionUnlocked\":{\"_value" +
            "\":true,\"_name\":\"extensionUnlocked\",\"$type\":\"NodeCanvas.Framework.Variable`1[[System.Boolean, mscorlib, " +
            "Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]\"},\"extensionSeen\":{\"_value\":true," +
            "\"_name\":\"extensionSeen\",\"$type\":\"NodeCanvas.Framework.Variable`1[[System.Boolean, mscorlib, Version=2.0.5.0," +
            " Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]\"},\"bookOpened\":{\"_value\":true,\"_name\":\"bookOpened\"," +
            "\"$type\":\"NodeCanvas.Framework.Variable`1[[System.Boolean, mscorlib, Version=2.0.5.0, Culture=neutral, " +
            "PublicKeyToken=7cec85d7bea7798e]]\"},\"worldUnlocked\":{\"_value\":true,\"_name\":\"worldUnlocked\",\"$type\":" +
            "\"NodeCanvas.Framework.Variable`1[[System.Boolean, mscorlib, Version=2.0.5.0, Culture=neutral, " +
            "PublicKeyToken=7cec85d7bea7798e]]\"}}}";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;
            if (value.ToString().Equals(LockedString) && parameter.ToString().Equals("Locked"))
                return true;
            if (value.ToString().Equals(UnlockedString) && parameter.ToString().Equals("Unlocked"))
                return true;
            if (value.ToString().Equals(ExpandedString1) && parameter.ToString().Equals("Expanded"))
                return true;
            if (value.ToString().StartsWith(ExpandedString2.Substring(0, 50)) && parameter.ToString() == "Expanded")
                return true;
            return false;
            //string valueString = value.ToString();
            //string parameterString = parameter.ToString();
            //return valueString.Equals(parameterString);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return null;
            if (!(bool)value)
                return Binding.DoNothing;
            switch (parameter.ToString())
            {
                case "Locked":
                    return LockedString;
                case "Unlocked":
                    return UnlockedString;
                case "Expanded":
                    return ExpandedString2;
            }
            throw new Exception("You done messed up A-A-Ron");
        }
    }

    public class AllPagiesConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Contains(DependencyProperty.UnsetValue))
                return Binding.DoNothing;
            int[] pagieArray = (int[])value[0];
            int count = 0;
            for (int i = 0; i < pagieArray.Length; i++)
            {
                if (pagieArray[i] == 2)
                    count++;
            }
            if (count >= 25)
                return true;
            if (count == 0)
                return false;
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            object[] returnObject = new object[2];
            int[] returnArray = new int[30];
            if ((bool)value)
            {
                for (int i = 0; i < returnArray.Length; i++)
                {
                    returnArray[i] = 2;
                }
                returnObject[0] = returnArray;
                returnObject[1] = 25;
                return returnObject;
            }
            returnObject[0] = returnArray;
            returnObject[1] = 0;
            return returnObject;
        }
    }

    public class AllQuillsConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Contains(DependencyProperty.UnsetValue))
                return Binding.DoNothing;
            int[] quillsArray = (int[])value[0];
            int count = 0;
            for (int i = 0; i < quillsArray.Length; i++)
            {
                if (quillsArray[i] == 1)
                    count++;
            }
            if (count >= 200)
                return true;
            if (count == 0)
                return false;
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            object[] returnObject = new object[2];
            int[] returnArray = new int[200];
            if ((bool)value)
            {
                for (int i = 0; i < returnArray.Length; i++)
                {
                    returnArray[i] = 1;
                }
                returnObject[0] = returnArray;
                returnObject[1] = 200;
                return returnObject;
            }
            returnObject[0] = returnArray;
            returnObject[1] = 0;
            return returnObject;
        }
    }

    public class AllHivoryPagiesConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Contains(DependencyProperty.UnsetValue))
                return Binding.DoNothing;
            int[] pagieArray = (int[])value[0];
            int count = 0;
            for (int i = 0; i < pagieArray.Length; i++)
            {
                if (pagieArray[i] == 2)
                    count++;
            }
            if (count >= 20)
                return true;
            if (count == 0)
                return false;
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            object[] returnObject = new object[2];
            int[] returnArray = new int[30];
            if ((bool)value)
            {
                for (int i = 0; i < returnArray.Length; i++)
                {
                    returnArray[i] = 2;
                }
                returnObject[0] = returnArray;
                returnObject[1] = 20;
                return returnObject;
            }
            returnObject[0] = returnArray;
            returnObject[1] = 0;
            return returnObject;
        }
    }

    public class AllHivoryQuillsConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Contains(DependencyProperty.UnsetValue))
                return Binding.DoNothing;
            int[] quillsArray = (int[])value[0];
            int count = 0;
            for (int i = 0; i < quillsArray.Length; i++)
            {
                if (quillsArray[i] == 1)
                    count++;
            }
            if (count >= 10)
                return true;
            if (count == 0)
                return false;
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            object[] returnObject = new object[2];
            int[] returnArray = new int[10];
            if ((bool)value)
            {
                for (int i = 0; i < returnArray.Length; i++)
                {
                    returnArray[i] = 1;
                }
                returnObject[0] = returnArray;
                returnObject[1] = 10;
                return returnObject;
            }
            returnObject[0] = returnArray;
            returnObject[1] = 0;
            return returnObject;
        }
    }

    public class AllCasinoChipsConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Contains(DependencyProperty.UnsetValue))
                return Binding.DoNothing;
            int[] casinochipsArray = (int[])value[0];
            int count = 0;
            for (int i = 0; i < casinochipsArray.Length; i++)
            {
                if (casinochipsArray[i] == 2)
                    count++;
            }
            if (count >= 190)
                return true;
            if (count == 0)
                return false;
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            object[] returnObject = new object[2];
            int[] returnArray = new int[190];
            if ((bool)value)
            {
                for (int i = 0; i < returnArray.Length; i++)
                {
                    returnArray[i] = 2;
                }
                returnObject[0] = returnArray;
                returnObject[1] = 190;
                return returnObject;
            }
            returnObject[0] = returnArray;
            returnObject[1] = 0;
            return returnObject;
        }
    }

    public class AllGhostwritersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int[] valueArray = ((int[])value);
            int count = 0;
            for (int i = 0; i < valueArray.Length; i++)
            {
                if (valueArray[i] == 2)
                    count++;
            }
            if (count >= 5)
                return true;
            if (count == 0)
                return false;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Binding.DoNothing;
            if ((bool)value)
                return new int[5] { 2, 2, 2, 2, 2 };
            return new int[5] { 0, 0, 0, 0, 0 };
        }
    }

    public class SingleCollectibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 2)
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return 2;
            return 0;
        }
    }
}
