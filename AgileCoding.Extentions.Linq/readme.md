AgileCoding.Extentions.Linq
===========================

Description
-----------

This is a .NET 6.0 NuGet package that provides various useful extensions to LINQ. The extensions are added in the `AgileCoding.Extentions.Linq` namespace and offer powerful tools to manipulate data structures.

Key Features
------------

Here are some key methods provided by this library:

1.  `TakeTop<TSource>(this List<TSource> source)`: An extension method on `List<TSource>` to take and remove the top element from the list.

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
int top = numbers.TakeTop();  // Returns 1 and removes it from the list.
```

2.  `Single<TSource>(this IEnumerable<TSource> source, string noElementsMessage = "NoElements", string moreThanOneMatchMessage = "MoreThanOneMatch")`: Overloads of `Single` method with additional parameters for providing custom error messages.

```csharp
List<int> numbers = new List<int> { 1 };
int single = numbers.Single("No elements found", "More than one match found");  // Returns 1 if the list has exactly one element, otherwise throws exception with specified error message.
```

3.  `SingleOrDefault<TSource>(this IEnumerable<TSource> source, string moreThanOneMatchMessage = "MoreThanOneMatch")`: Overloads of `SingleOrDefault` method with additional parameters for providing custom error messages.

```csharp
List<int> numbers = new List<int> { 1 };
int singleOrDefault = numbers.SingleOrDefault("More than one match found");  // Returns 1 if the list has exactly one element, null if no elements, otherwise throws exception with specified error message.
```

4.  `First<TSource, TNoElementsExceptionType>(this IEnumerable<TSource> source, string noElementsMessage = "NoElements")`: Overloads of `First` method with additional parameters for providing custom error messages.

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
int first = numbers.First<InvalidOperationException>("No elements found");  // Returns 1 if the list has at least one element, otherwise throws exception with specified error message.
```

Installation
------------

To install this package, you can use the .NET CLI and type:

`dotnet add package AgileCoding.Extentions.Linq --version 2.0.5`

Usage
-----

First, include the namespace in your file:

`using AgileCoding.Extentions.Linq;`

Then, use the methods as per your requirements with the examples provided above.

Documentation
-------------

For more detailed usage instructions, please visit the project's [Wiki page](https://github.com/ToolMaker/AgileCoding.Extentions.Linq/wiki).

Contributing
------------

This project is open-source and hosted on GitHub. Contributions are welcome. To contribute, please visit the [repository](https://github.com/ToolMaker/AgileCoding.Extentions.Linq).

License
-------

This project is licensed under the terms mentioned in the LICENSE file at the root of the repository. Please make sure you comply with the terms before using it in your projects.

Release Notes
-------------

The current version of the package is 2.0.5. For detailed release notes, please check out the repository.

Contact
-------

The package is maintained by Ernie Gunning. If you have any questions or suggestions, please feel free to reach out.