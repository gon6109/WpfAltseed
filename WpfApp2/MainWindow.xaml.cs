using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            altseed.Child = new System.Windows.Forms.Control();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // 図形描画オブジェクトのインスタンスを生成する。
            var geometryObj = new asd.GeometryObject2D();

            // 図形描画オブジェクトのインスタンスをエンジンに追加する。
            asd.Engine.AddObject2D(geometryObj);

            // 円の図形クラスのインスタンスを生成する。
            var arc = new asd.CircleShape();

            // 円の外径、中心位置を指定する。
            arc.OuterDiameter = 400;
            arc.Position = new asd.Vector2DF(320, 240);

            // 円を描画する図形として設定する。
            geometryObj.Shape = arc;
        }

        public void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(ExitFrames), frame);
            Dispatcher.PushFrame(frame);
        }

        public object ExitFrames(object f)
        {
            ((DispatcherFrame)f).Continue = false;

            return null;
        }
    }
}
