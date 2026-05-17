using Xunit;
using ProjectMod1DevOps.Utils;
public class ValidatorTests
{
    [Fact]
    public void ShortPassword_ShouldReturnFalse()
    {
        var validator = new PasswordValidator();
        var result = validator.IsValid("123");
        Assert.False(result);
    }
}
