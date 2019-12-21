using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace memo_taro
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                // TextBoxの文字列削除と、TextBlockの更新を行う
                UpdateTextBlock();
                clearTextBox();
            }
        }

        private void UpdateTextBlock()
        {
            var text = TextBox_Input.Text;
            if (TextBox_Output.Text.Equals(""))
            {
                TextBox_Output.Text = text;
            } else
            {
                TextBox_Output.Text = TextBox_Output.Text + "\n" + text;
            }
            scrollToEnd();
        }

        private void clearTextBox()
        {
            TextBox_Input.Text = "";
        }

        private void scrollToEnd()
        {
            // 詳細は、以下のStackOverflowスレッドを参照のこと
            // https://stackoverflow.com/questions/40114620/uwp-c-sharp-scroll-to-the-bottom-of-textbox
            var grid = (Grid)VisualTreeHelper.GetChild(TextBox_Output, 0);
            for (var i=0; i<= VisualTreeHelper.GetChildrenCount(grid) -1; i++)
            {
                object obj = VisualTreeHelper.GetChild(grid, i);
                if (!(obj is ScrollViewer)) continue;
                ((ScrollViewer)obj).ChangeView(0.0f, ((ScrollViewer)obj).ExtentHeight, 1.0f);
                break;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
