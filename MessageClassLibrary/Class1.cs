using System;

namespace MessageClassLibrary
{
    public class Msg
    {
        public Msg(string content)
        {
            Content = new string [9,9];
            Content[0, 0] = content;
        }

        public string [,] Content { get; }
    }
}
