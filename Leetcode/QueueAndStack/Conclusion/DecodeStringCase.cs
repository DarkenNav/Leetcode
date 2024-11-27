
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Leetcode.QueueAndStack.Conclusion
{
    public class DecodeStringCase 
    {
        public void Case()
        {
            // требует оптимизации, не самое лучшее решение
            // aaabcbc
            var result_0 = DecodeString("3[a]2[bc]");
            // accaccacc
            var result_1 = DecodeString("3[a2[c]]");
            // abcabccdcdcdef
            var result_2 = DecodeString("2[abc]3[cd]ef");
            // aaaaaaaaaabcbc
            var result_3 = DecodeString("10[a]2[bc]");
        }

        private class Visit
        {
            public enum StringType
            {
                Int = 0,
                String,
                OpenBracket,
                CloseBracket
            }

            public string Value { get; private set; }
            public StringType Type { get; private set; }
            
            public Visit(string s)
            {
                Value = s;
                Type = GetType(s);
            }

            public static StringType GetType(string s)
            {
                if (int.TryParse(s, out var n))
                {
                    return StringType.Int;
                }
                else if (s == "[")
                {
                    return StringType.OpenBracket;
                }
                else if (s == "]")
                {
                    return StringType.CloseBracket;
                }
                return StringType.String;
            }

            public void Append(string s)
            {
                var type = GetType(s);
                if(type == StringType.Int || type == StringType.String)
                {
                    Value += s;
                }
            }

            public void Prepend(string s)
            {
                var type = GetType(s);
                if (type == StringType.Int || type == StringType.String)
                {
                    Value = s + Value;
                }
            }

            public void RepeatAndSet(string n)
            {
                int count = int.Parse(n.ToString());
                var result = new StringBuilder();
                for (var i = 0; i < count; i++)
                {
                    result.Append(Value);
                }
                Value = result.ToString();
            }
        }

        public string DecodeString(string s)
        {
            var stack = new Stack<Visit>();
            stack.Push(new Visit(s[..1]));
            for (var i = 1; i < s.Length; i++)
            {
                var visit = stack.Peek();
                var next = new Visit(s[i..(i+1)]);
                if(visit.Type == next.Type)
                {
                    visit.Append(next.Value);
                }
                else
                {
                    if(next.Type == Visit.StringType.CloseBracket)
                    {
                        // from second "["
                        var skip = true;
                        var accu = stack.Pop();
                        while(stack.Count() > 0)
                        {
                            var prev = stack.Peek();
                            if(prev.Type == Visit.StringType.OpenBracket)
                            {
                                if (skip)                          
                                    skip = false;
                                else
                                    break;
                            }
                            else if(prev.Type == Visit.StringType.Int)
                            {
                                accu.RepeatAndSet(prev.Value);
                            }
                            else
                            {
                                accu.Prepend(prev.Value);
                            }
                            stack.Pop();
                        }
                        stack.Push(accu);
                    }
                    else
                        stack.Push(next);
                }
            }
            return stack.Pop().Value;
        }
    }
}
