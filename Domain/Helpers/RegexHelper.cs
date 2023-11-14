using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APS8_CSHARP_API.Domain.Helpers
{
    public static partial class RegexHelper
    {
        [GeneratedRegex("[^0-9]")]
        public static partial Regex GetNumberRegex();
    }
}