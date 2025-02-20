// Copyright (c) Frank Hambach. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Erpe.Testing.Tests;

using FluentAssertions;

using NUnit.Framework;

public class AutoDataCustomizationAttributeTests
{
    [Test]
    [AutoCustomizedData]
    public void AutoDataCustomizationAttribute_ShouldApplyCustomizationOnFixture_WhenUsedOnCustomizationType(
        TestUser user)
    {
        user.Name.Should().Be("Default Name");
    }

    [Test]
    [AutoCustomizedData]
    public void AutoDataCustomizationAttribute_ShouldNotAffectOtherTypes_WhenUsedOnCustomizationType(
        string randomString)
    {
        randomString.Should().NotBe("Default Name");
    }
}