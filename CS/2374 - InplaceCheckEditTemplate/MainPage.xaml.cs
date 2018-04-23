using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core.WPFCompatibility;
using System.Windows.Data;

namespace _2374___InplaceCheckEditTemplate {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }
    }

    public class BoolToYesNoConverter : IValueConverter {

        #region IValueConverter Members

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return (bool)value ? "Yes" : "No";
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
