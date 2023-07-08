using System;
#pragma warning disable

namespace Anagrams
{
    public class Anagram
    {
        public string source;
        /// <summary>
        /// Initializes a new instance of the <see cref="Anagram"/> class.
        /// </summary>
        /// <param name="sourceWord">Source word.</param>
        /// <exception cref="ArgumentNullException">Thrown when source word is null.</exception>
        /// <exception cref="ArgumentException">Thrown when  source word is empty.</exception>
        public Anagram(string? sourceWord)
        {
            if (sourceWord is null)
            {
                throw new ArgumentNullException("Source cannot be null.");
            }

            if (sourceWord.Length == 0)
            {
                throw new ArgumentException("Source cannot be empty.");
            }

            int upperCount = 0;
            for (int i = 0; i < sourceWord.Length; i++)
            {
                if (char.IsUpper(sourceWord[i]))
                {
                    upperCount++;
                }
            }

            if (upperCount == sourceWord.Length)
            {
                this.source = string.Empty;
                return;
            }

            this.source = sourceWord;
        }

        private bool IsAnagram(string word)
        {
            if (word.Length != this.source.Length)
                return false;

            if (this.source.Length == 0)
            {
                return false;
            }

            int[] charCount = new int[26];
            for (int i = 0; i < 26; i++)
            {
                charCount[i] = 0;
            }

            foreach (char c in word)
            {
                charCount[char.ToLower(c) - 'a']++;
            }

            foreach (char c in this.source)
            {
                charCount[char.ToLower(c) - 'a']--;
            }

            foreach (int count in charCount)
            {
                if (count != 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// From the list of possible anagrams selects the correct subset.
        /// </summary>
        /// <param name="candidates">A list of possible anagrams.</param>
        /// <returns>The correct sublist of anagrams.</returns>
        /// <exception cref="ArgumentNullException">Thrown when candidates list is null.</exception>
        public string[] FindAnagrams(string[]? candidates)
        {
            if (candidates is null)
            {
                throw new ArgumentNullException("Source cannot be null.");
            }

            string[] arr = Array.Empty<string>();
            for (int i = 0; i < candidates.Length; i++)
            {
                if (IsAnagram(candidates[i]))
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = candidates[i];
                }
            }

            return arr;
        }
    }
}
