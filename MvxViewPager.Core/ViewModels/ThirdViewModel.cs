// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the SecondViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MvxViewPager.Core.ViewModels
{
    using System.Windows.Input;

    /// <summary>
    /// Define the SecondViewModel type.
    /// </summary>
    public class ThirdViewModel : BaseViewModel
    {
        /// <summary>
        /// Backing field for my property.
        /// </summary>
        private string _name = "Third";


        /// <summary>
        /// Gets or sets my property.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this.SetProperty(ref this._name, value, () => this.Name); }
        }

    }
}
