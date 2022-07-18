using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using DotLiquid;
using DotLiquid.Exceptions;

namespace GoldArch.DotLiquidTest.Tags
{
    /// <summary>
    /// Increments a computed value
    /// </summary>
    public class Increment : Tag
    {
        private string _variable;

        /// <summary>
        /// Initializes the increment tag and ensures the syntax is correct
        /// </summary>
        /// <param name="tagName">The tag name (should be <pre>increment</pre>)</param>
        /// <param name="markup">Markup of the parsed tag</param>
        /// <param name="tokens">Tokens of the parsed tag</param>
        /// <exception cref="SyntaxException">If the increment tag is malformed</exception>
        public override void Initialize(string tagName, string markup, List<string> tokens)
        {
            Match syntaxMatch = LiquidExt.VariableSegmentRegex.Match(markup);
            if (syntaxMatch.Success)
            {
                _variable = syntaxMatch.Groups["Variable"].Value;
            }
            else
            {
                //throw new SyntaxException(Liquid.ResourceManager.GetString("IncrementSyntaxException"));
                throw new SyntaxException("'increment' 标记中的语法错误 - 有效语法：increment[var]");

                //< data name = "IncrementSyntaxException" xml: space = "preserve" >
                //    < value > Syntax Error in 'increment' tag - Valid syntax: increment[var] </ value >
                //</ data >
            }

            base.Initialize(tagName, markup, tokens);
        }

        /// <summary>
        /// Renders the incremented value
        /// </summary>
        /// <param name="context">The current context</param>
        /// <param name="result">The output buffer containing the currently rendered template</param>
        public override void Render(Context context, TextWriter result)
        {
            Increment32(context, result, context.Environments[0].TryGetValue(_variable, out var counterObj) ? counterObj : 0);
            base.Render(context, result);
        }

        private void Increment32(Context context, TextWriter result, object current)
        {
            try
            {
                checked
                { //needed to force OverflowException at runtime
                    var counter = Convert.ToInt32(current);
                    context.Environments[0][_variable] = counter + 1;
                    result.Write(counter);
                }
            }
            catch (OverflowException)
            {
                Increment64(context, result, current);
            }
        }

        private void Increment64(Context context, TextWriter result, object current)
        {
            var counter = Convert.ToInt64(current);
            context.Environments[0][_variable] = counter + 1;
            result.Write(counter);
        }
    }
}
