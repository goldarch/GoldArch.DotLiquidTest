using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DotLiquid;
using GoldArch.DotLiquidTest.CustomFilter;
using GoldArch.DotLiquidTest.Tags;

namespace GoldArch.DotLiquidTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LiquidExt.RegisterTag();
            Template.RegisterFilter(typeof(CustomFilters));

            Application.Run(new Form1());
        }
    }
}
