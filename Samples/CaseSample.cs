using Birdhouse.Tools.Strings;
using UnityEngine;

namespace Birdhouse.Cases.Samples
{
    public sealed class CaseSample
        : MonoBehaviour
    {
        [ContextMenu("Test")]
        private void Test()
        {
            var input = "<decline case=Dative>Женя</decline>";
            var processor = new TagProcessor();
            processor.RegisterTag("decline", new DeclineTag());
            Debug.Log(processor.Process(input));
        }
    }
}