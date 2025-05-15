using System;
using System.Collections.Generic;
using Birdhouse.Tools.Strings.Abstractions;
using Cyriller.Model;

namespace Birdhouse.Features.Cases
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

            var canParse = Enum.TryParse<CasesEnum>(@case, out var parsedCase);
            if (!canParse)
            {
                return input;
            }

            var result = input.As(parsedCase);
            return result;
        }
    }
}