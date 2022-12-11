## Еxtension instruction

*Еxtension examples can be found in TestUnitConverter/CustomCategoryConverterTest.cs and TestUnitConverter/CustomUnitConverterTest.cs*

**To add new category of units converter (e.g. volume)**
1. Create a class inherited from abstract class BaseCategoryConverter
2. Add specific converters to Converters dictionary in constructor or with method AddCustomCategoryConverter/AddConverter

**To add new specific converter (e.g. liter, cubicinch, pint)**
1. Use AddCustomCategoryConverter/AddConverter method
