using System;
using System.Text.RegularExpressions;
using System.Threading;
using DotLiquid;
using DotLiquid.Util;

namespace GoldArch.DotLiquidTest.Tags
{
    public class LiquidExt
    {
        private static readonly Lazy<Regex> LazyVariableSegmentRegex = new Lazy<Regex>(
            () => R.B(R.Q(@"\A\s*(?<Variable>{0}+)\s*\Z"), Liquid.VariableSegment),
            LazyThreadSafetyMode.ExecutionAndPublication);

        internal static Regex VariableSegmentRegex => LazyVariableSegmentRegex.Value;

        public static void RegisterTag()
        {
            Template.RegisterTag<Increment>("increment");
            Template.RegisterTag<Decrement>("decrement");
        }
    }
}