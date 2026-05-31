# End-to-End Test Structure

This project contains end to end tests for the workflow of opening a template file, making modifications to it and saving it at an output location using the EPPlus library. To automate the testing of such workflows and avoid checking in a number of template files, the template files are also dynamically generated. There might be specific exceptions where EPPlus does not have the features required to generate the template. For normal cases, each test class follows this pattern:

- The class derives from `TestsBase`. The name of the class should not include the word `Test` or `Tests`.
- It has a `[ClassInitialize]public static void Initialize(TestContext context)` method that calls `SaveTemplate` from the base class to save a template file used by all test methods in the class. Each class should create templates with unique names (<class_name>.xlsx is a good default).
- Each test method calls `Test` from the base class and provides file names and two delegates. The template file name should match the name of the template created in `Initialize`. The output file name should be unique across all test methods (<class_name>.<method_name>.xlsx is a good default)
	- The first delegate receives an `ExcelPackage` that represents the template file. It is supposed to write sheets, cell values, charts, pivot tables, etc into this package. After this delegate returns, the `Test` method saves the package with the provided file name, reopens it into a new package and passes the new package to the second delegate
	- The second delegate should have assertions to verify that the `ExcelPackage` it receives contains whatever it is supposed to.
- The templates and outputs (from the first delegate to `Test`) are persisted in `Templates` and `Outputs` directories in the project root so that they can be manually opened for inspection. These files are not checked in.

Illustrative code for test cases:
```cs
[TestClass]
public class SomeFeature : TestsBase
{
    static string template = "SomeFeature.xlsx";

    [ClassInitialize]
    public static void Initialize(TestContext context)
    {
        SaveTemplate(template, package =>
        {
            // Modify the template package here
        });
    }

    [TestMethod]
    public void Variant1()
    {
        Test(template, null, "SomeFeature.Variant1.xlsx", null, package =>
        {
            // Modify 
        }, package =>
        {
            // Assert
        });
    }

    // Add more test methods
}
```
