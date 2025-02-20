// Copyright (c) Frank Hambach. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Erpe.Testing.Tests;

using AutoFixture;

[AutoDataCustomization]
public class TestUserCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Register(
            () => new TestUser
                {
                    Name = "Default Name",
                });
    }
}