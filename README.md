# Erpe.**Testing**

**Erpe.Testing** is a NuGet metapackage designed for use in my personal projects, bundling essential unit testing libraries, analyzers, and custom attributes to streamline testing across projects.

## Included Testing Libraries

The following libraries are bundled in **Erpe.Testing**:

- [**NUnit**](https://nunit.org/): A widely used testing framework for .NET.
- [**NSubstitute**](https://nsubstitute.github.io/): A friendly substitute library for creating mocks, stubs, and test doubles in unit tests.
- [**AutoFixture**](https://github.com/AutoFixture/AutoFixture): Automatically generates data for tests to keep them focused on logic rather than setup.
- [**Bogus**](https://github.com/bchavez/Bogus): Generates realistic fake data to help make tests more meaningful and robust.
- [**FluentAssertions**](https://fluentassertions.com/): Adds a fluent syntax for assertions, making test code more readable and expressive.

## Custom Attributes

The **Erpe.Testing** package extends the functionality of AutoFixture by introducing custom attributes designed to simplify customization of test specimen creation. These attributes make it easier to apply project-specific customizations to your test data.

### AutoDataCustomizationAttribute

**`AutoDataCustomizationAttribute`** can be applied to any class implementing `ICustomization`. When marked with this attribute, customizations will be automatically applied by both `AutoCustomizedDataAttribute` and `InlineAutoCustomizedDataAttribute`. This allows for project-wide configurations, such as specific default values for properties, to be easily reused across multiple tests without having to manually extend AutoFixture's `AutoDataAttribute` and `InlineAutoDataAttribute` in each test project.

```csharp
using AutoFixture;
using Erpe.Testing;

[AutoDataCustomization]
public class StringCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Register(() => "Custom Value");
    }
}
```

### AutoCustomizedDataAttribute & InlineAutoCustomizedDataAttribute

**`AutoCustomizedDataAttribute`** and **`InlineAutoCustomizedDataAttribute`** extend AutoFixture’s `AutoDataAttribute` and `InlineAutoDataAttribute`. They include `AutoNSubstituteCustomization` by default, allowing for automatic generation of substitute instances. Additionally, these attributes apply any customizations marked with `AutoDataCustomizationAttribute`. This enables a flexible setup where any project-specific customizations can be added to the fixture without having to manually define additional attributes.

```csharp
using Erpe.Testing;
using FluentAssertions;
using NUnit.Framework;

public class ExampleTests
{
    [Test]
    [AutoCustomizedData]
    public void Test_StringCustomization(string value)
    {
        value.Should().Be("Custom Value");
    }

    [Test]
    [InlineAutoCustomizedData(42)]
    public void Test_StringCustomizationWithInlineData(int number, string value)
    {
        number.Should().Be(42);
        value.Should().Be("Custom Value");
    }
}
```

## Included Analyzers

In addition to testing libraries, **Erpe.Testing** bundles the following analyzers to ensure high-quality, consistent test code:

- [**Erpe.Analyzers**](https://github.com/frankhambach/erpe-analyzers): A custom bundle of essential analyzers and style settings that enforce consistent code quality across projects.
- [**FluentAssertions.Analyzers**](https://github.com/fluentassertions/fluentassertions.analyzers): Provides specific analyzers and refactorings for FluentAssertions, helping ensure optimal usage.
- [**NSubstitute.Analyzers.CSharp**](https://github.com/nsubstitute/NSubstitute.Analyzers): Adds analyzers for NSubstitute, enforcing best practices and preventing common mocking issues.

## Code Style and Warning Suppression

**Erpe.Testing** includes a `.globalconfig` configuration file that disables specific warnings in test projects. The following warnings are suppressed to allow for more descriptive test method names and other test-related flexibility:

- **CA1062**: Argument checks are not enforced to streamline unit test setup.
- **CA1303**: Allows literals where necessary in tests.
- **CA1515**: Allows public classes in test projects.
- **CA1707**: Allows underscores in method names to improve readability for test cases.
- **CA1861**: Suppresses efficiency checks specific to tests.
- **S4144**: Allows unused parameters in test data methods.
- **VSTHRD200**: Suppresses threading-related warnings that may be unnecessary in test contexts.

## Installation

To install **Erpe.Testing**, add the following package source to your `nuget.config` file:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="GitHub" value="https://nuget.pkg.github.com/frankhambach/index.json" />
  </packageSources>
</configuration>
```

Then, add Erpe.Testing to your project by running:

```shell
dotnet add package Erpe.Testing
```

## Usage

Once installed, **Erpe.Testing** provides access to the bundled libraries, analyzers, and custom attributes, with no further configuration needed. Simply import the necessary namespaces and start writing unit tests!

## License

This project is licensed under the [MIT License](https://opensource.org/license/mit).

## Contributions

This project is intended for personal use, so contributions are not actively accepted. However, feel free to fork it if you’d like to make custom modifications for your own use.