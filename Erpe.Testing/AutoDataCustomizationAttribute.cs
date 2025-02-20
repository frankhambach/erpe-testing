// Copyright (c) Frank Hambach. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Erpe.Testing;

using System;

using JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Class)]
[MeansImplicitUse]
public sealed class AutoDataCustomizationAttribute() : Attribute;