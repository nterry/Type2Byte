Type2Byte
=========

A class for converting managed integral types to byte arrays and vice versa

But BitConverter already exists! Why use this?
----------------------------------------------
A good question. BitConverter is a great class, but <b>ONLY</b> works with the Microsoft CLR. it <b><u>DOES NOT</u></b> work with Mono.


But Mono has DataConvert. Couldn't I just check the platform and use the appropriate lib?
----------------------------------------------------------------------------------------- 
To quote the guys at Xamarin (the developers and maintainers of Mono):
>Having code that depends on the underlying runtime is considered to be bad coding style, but sometimes such code is >necessary to work around runtime bugs...

Indeed, It is bad practice to have platform-specific code and <b>SHOULD BE AVOIDED</b> wherever possible. This library works with <b>BOTH</b> Mono and the CLR. 

In addition, it should be noted that Mono.DataConvert uses UNSAFE code. If you use library that is marked with unsafe code, your whole project has to marked as such, an you lose all guarantees that the runtime affords to you. You might as well code it in C at this point...

Besides, do you <i>REALLY</i> want to have more than one dependency?


Ok, sold, But how do I use it?
------------------------------
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
			short s = B2T.Get<short>(aByteArray);
			int i = B2T.Get<int>(anotherByteArray);
		}
	}
	
And thats it! All [integral types](http://msdn.microsoft.com/en-us/library/exx3b86w.aspx)(<b>EXCEPT</b> decimal) and [floating-point](http://msdn.microsoft.com/en-us/library/9ahet949.aspx) are supported.

Just as a convenience, this library also supports strings as they are used <b>SO</b> very much. This is the <b><u>ONLY</u></b> referece type that is supported. Use a serializer such as [James Newton-King's Json.NET](http://james.newtonking.com/json) if you need to serialize reference types.
		
		