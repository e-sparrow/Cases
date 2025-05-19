using System;
using System.Collections.Generic;
using Birdhouse.Cases.Enums;
using Birdhouse.Tools.Strings.Abstractions;
using Cyriller.Model;

namespace Birdhouse.Cases
{
    public sealed class DeclineTag
        : ITag
    {
        private const string CaseName = "case";
        
        public string Process(string input, IDictionary<string, string> parameters = null)
        {
            var hasCase = parameters.TryGetValue(CaseName, out var @case);
            if (!hasCase)
            {
                return input;
            }

            var canParse = Enum.TryParse<ERussianCase>(@case, out var parsedCase);
            if (!canParse)
            {
                return input;
            }

            var result = input.As(parsedCase);
            return result;
        }
    }
}