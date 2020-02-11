﻿using Lexica.Compositional.Interface;
using Lexica.Compositional.Lexigrams.Interface;
using Lexica.Parsing;

namespace Lexica.Compositional.Lexigrams
{
    public class CodeLexigram : IIdLexigram
    {
        public string Id { get; set; }
        public string Code { get; set; }

        public CodeLexigram(string id, string code)
        {
            Id = id;
            Code = code;
        }

        /// <summary>
        /// Retrieves the value with the given <see cref="Id"/> if possible. Otherwise evaluates the <see cref="Code"/>.
        /// </summary>
        /// <param name="engine">Engine to execute code against</param>
        /// <returns>The value from evaluation of the <see cref="Code"/></returns>
        public object GetValue(ICompositionEngine engine)
        {
            if (Id != null)
            {
                var value = engine.Execute(Id);
                if (value != null)
                    return value;
            }
            var rawCode = Code;
            
            if (engine.ShouldConvertTimeMarks())
                rawCode = new TimeConverter().ReplaceTimespans(rawCode);

            return engine.Execute(rawCode);
        }


        public static explicit operator CodeLexigram(string code) => new CodeLexigram(null, code);

        public override string ToString() => $"`{Code}`{(Id != null ? $"({Id})" : "")}";
    }
}
