// Copyright (c) Frank Hambach. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Erpe.Testing;

using System;

using AutoFixture;
using AutoFixture.AutoNSubstitute;

[AttributeUsage(AttributeTargets.Method)]
public sealed class AutoCustomizedDataAttribute() : AutoFixture.NUnit3.AutoDataAttribute(
    () => new Fixture().Customize(
            new AutoNSubstituteCustomization
                {
                    ConfigureMembers = true,
                })
        .Customize(new AutoDataCustomization()));