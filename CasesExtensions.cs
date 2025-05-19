using Birdhouse.Cases.Enums;
using Birdhouse.Common.Exceptions;
using Cyriller.Model;
using LingvoNET;

namespace Birdhouse.Cases
{
    public static class CaseExtensions
    {
        public static string As(this string self, ERussianCase @case, EDeclineMethod method = EDeclineMethod.LingvoNet)
        {
            var value = CyrillerHelper
                .MainNounCollection
                .Value
                .Get(self, out _, out _)
                .Decline();
            switch (method)
            {
                case EDeclineMethod.Cyriller:
                    switch ((CasesEnum) @case)
                    {
                        case CasesEnum.Nominative:
                            return value.Nominative;
                        case CasesEnum.Genitive:
                            return value.Genitive;
                        case CasesEnum.Dative:
                            return value.Dative;
                        case CasesEnum.Accusative:
                            return value.Accusative;
                        case CasesEnum.Instrumental:
                            return value.Instrumental;
                        case CasesEnum.Prepositional:
                            return value.Prepositional;
                    }

                    break;
                
                case EDeclineMethod.LingvoNet:
                    var noun = Nouns.FindSimilar(self);
                    return noun[(Case) @case];
            }

            throw new WtfException($"Can't decline a word {self} to case {@case.ToString()}");
        }
    }
}