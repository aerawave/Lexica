﻿using Lexica.Compositional.Interface;
using Lexica.Compositional.Lexigrams.Interface;

namespace Lexica.Compositional.Lexigrams
{
    public class Lexigram : ILexigram
    {
        public string Value { get; set; }

        public Lexigram(string value)
        {
            Value = value;
        }

        public object GetValue(ICompositionEngine engine)
            => Value;

        public static implicit operator Lexigram(string value) => new Lexigram(value);
        public static implicit operator string(Lexigram token) => token.Value;

        public override string ToString() => Value;
    }
}
