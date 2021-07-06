using FluentAssertions;
using NUnit.Framework;

namespace Misc.Tests
{
    [TestFixture]
    public class AnagramUtilTests
    {
        [Test]
        public void when_two_strings_have_different_size_then_false_is_returned()
        {
            // Arrange:
            var str1 = "aabbb";
            var str2 = "ab";

            // Act:
            var anagramUtil = new AnagramUtil();
            var result = anagramUtil.AreAnagrams(str1, str2);

            // Assert:
            result.Should().BeFalse();
        }

        [TestCase("", "aaa")]
        [TestCase("  ", "aa")]
        [TestCase("  \t\n", "aaa")]
        [TestCase("aaaa", " ")]
        [TestCase("  \t\n", "   s")]
        public void when_at_least_one_of_strings_is_null_or_empty_then_false_is_returned(string str1, string str2)
        {
            // Act:
            var anagramUtil = new AnagramUtil();
            var result = anagramUtil.AreAnagrams(str1, str2);

            // Assert:
            result.Should().BeFalse();
        }

        [Test]
        public void when_strings_contain_the_same_num_of_chars_but_they_differ_then_false_is_returned()
        {
            // Arrange:
            var str1 = "abac";
            var str2 = "abab";

            // Act:
            var anagramUtil = new AnagramUtil();
            var result = anagramUtil.AreAnagrams(str1, str2);

            // Assert:
            result.Should().BeFalse();
        }

        [Test]
        public void when_strings_contain_no_white_chars_and_have_same_chars_then_true_is_returned()
        {
            // Arrange:
            var str1 = "aabb";
            var str2 = "abab";

            // Act:
            var anagramUtil = new AnagramUtil();
            var result = anagramUtil.AreAnagrams(str1, str2);

            // Assert:
            result.Should().BeTrue();
        }

        [TestCase("aabb", "a b \t\t b a")]
        [TestCase("bba\ta", "abab")]
        public void when_strings_contain_white_chars_but_other_chars_are_equal_then_true_is_returned(string str1, string str2)
        {
            // Act:
            var anagramUtil = new AnagramUtil();
            var result = anagramUtil.AreAnagrams(str1, str2);

            // Assert:
            result.Should().BeTrue();
        }
    }
}