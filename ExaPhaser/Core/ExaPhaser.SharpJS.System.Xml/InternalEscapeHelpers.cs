using System;
using System.Runtime.CompilerServices;
using JSIL;
using Microsoft.CSharp.RuntimeBinder;


internal static class InternalEscapeHelpers
{
	
	public static string EscapeXml(string str)
	{
		return (string)Verbatim.Expression("str.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/\"/g, '&quot;').replace(/'/g, '&apos;')");
	}

	
	public static string UnescapeXml(string str)
	{
		return (string)Verbatim.Expression("str.replace(/&apos;/g, \"'\").replace(/&quot;/g, '\"').replace(/&gt;/g, '>').replace(/&lt;/g, '<').replace(/&amp;/g, '&')");
	}
}
