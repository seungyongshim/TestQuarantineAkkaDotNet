using System;
using System.Text;

namespace MessageClassLibrary
{
    public class Msg
    {
        public Msg(int v)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < v; i++)
            {
                sb.Append(i.ToString());
            }
            Content = sb.ToString();

        }

        public string Content { get; }
    }
}
