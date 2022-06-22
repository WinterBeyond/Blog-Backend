using System.Text.RegularExpressions;

namespace BlogBackend.Utils
{
    /// <summary>
    /// Utility tools related to hex.
    /// </summary>
    public class HexUtil
    {
        /// <summary>
        /// Check if the string is a hex.
        /// </summary>
        /// <param name="text">The string to check.</param>
        public static bool IsHex(string? text)
        {
            if (text == null)
                return false;

            return Regex.IsMatch(text, @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
}
