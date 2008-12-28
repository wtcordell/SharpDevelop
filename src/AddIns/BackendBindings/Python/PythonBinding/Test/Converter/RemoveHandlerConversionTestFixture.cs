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
	/// Tests that removing a method from an event handler is converted
	/// from C# to Python correctly.
	/// </summary>
	[TestFixture]
	public class RemoveHandlerConversionTestFixture
	{
		string csharp = "class Foo\r\n" +
						"{\r\n" +
						"\tpublic Foo()\r\n" +
						"\t{" +
						"\t\tbutton = new Button();\r\n" +
						"\t\tbutton.Click -= ButtonClick;\r\n" +
						"\t}\r\n" +
						"\r\n" +
						"\tvoid ButtonClick(object sender, EventArgs e)\r\n" +
						"\t{\r\n" +
						"\t}\r\n" +
						"}";
		
		[Test]
		public void ConvertedPythonCode()
		{
			string expectedCode = "class Foo(object):\r\n" +
									"\tdef __init__(self):\r\n" +
									"\t\tbutton = Button()\r\n" +
									"\t\tbutton.Click -= ButtonClick\r\n" +
									"\r\n" +
									"\tdef ButtonClick(self, sender, e):\r\n" +
									"\t\tpass";
			CSharpToPythonConverter converter = new CSharpToPythonConverter();
			string code = converter.Convert(csharp);
			
			Assert.AreEqual(expectedCode, code);
		}	
	}
}
