// Copyright (c) Frank Hambach. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Erpe.Testing.Tests;

using AutoFixture.AutoNSubstitute;

using FluentAssertions;

using NSubstitute;

using NUnit.Framework;

public class InlineAutoCustomizedDataAttributeTests
{
    [Test]
    [InlineAutoCustomizedData(42)]
    public void
        InlineAutoCustomizedDataAttribute_ShouldUseInlineDataAndCreateValuesUsingCustomizations_WhenUsedOnTestMethod(
            int number,
            TestUser user)
    {
        number.Should().Be(42);
        user.Name.Should().Be("Default Name");
    }

    [Test]
    [InlineAutoCustomizedData("Custom Name")]
    public void InlineAutoCustomizedData_ShouldUseInlineDataAndMockValuesUsingNSubstitute_WhenUsedOnTestMethod(
        string expectedName,
        [Substitute] ITestService service)
    {
        service.GetName().Returns(expectedName);

        string result = service.GetName();

        result.Should().Be(expectedName);
    }
}