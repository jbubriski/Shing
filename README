# SHING!
## The sound of your amazon wishlist being parsed!

## What is Shing?
Shing is a library for the .Net Framework, written in C# that parses Amazon Wish Lists. 

## How do I use it
For now, you need to pull the source down and compile it, but eventually this will be a Nuget package.

Then just add the Shing.dll file as a reference to your project and try the following sample:

```c#
var items = WishList.ScrapeUrl("http://www.amazon.com/gp/registry/wishlist/3ON5W8HBTKUOI/ref=wl_web");

foreach(var item in items) {
	Console.WriteLine( item.FriendlyName + " - " + item.Price.ToString("C") );
}
```