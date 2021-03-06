﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    static class Program
    {
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

            while (asd.Engine.DoEvents())
            {
                // 外部のウィンドウの処理を進める。
                window.DoEvents();
                // 外部のウィンドウが閉じられたらAltseed用のゲームループも抜ける。
                if (closed)
                {
                    break;
                }

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
