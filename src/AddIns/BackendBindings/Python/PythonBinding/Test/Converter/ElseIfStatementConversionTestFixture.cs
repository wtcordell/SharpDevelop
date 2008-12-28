﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using ICSharpCode.PythonBinding;
using NUnit.Framework;

namespace PythonBinding.Tests.Converter
{
	/// <summary>
	/// Converts a C# else if statement to Python's elif.
	/// </summary>
	[TestFixture]
	public class ElseIfStatementConversionTestFixture
	{
		string csharp = "class Foo\r\n" +
						"{\r\n" +
						"\tpublic int GetCount(i)\r\n" +
						"\t{" +
						"\t\tif (i == 0) {\r\n" +
						"\t\t\treturn 10;\r\n" +
						"\t\t} else if (i < 1){\r\n" +
						"\t\t\treturn 4;\r\n" +
						"\t\t}\r\n" +
						"\t\treturn 2;\r\n" +
						"\t}\r\n" +
						"}";
						
		[Test]
		public void ConvertedPythonCode()
		{
			CSharpToPythonConverter converter = new CSharpToPythonConverter();
			string python = converter.Convert(csharp);
			string expectedPython = "class Foo(object):\r\n" +
									"\tdef GetCount(self, i):\r\n" +
									"\t\tif i == 0:\r\n" +
									"\t\t\treturn 10\r\n" +
									"\t\telif i < 1:\r\n" +
									"\t\t\treturn 4\r\n" +
									"\t\treturn 2";
			
			Assert.AreEqual(expectedPython, python);
		}
	}
}
