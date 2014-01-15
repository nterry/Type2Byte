Type2Byte
=========

[![Build status](https://ci.appveyor.com/api/projects/status?id=1kikr01m0cg5rpy6)](https://ci.appveyor.com/project/type2byte)&nbsp;&nbsp;&nbsp;&nbsp;[![NuGet version](https://badge.fury.io/nu/Type2Byte.png)](http://badge.fury.io/nu/Type2Byte)

A class for converting managed integral types to byte arrays and vice versa


###But BitConverter already exists! Why use this?

A good question. BitConverter is a great class, but [only works](http://www.mono-project.com/Mono_DataConvert#Problems_with_the_CLI.27s_System.BitConverter) with the Microsoft CLR. it <b><u>does not</u></b> work with Mono.



###But Mono has DataConvert. Couldn't I just check the platform and use the appropriate lib?

To [quote the guys](http://www.mono-project.com/FAQ:_Technical#Mono_Platforms) at Xamarin (the developers and maintainers of Mono):
>Having code that depends on the underlying runtime is considered to be bad coding style, but sometimes such code is necessary to work around runtime bugs...

Indeed, It is bad practice to have platform-specific code and <b>should be avoided</b> wherever possible. This library works with <b>both</b> Mono and the CLR. 

In addition, it should be noted that [Mono.DataConvert](https://raw.github.com/mono/mono/master/mcs/class/corlib/Mono/DataConverter.cs) uses [unsafe](http://msdn.microsoft.com/en-us/library/t2yzs44b.aspx) code. If you use a library that is marked with unsafe code your <i>whole</i> project has to marked as such, and you lose all guarantees that the runtime affords to you. You might as well code it in C at this point...

Besides, do you <i>really</i> want to have more than one dependency for the same thing?



###Ok, sold, But how do I use it?

Good choice! Usage is extremely simple:

    using Type2Byte.BaseConverters;
	
	class Foo
	{
		public void DoSomething()
		{
			//Lets convert some valuetypes to arrays
			long l = T2B.ToBytes(aLong);
			char c = T2B.ToBytes(aChar);
			

			//Lets get some valuetypes from their arrays
			short s = B2T.Get<short>(aByteArray, someOffset);  //The offset is an optional
				int i = B2T.Get<int>(anotherByteArray);	   //parameter and defaults to zero
		}
	}
	
And thats it! All [integral types](http://msdn.microsoft.com/en-us/library/exx3b86w.aspx) and [floating-point types](http://msdn.microsoft.com/en-us/library/9ahet949.aspx) are supported.

Just as a convenience, this library also supports strings as they are extremely common. This is the <b><u>only</u></b> referece type that is supported. Use a serializer such as [James Newton-King's Json.NET](http://james.newtonking.com/json) if you need to serialize reference types.
		
		
