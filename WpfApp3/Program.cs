using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    static class Program
    {
        static asd.TextObject2D obj;
        [STAThread]
        static void Main(string[] args)
        {
            // 外部のウィンドウを作成する。
            bool closed = false;
            MainWindow window = new MainWindow();
            window.Closed += (sender, e) =>
            {
                closed = true;
            };
            window.Show();

            // 外部のウィンドウを利用してAltseedを初期化する。
            asd.Engine.InitializeByExternalWindow(window.altseed.Child.Handle, System.IntPtr.Zero, (int)window.altseed.RenderSize.Width, (int)window.altseed.RenderSize.Height, new asd.EngineOption());

            // フォントを生成する。
            var font = asd.Engine.Graphics.CreateDynamicFont("", 30, new asd.Color(255,255,255),0,new asd.Color());

            // 文字描画オブジェクトを生成する。
            obj = new asd.TextObject2D();

            // 描画に使うフォントを設定する。
            obj.Font = font;

            // 描画位置を指定する。
            obj.Position = new asd.Vector2DF(100, 100);

            // 描画する文字列を指定する。
            obj.Text = "普通の文字列描画";

            // 文字描画オブジェクトのインスタンスをエンジンへ追加する。
            asd.Engine.AddObject2D(obj);

            window.DataContext = obj;

            float count = 0;
            while (asd.Engine.DoEvents())
            {
                // 外部のウィンドウの処理を進める。
                window.DoEvents();
                // 外部のウィンドウが閉じられたらAltseed用のゲームループも抜ける。
                if (closed)
                {
                    break;
                }

                obj.Color = new asd.Color((byte)((Math.Sin(count) + 1) * 128), (byte)((Math.Sin(count) + 1) * 128), (byte)((Math.Sin(count) + 1) * 128));
                count += 0.1f;
                asd.Engine.Update();
            }

            asd.Engine.Terminate();
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
