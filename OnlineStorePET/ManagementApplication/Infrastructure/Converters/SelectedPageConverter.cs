using ManagementApplication.MVVM.Views.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace ManagementApplication.Infrastructure.Converters
{
    public class SelectedPageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Page selectedPage = value as Page ?? throw new ArgumentException(nameof(value));

            string color = "Transparent";
            switch (parameter as string)
            {
                case "Create":
                    if (selectedPage is CreatePage)
                    {
                        color = "#499dde";
                    }
                    break;
                case "Clothes":
                    if (selectedPage is ClothesPage)
                    {
                        color = "#2f8fda";
                    }
                    break;
                case "Shoes":
                    if (selectedPage is ShoesPage)
                    {
                        color = "#2f8fda";
                    }
                    break;
                default:
                    throw new ArgumentException(nameof(parameter));
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
