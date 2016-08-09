using DevExpress.Xpf.LayoutControl;
using System.Windows;

using DEVGroupBox = DevExpress.Xpf.LayoutControl.GroupBox;
using DevExpress.Xpf.Core.Native;
using System.Windows.Input;

namespace DIRECTView.Controls.Groups
{
    public class GroupBox : DEVGroupBox
    {

        protected FrameworkElement TitleElement { get; set; }
        public override void OnApplyTemplate()
        {
            if (TitleElement != null) { TitleElement.MouseLeftButtonDown -= OnTitleElementMouseLeftButtonDown; }
            base.OnApplyTemplate();
            TitleElement = LayoutHelper.FindParentObject<LayoutGroup>(GetTemplateChild("MaximizeElement"));
            if (TitleElement != null)
            {
                TitleElement.MouseLeftButtonDown += new MouseButtonEventHandler(OnTitleElementMouseLeftButtonDown);
            }
           
        }
        void OnTitleElementMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (State == GroupBoxState.Normal) State = GroupBoxState.Minimized;
            else State = GroupBoxState.Normal;
        }
    }

}
