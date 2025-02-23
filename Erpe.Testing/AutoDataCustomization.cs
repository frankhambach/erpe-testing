// Copyright (c) Frank Hambach. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Erpe.Testing;

using System;
using System.Linq;

using AutoFixture;

public class AutoDataCustomization() : CompositeCustomization(
    AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(assembly => assembly.GetTypes())
        .Where(
            type => typeof(ICustomization).IsAssignableFrom(type)
                && type.GetCustomAttributes(typeof(AutoDataCustomizationAttribute), true).Length > 0)
        .Select(type => Activator.CreateInstance(type) as ICustomization));