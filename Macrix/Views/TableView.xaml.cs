using Macrix.ViewModels;

namespace Macrix.Views
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    public partial class TableView
    {
        public TableView()
        {
            InitializeComponent();
            DataContext = new TableViewModel();
        }
    }
}
