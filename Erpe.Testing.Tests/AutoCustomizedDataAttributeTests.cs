// Copyright (c) Frank Hambach. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Erpe.Testing.Tests;

using Erpe.Testing;

using FluentAssertions;

using NSubstitute;

using NUnit.Framework;

public class AutoCustomizedDataAttributeTests
{
    [Test]
    [AutoCustomizedData]
    public void AutoCustomizedDataAttribute_ShouldCreateValuesUsingCustomizations_WhenUsedOnTestMethod(TestUser user)
    {
        user.Name.Should().Be("Default Name");
    }

    [Test]
    [AutoCustomizedData]
    public void AutoCustomizedDataAttribute_ShouldMockValuesUsingNSubstitute_WhenUsedOnTestMethod(ITestService service)
    {
        const string expectedValue = "Custom Name";
        service.GetName().Returns(expectedValue);

        string result = service.GetName();

        result.Should().Be(expectedValue);
    }
}